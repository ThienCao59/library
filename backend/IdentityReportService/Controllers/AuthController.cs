using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using IdentityReportService.DTOs;
using IdentityReportService.Models;
using IdentityReportService.Services;
using IdentityReportService.Data;

namespace IdentityReportService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IAuthHandoffService _authHandoffService;
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IEventLogService _eventLogService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            IJwtTokenService jwtTokenService,
            IAuthHandoffService authHandoffService,
            AppDbContext context,
            IEmailService emailService,
            IEventLogService eventLogService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _authHandoffService = authHandoffService;
            _context = context;
            _emailService = emailService;
            _eventLogService = eventLogService;
        }

        [AllowAnonymous]
        [EnableRateLimiting("auth")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userExists = await _userManager.FindByNameAsync(dto.Username);
            if (userExists != null)
                return BadRequest(new { Message = "Username already exists!" });

            var emailExists = await _userManager.FindByEmailAsync(dto.Email);
            if (emailExists != null)
                return BadRequest(new { Message = "Email already exists!" });

            var user = new ApplicationUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                // Public registration is always Reader — never trust Role from client
                Role = "Reader",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "User creation failed!", Errors = result.Errors });
            }

            // Create Library Card automatically ONLY for Reader role
            if (user.Role == "Reader")
            {
                var libraryCard = new LibraryCard
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    CardNumber = "LIB-" + new Random().Next(100000, 999999),
                    IssueDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddYears(1),
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow
                };

                _context.LibraryCards.Add(libraryCard);
                await _context.SaveChangesAsync();

                await _eventLogService.LogAsync("user.registered", new
                {
                    userId = user.Id,
                    username = user.UserName,
                    fullName = user.FullName,
                    role = user.Role,
                    cardNumber = libraryCard.CardNumber
                });

                return Ok(new { Message = "User registered successfully!", CardNumber = libraryCard.CardNumber });
            }

            await _eventLogService.LogAsync("user.registered", new
            {
                userId = user.Id,
                username = user.UserName,
                fullName = user.FullName,
                role = user.Role
            });

            return Ok(new { Message = "User registered successfully!", CardNumber = (string?)null });
        }

        [AllowAnonymous]
        [EnableRateLimiting("auth")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Support login by username OR phone number
            ApplicationUser? user = await _userManager.FindByNameAsync(dto.Username);
            
            // If not found by username, try to find by phone number (10-digit pattern)
            if (user == null && dto.Username.Length >= 9 && dto.Username.All(char.IsDigit))
            {
                user = _context.Users.FirstOrDefault(u => u.PhoneNumber == dto.Username);
            }

            if (user == null || !user.IsActive)
                return Unauthorized(new { Message = "Invalid username/phone or password, or account is disabled." });

            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
                return Unauthorized(new { Message = "Invalid username or password." });

            var roles = await _userManager.GetRolesAsync(user);
            
            // If Identity roles is empty, fallback to the string Role property
            if (roles.Count == 0)
            {
                roles = new List<string> { user.Role };
            }

            // Fetch CardNumber before generating token so it can be embedded as a claim
            var card = _context.LibraryCards.FirstOrDefault(c => c.UserId == user.Id);

            var accessToken = _jwtTokenService.GenerateAccessToken(user, roles, card?.CardNumber);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();

            user.PreviousRefreshToken = null;
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            user.UpdatedAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            await _eventLogService.LogAsync("user.login", new
            {
                userId = user.Id,
                username = user.UserName,
                fullName = user.FullName,
                role = user.Role
            });

            return Ok(new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Username = user.UserName!,
                Email = user.Email!,
                Role = user.Role,
                UserId = user.Id,
                CardNumber = card?.CardNumber
            });
        }

        [AllowAnonymous]
        [EnableRateLimiting("token-refresh")]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string accessToken = dto.AccessToken;
            string refreshToken = dto.RefreshToken;

            try
            {
                var principal = _jwtTokenService.GetPrincipalFromExpiredToken(accessToken);
                if (principal == null)
                    return BadRequest(new { Message = "Invalid access token" });

                var username = principal.Identity?.Name;
                if (string.IsNullOrEmpty(username))
                    return BadRequest(new { Message = "Invalid token claims" });

                var user = await _userManager.FindByNameAsync(username);
                if (user == null || !user.IsActive)
                    return BadRequest(new { Message = "Invalid or expired refresh token" });

                if (user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                    return BadRequest(new { Message = "Invalid or expired refresh token" });

                if (user.PreviousRefreshToken == refreshToken)
                {
                    user.RefreshToken = null;
                    user.PreviousRefreshToken = null;
                    user.RefreshTokenExpiryTime = null;
                    user.UpdatedAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(user);

                    return Unauthorized(new
                    {
                        Message = "Refresh token reuse detected. All sessions have been revoked.",
                        Code = "REFRESH_TOKEN_REUSE"
                    });
                }

                if (user.RefreshToken != refreshToken)
                    return BadRequest(new { Message = "Invalid or expired refresh token" });

                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count == 0)
                {
                    roles = new List<string> { user.Role };
                }

                // Fetch CardNumber before generating token so it can be embedded as a claim
                var card = _context.LibraryCards.FirstOrDefault(c => c.UserId == user.Id);

                var newAccessToken = _jwtTokenService.GenerateAccessToken(user, roles, card?.CardNumber);
                var newRefreshToken = _jwtTokenService.GenerateRefreshToken();

                user.PreviousRefreshToken = user.RefreshToken;
                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                user.UpdatedAt = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);

                return Ok(new AuthResponseDto
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                    Username = user.UserName!,
                    Email = user.Email!,
                    Role = user.Role,
                    UserId = user.Id,
                    CardNumber = card?.CardNumber
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Token renewal failed", Error = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                // Return success to avoid user enumeration attacks, but with a warning in local logs
                return Ok(new { Message = "Nếu email chính xác và đã được đăng ký, mã xác thực đặt lại mật khẩu đã được gửi đi!" });
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var htmlMessage = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 8px;'>
                    <h2 style='color: #1E5652; text-align: center;'>Yêu Cầu Đặt Lại Mật Khẩu</h2>
                    <p>Xin chào <strong>{user.FullName}</strong>,</p>
                    <p>Chúng tôi nhận được yêu cầu đặt lại mật khẩu cho tài khoản thư viện của bạn. Dưới đây là mã xác thực của bạn:</p>
                    <div style='background-color: #f5f5f5; padding: 15px; border-radius: 6px; text-align: center; font-size: 24px; font-weight: bold; letter-spacing: 2px; color: #d35230; margin: 20px 0;'>
                        {token}
                    </div>
                    <p style='color: #555;'>Vui lòng sao chép mã này và dán vào trang đặt lại mật khẩu trên website để hoàn tất đổi mật khẩu.</p>
                    <p style='color: #e07a5f; font-size: 12px;'>Lưu ý: Mã này chỉ có hiệu lực trong vòng 2 tiếng. Nếu bạn không yêu cầu hành động này, vui lòng bỏ qua email này.</p>
                    <hr style='border: none; border-top: 1px solid #eee; margin: 20px 0;' />
                    <p style='font-size: 11px; color: #999; text-align: center;'>SmartLib System - Hỗ trợ kỹ thuật bởi Group 3</p>
                </div>";

            try
            {
                await _emailService.SendEmailAsync(user.Email!, "Đặt lại mật khẩu - SmartLib System", htmlMessage);
            }
            catch (Exception ex)
            {
                // In case of SMTP send failure, we log it and still return OK with the token in dev mode
                // so the user can test the reset workflow seamlessly
                Console.WriteLine($"SMTP sending failed: {ex.Message}");
            }

            return Ok(new { 
                Message = "Mã xác thực đặt lại mật khẩu đã được gửi đến email của bạn!" 
            });
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return BadRequest(new { Message = "Email không tồn tại trong hệ thống!" });
            }

            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Đặt lại mật khẩu thất bại!", Errors = result.Errors });
            }

            return Ok(new { Message = "Đặt lại mật khẩu thành công! Bạn có thể đăng nhập bằng mật khẩu mới." });
        }

        [Authorize]
        [HttpPost("handoff")]
        public async Task<IActionResult> CreateHandoff()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null || !user.IsActive)
                return Unauthorized(new { Message = "Account locked or disabled." });

            if (string.IsNullOrEmpty(user.RefreshToken) || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return Unauthorized(new { Message = "Session expired. Please log in again." });

            var accessToken = Request.Headers.Authorization.ToString().Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase).Trim();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var card = _context.LibraryCards.FirstOrDefault(c => c.UserId == user.Id);

            var handoff = _authHandoffService.CreateHandoffCode(new AuthHandoffPayload
            {
                AccessToken = accessToken,
                RefreshToken = user.RefreshToken,
                Username = user.UserName!,
                Email = user.Email!,
                Role = user.Role,
                UserId = user.Id,
                CardNumber = card?.CardNumber
            });

            return Ok(handoff);
        }

        [AllowAnonymous]
        [EnableRateLimiting("auth")]
        [HttpPost("handoff/redeem")]
        public IActionResult RedeemHandoff([FromBody] RedeemHandoffDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var session = _authHandoffService.RedeemHandoffCode(dto.Code);
            if (session == null)
                return BadRequest(new { Message = "Invalid or expired handoff code." });

            return Ok(session);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Unauthorized();

            user.RefreshToken = null;
            user.PreviousRefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            user.UpdatedAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            await _eventLogService.LogAsync("user.logout", new
            {
                userId = user.Id,
                username = user.UserName,
                fullName = user.FullName,
                role = user.Role
            });

            return Ok(new { Message = "Logged out successfully." });
        }

        [Authorize]
        [HttpGet("validate")]
        public async Task<IActionResult> ValidateToken()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username)) return Unauthorized();

            var user = await _userManager.FindByNameAsync(username);
            if (user == null || !user.IsActive)
                return Unauthorized(new { Message = "Account locked or disabled." });

            return Ok();
        }
    }
}
