<template>
  <div class="features-page-container">
    <!-- Navbar (Shared style) -->
    <header class="navbar">
      <div class="logo" @click="$router.push('/')">
        <v-icon icon="mdi-library" class="mr-2 logo-icon"></v-icon>
        <span class="logo-text">SmartLib.NET</span>
      </div>
      <nav class="nav-links">
        <a href="#" @click.prevent="$router.push('/')">HOME</a>
        <a href="#" class="active" @click.prevent="$router.push('/features')">FEATURES</a>
        <a href="#" @click.prevent="$router.push('/statistics')">STATISTICS</a>
        <a href="#" @click.prevent="$router.push('/reviews')">REVIEWS</a>
      </nav>
      <div class="nav-auth">
        <a-button type="text" class="btn-login mr-2" @click="$router.push('/login')">Sign in</a-button>
        <a-button type="primary" shape="round" class="btn-register" @click="$router.push('/register')">Sign up</a-button>
      </div>
    </header>

    <!-- Main Hero Subheader -->
    <div class="features-hero">
      <div class="hero-glow"></div>
      <div class="features-hero-content text-center">
        <span class="badge-tag">HỆ THỐNG CAO CẤP</span>
        <h1 class="features-title">Tính Năng Đột Phá</h1>
        <p class="features-subtitle">
          Khám phá hệ sinh thái quản lý thư viện số tự động ứng dụng các công nghệ hiện đại nhất.
        </p>
      </div>
    </div>

    <!-- Features Showcase Section -->
    <div class="showcase-section">
      <!-- Feature 1: Digital Card Issuing & RFID -->
      <div class="feature-detail-row">
        <div class="detail-left">
          <span class="feature-num">01</span>
          <h2 class="section-title">Cấp Thẻ Số Tự Động & RFID</h2>
          <p class="section-desc">
            Không còn phải xếp hàng làm thủ tục rườm rà. Hệ thống tích hợp dịch vụ định danh tự động 
            cho phép cấp thẻ thư viện số có mã QR cá nhân hóa chỉ trong 3 giây.
          </p>
          <div class="feature-bullets">
            <div class="bullet-item">
              <v-icon icon="mdi-shield-check" class="bullet-icon"></v-icon>
              <span>Xác thực OTP & Tự động phê duyệt chính sách liên kết.</span>
            </div>
            <div class="bullet-item">
              <v-icon icon="mdi-qrcode" class="bullet-icon"></v-icon>
              <span>Mã QR bảo mật động thay đổi liên tục chống gian lận.</span>
            </div>
            <div class="bullet-item">
              <v-icon icon="mdi-card-bulleted" class="bullet-icon"></v-icon>
              <span>Hỗ trợ đồng bộ hóa thẻ vật lý RFID của trường học.</span>
            </div>
          </div>
        </div>
        <div class="detail-right">
          <!-- Interactive Virtual Card Simulator -->
          <div class="card-simulator-box">
            <div class="sim-card">
              <div class="card-chip"></div>
              <div class="card-logo">SmartLib.NET</div>
              <div class="card-body">
                <div class="sim-qr">
                  <!-- Vector QR Mockup -->
                  <svg viewBox="0 0 100 100" class="qr-svg">
                    <rect x="0" y="0" width="100" height="100" fill="white" />
                    <rect x="10" y="10" width="25" height="25" fill="#1E5652" />
                    <rect x="15" y="15" width="15" height="15" fill="white" />
                    <rect x="65" y="10" width="25" height="25" fill="#1E5652" />
                    <rect x="70" y="15" width="15" height="15" fill="white" />
                    <rect x="10" y="65" width="25" height="25" fill="#1E5652" />
                    <rect x="15" y="15" width="15" height="15" fill="white" />
                    <!-- Random dots -->
                    <rect x="45" y="20" width="10" height="10" fill="#1E5652" />
                    <rect x="40" y="45" width="15" height="10" fill="#1E5652" />
                    <rect x="20" y="45" width="10" height="15" fill="#CF7C07" />
                    <rect x="65" y="45" width="20" height="20" fill="#1E5652" />
                    <rect x="45" y="70" width="20" height="15" fill="#CF7C07" />
                  </svg>
                </div>
                <div class="sim-info">
                  <div class="info-lbl">MÃ THẺ THƯ VIỆN</div>
                  <div class="info-val">LIB-884920</div>
                  <div class="info-lbl mt-2">ĐỘC GIẢ</div>
                  <div class="info-val">NGUYỄN VĂN A</div>
                </div>
              </div>
            </div>
            <div class="pulsing-radar"></div>
          </div>
        </div>
      </div>

      <!-- Feature 2: Smart Search & Catalog Engine -->
      <div class="feature-detail-row reverse">
        <div class="detail-left">
          <span class="feature-num">02</span>
          <h2 class="section-title">Tìm Kiếm Thông Minh & Gợi Ý Sách</h2>
          <p class="section-desc">
            Ứng dụng thuật toán phân tích hành vi đọc để đưa ra các gợi ý sách cá nhân hóa chuẩn xác, 
            kết hợp bộ lọc thông minh nhiều tiêu chí giúp tra cứu tài liệu nhanh gọn.
          </p>
          <div class="feature-bullets">
            <div class="bullet-item">
              <v-icon icon="mdi-magnify-plus" class="bullet-icon"></v-icon>
              <span>Tìm kiếm tức thời Full-text Search tốc độ mili-giây.</span>
            </div>
            <div class="bullet-item">
              <v-icon icon="mdi-brain" class="bullet-icon"></v-icon>
              <span>Gợi ý dựa trên chủ đề yêu thích và lịch sử mượn trả.</span>
            </div>
            <div class="bullet-item">
              <v-icon icon="mdi-bookmark-multiple" class="bullet-icon"></v-icon>
              <span>Quản lý danh mục đa tầng và trạng thái sách theo thời gian thực.</span>
            </div>
          </div>
        </div>
        <div class="detail-right">
          <!-- Interactive Search Mockup -->
          <div class="search-simulator-box">
            <div class="search-bar-sim">
              <v-icon icon="mdi-magnify" class="mr-2"></v-icon>
              <input type="text" placeholder="Tìm kiếm sách..." value="ASP.NET Core" disabled />
              <div class="search-glow-pill">Search</div>
            </div>
            <div class="search-results-sim mt-4">
              <div class="result-card-sim">
                <div class="book-cover-mini text-center">C#</div>
                <div class="result-info">
                  <div class="result-title">Lập Trình ASP.NET Core MVC</div>
                  <div class="result-author">Nguyễn Văn B (2025)</div>
                  <div class="result-status-tag available">Sẵn sàng mượn</div>
                </div>
              </div>
              <div class="result-card-sim">
                <div class="book-cover-mini second text-center">EF</div>
                <div class="result-info">
                  <div class="result-title">Entity Framework Core 9</div>
                  <div class="result-author">Trần Thị C (2026)</div>
                  <div class="result-status-tag borrowing">Đang mượn</div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- Feature 3: Microservices & Observability Visualizer -->
      <div class="feature-detail-row">
        <div class="detail-left">
          <span class="feature-num">03</span>
          <h2 class="section-title">Kiến Trúc Microservices Đỉnh Cao</h2>
          <p class="section-desc">
            Không chỉ là một hệ thống đơn lẻ. SmartLib.NET được xây dựng trên nền tảng kiến trúc 
            Microservices mạnh mẽ, kết hợp API Gateway hiện đại điều hướng lưu lượng an toàn.
          </p>
          <div class="feature-bullets">
            <div class="bullet-item">
              <v-icon icon="mdi-dns" class="bullet-icon"></v-icon>
              <span>Độc lập dịch vụ: CatalogService, IdentityService, NotificationService.</span>
            </div>
            <div class="bullet-item">
              <v-icon icon="mdi-lan" class="bullet-icon"></v-icon>
              <span>Giao tiếp phi đồng bộ siêu tốc qua RabbitMQ Event Bus.</span>
            </div>
            <div class="bullet-item">
              <v-icon icon="mdi-eye-outline" class="bullet-icon"></v-icon>
              <span>Observability: Health checks tập trung và ghi log Serilog chuyên sâu.</span>
            </div>
          </div>
        </div>
        <div class="detail-right">
          <!-- Live Architecture Visualizer Diagram -->
          <div class="architecture-diagram-box">
            <div class="diagram-client">Client UI</div>
            <div class="diagram-arrow pulsing-arrow">▼</div>
            <div class="diagram-gateway">API Gateway (Ocelot / Reverse Proxy)</div>
            <div class="diagram-split">
              <div class="diagram-service">
                <div class="service-dot pulse-green"></div>
                Identity
              </div>
              <div class="diagram-service secondary">
                <div class="service-dot pulse-green"></div>
                Catalog
              </div>
              <div class="diagram-service tertiary">
                <div class="service-dot pulse-orange"></div>
                RabbitMQ
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Call to Action Section -->
    <div class="features-cta text-center">
      <h2 class="cta-heading mb-4">Trải Nghiệm Dịch Vụ Thư Viện Thế Hệ Mới</h2>
      <p class="cta-sub mb-8">Đăng ký tài khoản và nhận thẻ thư viện trực tuyến tự động ngay hôm nay.</p>
      <button class="btn-cta-register" @click="$router.push('/register')">
        Đăng Ký Ngay
      </button>
    </div>

    <!-- Beautiful Footer -->
    <footer class="footer py-12">
      <div class="footer-content text-center">
        <div class="footer-logo mb-4">
          <v-icon icon="mdi-library" class="mr-2"></v-icon>
          <span>SmartLib.NET</span>
        </div>
        <p class="footer-text mb-6">Mở cánh cửa tri thức - Kiến tạo tương lai tốt đẹp hơn</p>
        <p class="copyright-text">© 2026 SmartLib.NET - Developed by Group 3. All rights reserved.</p>
      </div>
    </footer>
  </div>
</template>

<script setup lang="ts">
// No complex reactive logic needed, purely highly dynamic visual presentation
</script>

<style scoped>
.features-page-container {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background-color: #FAF9F6;
  overflow-x: hidden;
  padding-top: 80px;
}

/* Navbar fixed top */
.navbar {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 16px 60px;
  background-color: rgba(250, 249, 246, 0.92);
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px);
  z-index: 1000;
  border-bottom: 1px solid rgba(0, 0, 0, 0.05);
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.02);
}

.logo {
  display: flex;
  align-items: center;
  cursor: pointer;
}

.logo-icon {
  font-size: 28px;
  color: #1E5652 !important;
}

.logo-text {
  font-size: 24px;
  font-weight: 800;
  color: #1E5652;
  letter-spacing: 1px;
}

.nav-links {
  display: flex;
  gap: 32px;
}

.nav-links a {
  text-decoration: none;
  font-size: 15px;
  font-weight: 700;
  color: #5C6765;
  letter-spacing: 1.5px;
  transition: color 0.3s;
}

.nav-links a.active, .nav-links a:hover {
  color: #1E5652;
}

.nav-auth {
  display: flex;
  align-items: center;
}

.btn-login {
  font-size: 15px !important;
  font-weight: 700 !important;
  color: #1E5652 !important;
}

.btn-register {
  background-color: #1E5652 !important;
  border-color: #1E5652 !important;
  color: white !important;
  font-weight: 700 !important;
  font-size: 14px !important;
  box-shadow: 0 4px 10px rgba(30, 86, 82, 0.2);
  transition: transform 0.3s;
}

.btn-register:hover {
  transform: translateY(-1px);
}

/* Features Hero Header */
.features-hero {
  position: relative;
  padding: 100px 20px 80px 20px;
  background-color: #1E5652;
  color: white;
  overflow: hidden;
}

.hero-glow {
  position: absolute;
  top: -150%;
  left: -50%;
  width: 200%;
  height: 300%;
  background: radial-gradient(circle, rgba(207,124,7,0.15) 0%, rgba(255,255,255,0) 70%);
  z-index: 1;
}

.features-hero-content {
  position: relative;
  z-index: 5;
  max-width: 800px;
  margin: 0 auto;
}

.badge-tag {
  background-color: #CF7C07;
  color: white;
  padding: 6px 16px;
  font-size: 11px;
  font-weight: 800;
  letter-spacing: 2px;
  border-radius: 20px;
  display: inline-block;
  margin-bottom: 20px;
  box-shadow: 0 4px 12px rgba(207, 124, 7, 0.3);
}

.features-title {
  font-size: 56px;
  font-weight: 800;
  font-family: 'Outfit', sans-serif;
  line-height: 1.1;
  margin-bottom: 20px;
  background: linear-gradient(135deg, #FAF9F6 0%, #DCEAD5 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
}

.features-subtitle {
  font-size: 18px;
  color: #CBE0DE;
  line-height: 1.6;
  max-width: 600px;
  margin: 0 auto;
}

/* Showcase Section */
.showcase-section {
  max-width: 1100px;
  margin: 80px auto;
  padding: 0 40px;
}

.feature-detail-row {
  display: flex;
  align-items: center;
  gap: 80px;
  margin-bottom: 120px;
}

.feature-detail-row.reverse {
  flex-direction: row-reverse;
}

.detail-left {
  flex: 1.2;
}

.feature-num {
  font-size: 48px;
  font-weight: 900;
  color: rgba(30, 86, 82, 0.15);
  font-family: 'Outfit', sans-serif;
  display: block;
  margin-bottom: 10px;
}

.section-title {
  font-size: 36px;
  font-weight: 800;
  color: #114B44;
  margin-bottom: 20px;
  font-family: 'Outfit', sans-serif;
}

.section-desc {
  font-size: 15px;
  color: #5C6765;
  line-height: 1.8;
  margin-bottom: 30px;
}

.bullet-item {
  display: flex;
  align-items: flex-start;
  gap: 14px;
  margin-bottom: 18px;
}

.bullet-icon {
  color: #CF7C07 !important;
  font-size: 20px !important;
  margin-top: 2px;
}

.bullet-item span {
  font-size: 14px;
  font-weight: 600;
  color: #3C4745;
  line-height: 1.5;
}

.detail-right {
  flex: 1;
  display: flex;
  justify-content: center;
  align-items: center;
}

/* Virtual Card simulator style */
.card-simulator-box {
  width: 100%;
  max-width: 340px;
  position: relative;
}

.sim-card {
  background: linear-gradient(135deg, #114B44 0%, #1E5652 100%);
  color: white;
  border-radius: 16px;
  padding: 24px;
  box-shadow: 0 15px 30px rgba(30, 86, 82, 0.25);
  border: 1px solid rgba(255,255,255,0.1);
  position: relative;
  z-index: 5;
}

.card-chip {
  width: 40px;
  height: 30px;
  background: linear-gradient(135deg, #F5B041 0%, #CF7C07 100%);
  border-radius: 6px;
  margin-bottom: 20px;
}

.card-logo {
  position: absolute;
  top: 24px;
  right: 24px;
  font-weight: 800;
  font-size: 13px;
  letter-spacing: 0.5px;
}

.sim-card .card-body {
  display: flex;
  gap: 20px;
  align-items: center;
}

.sim-qr {
  width: 80px;
  height: 80px;
  border-radius: 8px;
  overflow: hidden;
  box-shadow: 0 4px 10px rgba(0,0,0,0.15);
}

.qr-svg {
  width: 100%;
  height: 100%;
}

.info-lbl {
  font-size: 8px;
  color: #BBE1DC;
  font-weight: 700;
  letter-spacing: 1px;
}

.info-val {
  font-size: 13px;
  font-weight: 800;
  letter-spacing: 0.5px;
}

.pulsing-radar {
  position: absolute;
  top: 50%;
  left: 50%;
  width: 108%;
  height: 108%;
  border: 2px solid #CF7C07;
  border-radius: 20px;
  transform: translate(-50%, -50%);
  z-index: 1;
  animation: radar 2s infinite ease-out;
  opacity: 0;
}

@keyframes radar {
  0% {
    width: 100%;
    height: 100%;
    opacity: 0.8;
  }
  100% {
    width: 114%;
    height: 114%;
    opacity: 0;
  }
}

/* Search simulator style */
.search-simulator-box {
  width: 100%;
  background: white;
  border-radius: 16px;
  padding: 20px;
  box-shadow: 0 10px 30px rgba(0,0,0,0.04);
  border: 1px solid rgba(0,0,0,0.02);
}

.search-bar-sim {
  display: flex;
  align-items: center;
  background-color: #FAF9F6;
  border-radius: 24px;
  padding: 8px 16px;
  border: 1px solid rgba(0,0,0,0.05);
}

.search-bar-sim input {
  border: none;
  background: transparent;
  outline: none;
  font-size: 13px;
  flex: 1;
  color: #3C4745;
  font-weight: 600;
}

.search-glow-pill {
  background-color: #1E5652;
  color: white;
  font-size: 11px;
  font-weight: 700;
  padding: 4px 12px;
  border-radius: 12px;
}

.result-card-sim {
  display: flex;
  gap: 16px;
  align-items: center;
  padding: 12px;
  border-bottom: 1px solid rgba(0,0,0,0.03);
}

.result-card-sim:last-child {
  border-bottom: none;
}

.book-cover-mini {
  width: 40px;
  height: 56px;
  background-color: #1E5652;
  color: white;
  font-weight: 800;
  font-size: 13px;
  line-height: 56px;
  border-radius: 4px;
  box-shadow: 0 3px 6px rgba(0,0,0,0.1);
}

.book-cover-mini.second {
  background-color: #CF7C07;
}

.result-title {
  font-size: 13px;
  font-weight: 700;
  color: #114B44;
}

.result-author {
  font-size: 11px;
  color: #7A8583;
}

.result-status-tag {
  font-size: 9px;
  font-weight: 800;
  padding: 1px 6px;
  border-radius: 4px;
  width: fit-content;
  margin-top: 4px;
}

.result-status-tag.available {
  background-color: #EBF3E8;
  color: #1E5652;
}

.result-status-tag.borrowing {
  background-color: #FDF2E2;
  color: #CF7C07;
}

/* Architecture visualizer style */
.architecture-diagram-box {
  width: 100%;
  background-color: #1E332E;
  border-radius: 16px;
  padding: 24px;
  box-shadow: 0 15px 30px rgba(0,0,0,0.15);
  color: white;
  text-align: center;
  font-family: monospace;
}

.diagram-client {
  background-color: rgba(255,255,255,0.08);
  border: 1px dashed rgba(255,255,255,0.3);
  padding: 8px;
  border-radius: 8px;
  font-size: 12px;
}

.diagram-arrow {
  color: #CF7C07;
  font-size: 14px;
  margin: 6px 0;
}

.pulsing-arrow {
  animation: arrowPulse 1.5s infinite;
}

@keyframes arrowPulse {
  0%, 100% { opacity: 0.3; transform: translateY(-2px); }
  50% { opacity: 1; transform: translateY(2px); }
}

.diagram-gateway {
  background-color: #CF7C07;
  font-weight: bold;
  padding: 10px;
  border-radius: 8px;
  font-size: 12px;
  box-shadow: 0 4px 10px rgba(207, 124, 7, 0.2);
}

.diagram-split {
  display: flex;
  justify-content: space-around;
  margin-top: 20px;
  gap: 10px;
}

.diagram-service {
  background-color: #114B44;
  border: 1px solid rgba(255,255,255,0.1);
  padding: 10px;
  border-radius: 8px;
  font-size: 11px;
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 6px;
}

.diagram-service.secondary {
  background-color: #277D78;
}

.diagram-service.tertiary {
  background-color: #533527;
}

.service-dot {
  width: 8px;
  height: 8px;
  border-radius: 50%;
}

.pulse-green {
  background-color: #2ECC71;
  box-shadow: 0 0 8px #2ECC71;
  animation: servicePulse 1s infinite alternate;
}

.pulse-orange {
  background-color: #E67E22;
  box-shadow: 0 0 8px #E67E22;
  animation: servicePulse 1.2s infinite alternate;
}

@keyframes servicePulse {
  0% { transform: scale(0.9); opacity: 0.6; }
  100% { transform: scale(1.2); opacity: 1; }
}

/* Call to Action */
.features-cta {
  background-color: #114B44;
  color: white;
  padding: 80px 20px;
  position: relative;
  overflow: hidden;
}

.cta-heading {
  font-size: 38px;
  font-weight: 800;
  font-family: 'Outfit', sans-serif;
}

.cta-sub {
  font-size: 16px;
  color: #BBE1DC;
  max-width: 500px;
  margin: 0 auto;
}

.btn-cta-register {
  position: relative;
  overflow: hidden;
  background-color: #CF7C07;
  color: white;
  border: none;
  border-radius: 40px;
  padding: 16px 48px;
  font-size: 16px;
  font-weight: 700;
  cursor: pointer;
  box-shadow: 0 6px 20px rgba(207, 124, 7, 0.35);
  transition: transform 0.2s, background-color 0.3s;
}

.btn-cta-register::after {
  content: '';
  position: absolute;
  top: -50%;
  left: -60%;
  width: 30%;
  height: 200%;
  background: rgba(255, 255, 255, 0.4);
  transform: rotate(30deg);
  animation: btnShine 4.5s infinite ease-in-out;
}

.btn-cta-register:hover {
  background-color: #B56C05;
  transform: translateY(-2px);
}

/* Footer styling */
.footer {
  background-color: #0A2E2A;
  color: white;
  border-top: 1px solid rgba(255,255,255,0.05);
}

.footer-logo {
  font-size: 24px;
  font-weight: 800;
  color: #FAF9F6;
}

.footer-text {
  font-size: 14px;
  color: #7A9E9A;
}

.copyright-text {
  font-size: 11px;
  color: #567C78;
}

@media (max-width: 850px) {
  .feature-detail-row, .feature-detail-row.reverse {
    flex-direction: column;
    gap: 40px;
    margin-bottom: 80px;
  }
  .navbar {
    padding: 16px 30px;
  }
}
</style>
