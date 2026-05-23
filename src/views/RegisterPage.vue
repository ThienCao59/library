<template>
  <div class="auth-page-container">
    <div class="split-container signup-style">
      <!-- LEFT PANEL: Premium Nature Scenery SVG Illustration exactly like Sample 1 -->
      <div class="scenery-panel">
        <svg class="nature-illustration" viewBox="0 0 400 500" preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg">
          <!-- Sky / Background -->
          <rect width="400" height="500" fill="#EBF3E8" />
          
          <!-- Soft Clouds -->
          <path d="M 20 80 Q 40 70 60 80 T 100 80 T 140 80 Z" fill="#FAF9F6" opacity="0.6" />
          <path d="M 220 60 Q 240 50 260 60 T 300 60 T 340 60 Z" fill="#FAF9F6" opacity="0.6" />
          
          <!-- Sun / Light glow -->
          <circle cx="200" cy="180" r="140" fill="#FAF9F6" opacity="0.4" />
          
          <!-- Distant Mountains -->
          <path d="M 0 350 L 80 250 L 180 320 L 280 220 L 400 310 L 400 500 L 0 500 Z" fill="#C3DEC6" opacity="0.7" />
          
          <!-- Flying Birds -->
          <path d="M 240 180 Q 245 175 250 180 Q 255 175 260 180" fill="none" stroke="#7A8F7C" stroke-width="1.5" />
          <path d="M 265 170 Q 268 166 272 170 Q 276 166 280 170" fill="none" stroke="#7A8F7C" stroke-width="1.2" />

          <!-- Cozy cabins/houses with red roofs -->
          <g transform="translate(130, 270)">
            <rect x="0" y="10" width="32" height="20" fill="#FAF9F6" rx="2" />
            <polygon points="0,10 16,0 32,10" fill="#D35230" />
            <rect x="12" y="18" width="8" height="12" fill="#434D4B" />
          </g>
          <g transform="translate(260, 290) scale(0.8)">
            <rect x="0" y="10" width="32" height="20" fill="#FAF9F6" rx="2" />
            <polygon points="0,10 16,0 32,10" fill="#D35230" />
            <rect x="12" y="18" width="8" height="12" fill="#434D4B" />
          </g>

          <!-- Rolling Forest Hills -->
          <path d="M 0 420 Q 120 370 240 400 T 400 360 L 400 500 L 0 500 Z" fill="#84A98C" />
          <path d="M 0 450 Q 150 410 300 440 T 400 420 L 400 500 L 0 500 Z" fill="#52796F" />
          <path d="M 0 480 Q 180 440 360 470 T 400 450 L 400 500 L 0 500 Z" fill="#354F52" />
          <path d="M 0 495 L 400 495 L 400 500 L 0 500 Z" fill="#2F3E46" />

          <!-- Elegant Pine Trees -->
          <g transform="translate(20, 240) scale(0.6)" fill="#354F52">
            <polygon points="30,0 0,60 60,60" />
            <polygon points="30,30 5,90 55,90" />
            <polygon points="30,60 10,120 50,120" />
            <rect x="25" y="120" width="10" height="20" fill="#533527" />
          </g>
          <g transform="translate(60, 260) scale(0.5)" fill="#354F52">
            <polygon points="30,0 0,60 60,60" />
            <polygon points="30,30 5,90 55,90" />
            <rect x="25" y="90" width="10" height="20" fill="#533527" />
          </g>
          <g transform="translate(320, 250) scale(0.7)" fill="#354F52">
            <polygon points="30,0 0,60 60,60" />
            <polygon points="30,30 5,90 55,90" />
            <polygon points="30,60 10,120 50,120" />
            <rect x="25" y="120" width="10" height="20" fill="#533527" />
          </g>

          <!-- Forest Trees in Foreground -->
          <g transform="translate(360, 310) scale(0.9)" fill="#2F3E46">
            <polygon points="20,0 0,50 40,50" />
            <polygon points="20,20 5,70 35,70" />
            <rect x="17" y="70" width="6" height="15" fill="#533527" />
          </g>

          <!-- Elegant Deer Silhouettes -->
          <!-- Deer 1 (Looking right) -->
          <g transform="translate(70, 385) scale(0.5)" fill="#1E332E">
            <!-- Body -->
            <ellipse cx="40" cy="40" rx="20" ry="12" />
            <!-- Neck & Head -->
            <path d="M 52 35 C 55 25 58 12 55 5 C 53 2 48 2 45 4 M 45 4 L 40 8 L 48 18 Z" />
            <!-- Antlers -->
            <path d="M 48 4 Q 45 -10 35 -15 M 48 4 Q 52 -12 60 -18 M 43 -8 Q 40 -8 38 -12 M 53 -10 Q 56 -10 58 -14" stroke="#1E332E" stroke-width="2" fill="none" stroke-linecap="round" />
            <!-- Legs -->
            <rect x="25" y="48" width="4" height="22" rx="1" />
            <rect x="33" y="48" width="4" height="22" rx="1" />
            <rect x="45" y="46" width="4" height="24" rx="1" />
            <rect x="51" y="46" width="3.5" height="24" rx="1" />
            <!-- Tail -->
            <path d="M 20 34 Q 16 30 18 36 Z" />
          </g>

          <!-- Deer 2 (Smaller, eating) -->
          <g transform="translate(130, 410) scale(0.4)" fill="#1E332E">
            <!-- Body -->
            <ellipse cx="40" cy="40" rx="18" ry="11" />
            <!-- Neck & Head leaning down -->
            <path d="M 50 38 C 55 42 62 48 68 49 C 70 50 72 48 70 45 C 65 38 55 33 50 33 Z" />
            <!-- Legs -->
            <rect x="26" y="48" width="3.5" height="18" rx="1" />
            <rect x="32" y="48" width="3.5" height="18" rx="1" />
            <rect x="44" y="46" width="3.5" height="20" rx="1" />
            <rect x="49" y="46" width="3.2" height="20" rx="1" />
          </g>

          <!-- Scenic overlay text -->
          <text x="200" y="110" font-family="'Inter', sans-serif" font-size="28" font-weight="900" fill="#789A7E" letter-spacing="10" text-anchor="middle" opacity="0.8">WELCOME</text>
        </svg>

        <!-- Wavy Divider Mask that perfectly divides screen exactly like Sample 1 -->
        <svg class="scenery-wave" viewBox="0 0 100 100" preserveAspectRatio="none">
          <path d="M 100,0 C 70,25 90,50 65,75 C 50,90 60,100 100,100 Z" fill="#1E5652" />
        </svg>
      </div>

      <!-- RIGHT PANEL: Elegant Sign Up Form in deep emerald matching Sample 1 -->
      <div class="form-panel">
        <div class="form-scroll-container">
          <h2 class="welcome-hello">Hello!</h2>
          <p class="welcome-glad mb-6">We are glad to see you :)</p>

          <!-- OAuth Social Pill Buttons -->
          <div class="social-login-container mb-6">
            <a-button class="btn-social-google" shape="round">
              <v-icon icon="mdi-google" class="mr-2 google-icon"></v-icon>
              Sign up with Google
            </a-button>
            <a-button class="btn-social-circle" shape="circle">
              <v-icon icon="mdi-facebook"></v-icon>
            </a-button>
            <a-button class="btn-social-circle" shape="circle">
              <v-icon icon="mdi-twitter"></v-icon>
            </a-button>
          </div>

          <div class="divider-or mb-6">
            <span class="divider-line"></span>
            <span class="divider-text">Or</span>
            <span class="divider-line"></span>
          </div>

          <!-- Form fields using pill-shape inputs exactly like Sample 1 -->
          <a-form :model="formState" @finish="onFinish" layout="vertical">
            <div class="form-row">
              <div class="form-col">
                <a-form-item
                  label="Name"
                  name="fullName"
                  :rules="[{ required: true, message: 'Please input your name!' }]"
                >
                  <a-input v-model:value="formState.fullName" placeholder="Your Full Name" class="pill-input" />
                </a-form-item>
              </div>
              <div class="form-col">
                <a-form-item
                  label="Username"
                  name="username"
                  :rules="[{ required: true, message: 'Please input your username!' }]"
                >
                  <a-input v-model:value="formState.username" placeholder="Choose a username" class="pill-input" />
                </a-form-item>
              </div>
            </div>

            <div class="form-row">
              <div class="form-col">
                <a-form-item
                  label="Email Address"
                  name="email"
                  :rules="[
                    { required: true, message: 'Please input your email!' },
                    { type: 'email', message: 'Invalid email format!' }
                  ]"
                >
                  <a-input v-model:value="formState.email" placeholder="example@domain.com" class="pill-input" />
                </a-form-item>
              </div>
              <div class="form-col">
                <a-form-item
                  label="Password"
                  name="password"
                  :rules="[
                    { required: true, message: 'Vui lòng nhập mật khẩu!' },
                    { validator: validatePasswordStrength }
                  ]"
                >
                  <a-input-password v-model:value="formState.password" placeholder="xxxxxxxx" class="pill-input" />
                </a-form-item>
              </div>
            </div>

            <div class="form-row">
              <div class="form-col">
                <a-form-item
                  label="Repeat Password"
                  name="confirmPassword"
                  :rules="[
                    { required: true, message: 'Please repeat password!' },
                    { validator: validateConfirmPassword }
                  ]"
                >
                  <a-input-password v-model:value="formState.confirmPassword" placeholder="xxxxxxxx" class="pill-input" />
                </a-form-item>
              </div>
              <div class="form-col">
                <!-- Symmetrical empty placeholder column to align layout nicely -->
              </div>
            </div>

            <!-- Custom terms checkbox -->
            <div class="mb-6">
              <a-checkbox v-model:checked="formState.agree" class="terms-checkbox">
                I agree <a href="#" class="terms-link">Terms of Service</a> and <a href="#" class="terms-link">Privacy Policy</a>
              </a-checkbox>
            </div>

            <a-form-item class="mb-2">
              <a-button type="primary" html-type="submit" class="btn-signup-pill" :loading="loading" :disabled="!formState.agree">
                Sign Up
              </a-button>
            </a-form-item>
          </a-form>

          <div class="footer-links-signup mt-6">
            <span>Already have an account? </span>
            <a href="#" class="btn-signin-link" @click.prevent="$router.push('/login')">Sign In</a>
          </div>

          <div class="text-center mt-4">
            <a href="#" class="back-link" @click.prevent="$router.push('/')">
              <v-icon icon="mdi-arrow-left" class="mr-1"></v-icon> Back to home
            </a>
          </div>
        </div>
      </div>
    </div>

    <!-- Celebration Modal (Same 3D digital card as N3) -->
    <a-modal v-model:open="showSuccessModal" :footer="null" :closable="false" width="500px" centered>
      <div class="success-modal-content text-center py-6">
        <div class="success-icon-wrapper mb-4">
          <v-icon icon="mdi-check-circle" color="success" size="64"></v-icon>
        </div>
        <h3 class="success-title mb-2">Đăng Ký Thành Công!</h3>
        <p class="success-subtitle mb-6 text-grey-darken-1">Thẻ thư viện số đã tự động được kích hoạt cho tài khoản mới!</p>
        
        <!-- Virtual card -->
        <div class="virtual-card-wrapper mx-auto mb-8">
          <div class="virtual-card">
            <div class="card-bg-glow"></div>
            <div class="card-header d-flex justify-space-between align-center">
              <div class="card-brand d-flex align-center">
                <v-icon icon="mdi-library" color="white" class="mr-1"></v-icon>
                <span>SmartLib.NET</span>
              </div>
              <div class="card-type">DIGITAL CARD</div>
            </div>
            
            <div class="card-body my-6 text-left">
              <div class="card-label">MÃ THẺ THƯ VIỆN</div>
              <div class="card-number">{{ generatedCardNumber }}</div>
            </div>

            <div class="card-footer d-flex justify-space-between text-left">
              <div>
                <div class="card-label">HỌ VÀ TÊN</div>
                <div class="card-val">{{ formState.fullName }}</div>
              </div>
              <div class="text-right">
                <div class="card-label">HẠN SỬ DỤNG</div>
                <div class="card-val">{{ expiryDateString }}</div>
              </div>
            </div>
          </div>
        </div>

        <a-button type="primary" shape="round" class="btn-success-close" @click="closeModalAndRedirect">
          Vào Trang Đăng Nhập
        </a-button>
      </div>
    </a-modal>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref, computed } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'
import { message } from 'ant-design-vue'

const router = useRouter()
const loading = ref(false)
const showSuccessModal = ref(false)
const generatedCardNumber = ref('')

const formState = reactive({
  fullName: '',
  email: '',
  password: '',
  confirmPassword: '',
  username: '', // Default computed internally or mapped to email
  role: 'Reader', // Default role
  agree: false
})

const expiryDateString = computed(() => {
  const nextYear = new Date()
  nextYear.setFullYear(nextYear.getFullYear() + 1)
  return nextYear.toLocaleDateString('vi-VN')
})

const validatePasswordStrength = (_rule: any, value: string) => {
  if (!value) {
    return Promise.resolve()
  }
  
  const hasMinLength = value.length >= 6
  const hasUpperCase = /[A-Z]/.test(value)
  const hasLowerCase = /[a-z]/.test(value)
  const hasDigit = /[0-9]/.test(value)
  const hasSpecial = /[^A-Za-z0-9]/.test(value)
  
  if (!hasMinLength || !hasUpperCase || !hasLowerCase || !hasDigit || !hasSpecial) {
    return Promise.reject(
      new Error(
        'Mật khẩu phải gồm ít nhất: 6 ký tự, 1 chữ hoa, 1 chữ thường, 1 chữ số, và 1 ký tự đặc biệt (e.g. @, #, !, $).'
      )
    )
  }
  
  return Promise.resolve()
}

const validateConfirmPassword = (_rule: any, value: string) => {
  if (!value) {
    return Promise.resolve()
  }
  if (value !== formState.password) {
    return Promise.reject(new Error('Passwords do not match!'))
  }
  return Promise.resolve()
}

const onFinish = async (values: any) => {
  loading.value = true
  try {
    const response = await axios.post('http://localhost:5208/api/Auth/register', {
      Username: formState.username,
      Email: formState.email,
      Password: formState.password,
      FullName: formState.fullName,
      Role: formState.role
    })
    
    const data = response.data
    // Accept both camelCase and PascalCase from API Gateway
    generatedCardNumber.value = data.cardNumber || data.CardNumber || `LIB-${Math.floor(100000 + Math.random() * 900000)}`
    showSuccessModal.value = true
    message.success('Đăng ký tài khoản thành công!')
  } catch (error: any) {
    console.error('Register API Error:', error)
    const responseData = error.response?.data
    
    if (responseData?.Errors && Array.isArray(responseData.Errors)) {
      // Loop through all Microsoft Identity validation errors and display them
      responseData.Errors.forEach((err: any) => {
        message.error(err.Description || err.description || 'Lỗi đăng ký từ hệ thống!')
      })
    } else if (responseData?.errors && Array.isArray(responseData.errors)) {
      // Handle camelCase from JSON serializer
      responseData.errors.forEach((err: any) => {
        message.error(err.description || err.Description || 'Lỗi đăng ký từ hệ thống!')
      })
    } else {
      const errMessage = responseData?.Message || responseData?.message || 'Đăng ký thất bại. Vui lòng kiểm tra kết nối API!'
      message.error(errMessage)
    }
  } finally {
    loading.value = false
  }
}

const closeModalAndRedirect = () => {
  showSuccessModal.value = false
  router.push('/login')
}
</script>

<style scoped>
/* Scoped styles replicating Sample 1 exactly */
.auth-page-container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #FAF9F6;
  padding: 40px;
}

.split-container {
  display: flex;
  width: 100%;
  max-width: 960px;
  height: 600px;
  background: white;
  border-radius: 30px;
  box-shadow: 0 15px 40px rgba(0,0,0,0.06);
  overflow: hidden;
  position: relative;
}

/* LEFT PANEL (Nature Scenery) */
.scenery-panel {
  flex: 1.1;
  position: relative;
  height: 100%;
  background-color: #EBF3E8;
  overflow: hidden;
}

.nature-illustration {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

/* Wavy separator linking panels beautifully */
.scenery-wave {
  position: absolute;
  top: 0;
  right: -2px;
  bottom: 0;
  width: 120px;
  height: 100%;
  z-index: 10;
  pointer-events: none;
}

/* RIGHT PANEL (Sign Up Form) */
.form-panel {
  flex: 1.2;
  background-color: #1E5652; /* Deep emerald color scheme matching landing page */
  color: white;
  display: flex;
  flex-direction: column;
  justify-content: center;
  padding: 40px 60px;
  position: relative;
  z-index: 5;
}

.form-scroll-container {
  width: 100%;
  max-height: 100%;
  overflow-y: auto;
  padding-right: 5px;
}

/* Hide scrollbar for form scroll container */
.form-scroll-container::-webkit-scrollbar {
  width: 0px;
}

.welcome-hello {
  font-size: 38px;
  font-weight: 800;
  color: #FAF9F6;
  margin-bottom: 4px;
}

.welcome-glad {
  font-size: 16px;
  color: #BBE1DC;
}

/* Social Buttons */
.social-login-container {
  display: flex;
  align-items: center;
  gap: 12px;
}

.btn-social-google {
  background-color: rgba(255, 255, 255, 0.08) !important;
  border: 1px solid rgba(255, 255, 255, 0.2) !important;
  color: white !important;
  font-weight: 600 !important;
  font-size: 13px !important;
  padding: 0 24px !important;
  height: 40px !important;
  display: inline-flex;
  align-items: center;
}

.btn-social-google:hover {
  background-color: rgba(255, 255, 255, 0.15) !important;
}

.google-icon {
  color: #FAF9F6 !important;
  font-size: 18px !important;
}

.btn-social-circle {
  background-color: rgba(255, 255, 255, 0.08) !important;
  border: 1px solid rgba(255, 255, 255, 0.2) !important;
  color: white !important;
  width: 40px !important;
  height: 40px !important;
  min-width: 40px !important;
  display: inline-flex;
  align-items: center;
  justify-content: center;
}

.btn-social-circle:hover {
  background-color: rgba(255, 255, 255, 0.15) !important;
}

/* Text Divider */
.divider-or {
  display: flex;
  align-items: center;
  gap: 16px;
  color: #BBE1DC;
  font-size: 14px;
}

.divider-line {
  flex: 1;
  height: 1px;
  background-color: rgba(255, 255, 255, 0.15);
}

.divider-text {
  font-weight: 600;
}

/* Form inputs styling */
.form-row {
  display: flex;
  gap: 16px;
}

.form-col {
  flex: 1;
}

/* Pill Input overrides */
:deep(.pill-input) {
  background-color: rgba(255, 255, 255, 0.06) !important;
  border: 1.5px solid rgba(255, 255, 255, 0.15) !important;
  color: white !important;
  border-radius: 24px !important;
  padding: 8px 18px !important;
}

:deep(.pill-input-select) {
  width: 100% !important;
}

:deep(.pill-input-select .ant-select-selector) {
  background-color: rgba(255, 255, 255, 0.06) !important;
  border: 1.5px solid rgba(255, 255, 255, 0.15) !important;
  color: white !important;
  border-radius: 24px !important;
  height: 43px !important;
  padding: 6px 18px !important;
  box-shadow: none !important;
}

:deep(.pill-input-select .ant-select-selection-item) {
  color: white !important;
  font-weight: 600 !important;
  font-size: 14px !important;
}

:deep(.pill-input-select .ant-select-arrow) {
  color: rgba(255, 255, 255, 0.6) !important;
  right: 18px !important;
}

:deep(.pill-input-select:hover .ant-select-selector), 
:deep(.pill-input-select.ant-select-focused .ant-select-selector) {
  border-color: #BBE1DC !important;
}

:deep(.pill-input input), :deep(.pill-input .ant-input) {
  background: transparent !important;
  background-color: transparent !important;
  color: white !important;
  border: none !important;
  box-shadow: none !important;
}

:deep(.pill-input input::placeholder) {
  color: rgba(255, 255, 255, 0.4) !important;
}

:deep(.pill-input:hover), :deep(.pill-input:focus-within) {
  border-color: #BBE1DC !important;
  box-shadow: 0 0 0 2px rgba(187, 225, 220, 0.1) !important;
}

:deep(.ant-input-password-icon) {
  color: rgba(255,255,255,0.6) !important;
}

:deep(.ant-form-item-label > label) {
  color: #BBE1DC !important;
  font-weight: 700 !important;
  font-size: 13px !important;
  padding-bottom: 2px !important;
}

.terms-checkbox {
  color: #BBE1DC !important;
  font-size: 13px;
}

:deep(.ant-checkbox-wrapper:hover .ant-checkbox-inner),
:deep(.ant-checkbox-checked .ant-checkbox-inner) {
  border-color: #CF7C07 !important;
  background-color: #CF7C07 !important;
}

.terms-link {
  color: #FAF9F6;
  font-weight: 700;
  text-decoration: underline;
}

/* Pill Signup Button */
.btn-signup-pill {
  width: 100%;
  height: 46px !important;
  border-radius: 24px !important;
  background-color: #BBE1DC !important; /* Soft mint/teal light color from Sample 1 */
  border-color: #BBE1DC !important;
  color: #1E5652 !important; /* Dark text matching background */
  font-weight: 800 !important;
  font-size: 15px !important;
  box-shadow: 0 6px 15px rgba(0,0,0,0.15) !important;
  transition: transform 0.2s, background-color 0.3s !important;
}

.btn-signup-pill:hover {
  background-color: #FAF9F6 !important;
  transform: translateY(-1px);
}

.btn-signup-pill:disabled {
  background-color: rgba(255, 255, 255, 0.1) !important;
  border-color: rgba(255, 255, 255, 0.05) !important;
  color: rgba(255, 255, 255, 0.3) !important;
}

.footer-links-signup {
  text-align: center;
  font-size: 13px;
  color: #BBE1DC;
}

.btn-signin-link {
  color: white;
  font-weight: 800;
  text-decoration: underline;
}

.back-link {
  color: #BBE1DC;
  text-decoration: none;
  font-size: 13px;
  font-weight: 600;
  transition: color 0.3s;
  display: block;
}

.back-link:hover {
  color: white;
}

/* Celebration Modal & Thẻ Số Đồ Họa */
.success-modal-content {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.success-icon-wrapper {
  animation: scaleUp 0.5s cubic-bezier(0.175, 0.885, 0.32, 1.275);
}

.success-title {
  font-size: 24px;
  font-weight: 800;
  color: #114B44;
}

.virtual-card-wrapper {
  perspective: 1000px;
  width: 100%;
  max-width: 360px;
}

.virtual-card {
  position: relative;
  background: linear-gradient(135deg, #114B44 0%, #1E5652 100%);
  color: white;
  border-radius: 16px;
  padding: 24px;
  box-shadow: 0 15px 30px rgba(30, 86, 82, 0.3);
  overflow: hidden;
  border: 1px solid rgba(255,255,255,0.1);
  transform: rotateX(5deg);
  transform-style: preserve-3d;
}

.card-bg-glow {
  position: absolute;
  top: -50%;
  right: -50%;
  width: 150%;
  height: 150%;
  background: radial-gradient(circle, rgba(207,124,7,0.15) 0%, rgba(255,255,255,0) 70%);
  z-index: 1;
}

.card-brand span {
  font-weight: 800;
  letter-spacing: 0.5px;
  font-size: 14px;
}

.card-type {
  font-size: 10px;
  font-weight: 700;
  letter-spacing: 1.5px;
  background-color: rgba(255,255,255,0.15);
  padding: 2px 8px;
  border-radius: 4px;
}

.card-label {
  font-size: 9px;
  color: #CBE0DE;
  font-weight: 700;
  letter-spacing: 1px;
  margin-bottom: 4px;
}

.card-number {
  font-size: 28px;
  font-weight: 800;
  font-family: 'Courier New', Courier, monospace;
  letter-spacing: 2px;
  position: relative;
  z-index: 2;
  text-shadow: 0 2px 4px rgba(0,0,0,0.2);
}

.card-val {
  font-size: 14px;
  font-weight: 700;
  letter-spacing: 0.5px;
}

.btn-success-close {
  background-color: #CF7C07 !important;
  border-color: #CF7C07 !important;
  color: white !important;
  font-weight: 700 !important;
  padding: 10px 32px !important;
  height: 44px !important;
  box-shadow: 0 4px 15px rgba(207, 124, 7, 0.3);
}

@keyframes scaleUp {
  0% { transform: scale(0.5); opacity: 0; }
  100% { transform: scale(1); opacity: 1; }
}

@media (max-width: 850px) {
  .split-container {
    flex-direction: column;
    height: auto;
    max-width: 460px;
  }
  .scenery-panel {
    display: none;
  }
  .form-panel {
    padding: 40px 30px;
  }
}
</style>
