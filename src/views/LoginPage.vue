<template>
  <div class="auth-page-container">
    <div class="split-container login-style">
      <!-- LEFT PANEL: Cozy Reading Tree & Abstract Bubbles SVG matching Sample 2 -->
      <div class="scenery-panel-left">
        <svg class="reading-illustration" viewBox="0 0 400 500" preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg">
          <!-- Soft Background -->
          <rect width="400" height="500" fill="#FAF9F6" />
          
          <!-- Abstract Background Bubbles exactly like Sample 2 -->
          <circle cx="80" cy="120" r="40" fill="#E6EADF" opacity="0.6" />
          <circle cx="160" cy="80" r="20" fill="#DCE2D5" opacity="0.5" />
          <circle cx="340" cy="180" r="30" fill="#FAF9F6" opacity="0.8" />
          
          <!-- Beautiful Abstract Wavy Bubble Mask that bounds the illustration -->
          <path d="M 50 180 C 20 220 30 280 80 320 C 130 360 280 380 300 300 C 330 200 240 120 180 140 C 120 160 80 140 50 180 Z" fill="#E2ECE9" opacity="0.9" />

          <!-- Cozy Reading Tree with hanging glowing baubles (replicates Christmas tree vibe) -->
          <g transform="translate(140, 160)">
            <!-- Trunk -->
            <path d="M 55 120 Q 60 180 60 210 L 50 210 Q 50 180 45 120 Z" fill="#533527" />
            <!-- Branches & Leaves -->
            <!-- Layer 3 (Bottom) -->
            <path d="M 10 150 Q 55 90 100 150 L 85 155 Q 55 110 25 155 Z" fill="#1E5652" />
            <path d="M 0 160 Q 55 80 110 160 C 95 140 15 140 0 160 Z" fill="#153E3B" />
            <!-- Layer 2 (Middle) -->
            <path d="M 20 110 Q 55 60 90 110 L 80 115 Q 55 80 30 115 Z" fill="#277D78" />
            <path d="M 15 120 Q 55 50 95 120 C 85 105 25 105 15 120 Z" fill="#1E5652" />
            <!-- Layer 1 (Top) -->
            <polygon points="55,20 25,80 85,80" fill="#2A7973" />
            <polygon points="55,30 35,70 75,70" fill="#359A92" />
            
            <!-- Glowing Yellow Star on top -->
            <polygon points="55,5 58,14 67,14 60,20 62,29 55,23 48,29 50,20 43,14 52,14" fill="#F5B041" />

            <!-- Hanging Baubles / Light Orbs -->
            <circle cx="40" cy="70" r="5" fill="#D35230" />
            <circle cx="70" cy="75" r="5" fill="#CF7C07" />
            <circle cx="30" cy="115" r="6" fill="#FAF9F6" />
            <circle cx="80" cy="110" r="6" fill="#D35230" />
            <circle cx="50" cy="95" r="5" fill="#FAF9F6" />
            <circle cx="20" cy="145" r="6" fill="#CF7C07" />
            <circle cx="90" cy="140" r="6" fill="#FAF9F6" />
            <circle cx="55" cy="135" r="5" fill="#D35230" />
          </g>

          <!-- Little silhouette reading books under the tree (customized reader vibe) -->
          <g transform="translate(130, 310) scale(0.7)">
            <!-- Reader Sitting -->
            <circle cx="30" cy="20" r="6" fill="#1E332E" />
            <path d="M 30 26 C 25 26 15 32 15 42 L 32 42 L 35 48 L 45 48 L 38 35 Z" fill="#1E332E" />
            <!-- Book in hand -->
            <path d="M 36 34 L 44 32 L 48 35 L 40 37 Z" fill="#CF7C07" />
          </g>
          <g transform="translate(230, 320) scale(0.65)">
            <!-- Little child looking at tree -->
            <circle cx="30" cy="20" r="6" fill="#1E332E" />
            <path d="M 30 26 C 28 26 22 30 22 45 L 38 45 L 36 30 Z" fill="#1E332E" />
          </g>

          <!-- Flying Snow / Magic Dots -->
          <circle cx="160" cy="220" r="3" fill="white" opacity="0.8" />
          <circle cx="250" cy="240" r="2.5" fill="white" opacity="0.8" />
          <circle cx="190" cy="300" r="3.5" fill="white" opacity="0.7" />
          <circle cx="270" cy="290" r="2" fill="white" opacity="0.8" />

          <!-- Tiny Library Logo at Top Left -->
          <g transform="translate(30, 30)">
            <rect x="0" y="0" width="36" height="36" rx="8" fill="#1E5652" />
            <path d="M 12 12 H 24 V 24 H 12 Z" fill="none" stroke="white" stroke-width="2" />
            <path d="M 12 18 H 24" stroke="white" stroke-width="2" />
            <path d="M 18 12 V 24" stroke="white" stroke-width="2" />
          </g>
          <text x="75" y="45" font-family="'Inter', sans-serif" font-size="14" font-weight="800" fill="#1E5652">SmartLib.NET</text>

          <!-- Bottom Scenery Copyright info exactly like Sample 2 -->
          <text x="30" y="460" font-family="sans-serif" font-size="9" fill="#7A8583">© 2026 SmartLib.NET System</text>
          <text x="30" y="475" font-family="sans-serif" font-size="9" fill="#9AA6A4">Powered by Group 3 Services</text>
        </svg>

        <!-- Wavy Divider Mask that perfectly divides screen exactly like Sample 2 -->
        <svg class="scenery-wave-left" viewBox="0 0 100 100" preserveAspectRatio="none">
          <path d="M 0,0 Q 30,30 10,50 T 40,75 T 0,100 Z" fill="#FAF9F6" />
        </svg>
      </div>

      <!-- RIGHT PANEL: Elegant Sign In Form exactly like Sample 2 -->
      <div class="form-panel-right">
        <div class="form-content-wrapper">
          <h2 class="auth-title-login">Login</h2>

          <a-form :model="formState" @finish="onFinish" layout="vertical">
            <a-form-item
              label="Username"
              name="username"
              :rules="[{ required: true, message: 'Please enter your username!' }]"
            >
              <a-input v-model:value="formState.username" placeholder="Enter your username" class="pill-input" />
            </a-form-item>

            <a-form-item
              label="Password"
              name="password"
              :rules="[{ required: true, message: 'Please enter your password!' }]"
              class="mb-2"
            >
              <a-input-password v-model:value="formState.password" placeholder="Enter your password" class="pill-input" />
            </a-form-item>

            <div class="text-right mb-6">
              <a href="#" class="forgot-password-link" @click.prevent="$router.push('/forgot-password')">Forgot Password?</a>
            </div>

            <a-form-item>
              <a-button type="primary" html-type="submit" class="btn-login-pill" :loading="loading">
                Login to System
              </a-button>
            </a-form-item>
          </a-form>

          <div class="footer-links-signin mt-6">
            <span>Don't have an account? </span>
            <a href="#" class="btn-register-link" @click.prevent="$router.push('/register')">Register Now</a>
          </div>

          <div class="text-center mt-6">
            <a href="#" class="back-link-login" @click.prevent="$router.push('/')">
              <v-icon icon="mdi-arrow-left" class="mr-1"></v-icon> Back to home
            </a>
          </div>



          <div class="contact-us-footer mt-8 text-center">
            <span>Have a problem? Contact us at </span>
            <a href="mailto:support@smartlib.net" class="support-email">support@smartlib.net</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue'
import { message } from 'ant-design-vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

const router = useRouter()
const loading = ref(false)

const formState = reactive({
  username: '',
  password: '',
})



const onFinish = async (values: any) => {
  loading.value = true
  try {
    const response = await axios.post('http://localhost:5208/api/Auth/login', {
      Username: formState.username,
      Password: formState.password
    })

    const data = response.data
    
    // Save token and profile information into localStorage
    localStorage.setItem('accessToken', data.accessToken || data.AccessToken || '')
    localStorage.setItem('refreshToken', data.refreshToken || data.RefreshToken || '')
    localStorage.setItem('username', data.username || data.Username || '')
    localStorage.setItem('email', data.email || data.Email || '')
    const userRole = data.role || data.Role || ''
    localStorage.setItem('role', userRole)

    message.success('Đăng nhập thành công! Chào mừng quay trở lại.')
    
    if (userRole === 'Admin' || userRole === 'Librarian') {
      router.push('/dashboard')
    } else {
      router.push('/')
    }
  } catch (error: any) {
    console.error('Login API Error:', error)
    const errMessage = error.response?.data?.Message || error.response?.data?.message || 'Đăng nhập thất bại. Sai tài khoản hoặc mật khẩu!'
    message.error(errMessage)
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
/* Scoped styles replicating Sample 2 exactly */
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

/* LEFT PANEL (Abstract Bubble Scenery) */
.scenery-panel-left {
  flex: 1.1;
  position: relative;
  height: 100%;
  background-color: #FAF9F6;
  overflow: hidden;
  border-right: 1px solid rgba(0,0,0,0.02);
}

.reading-illustration {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

/* Wavy separator linking panels beautifully */
.scenery-wave-left {
  position: absolute;
  top: 0;
  right: -2px;
  bottom: 0;
  width: 100px;
  height: 100%;
  z-index: 10;
  pointer-events: none;
}

/* RIGHT PANEL (Login Form) */
.form-panel-right {
  flex: 1;
  background-color: #1E5652; /* Deep emerald color scheme matching landing page */
  color: white;
  display: flex;
  flex-direction: column;
  justify-content: center;
  padding: 40px 60px;
  position: relative;
  z-index: 5;
}

.form-content-wrapper {
  width: 100%;
}

.auth-title-login {
  font-size: 38px;
  font-weight: 800;
  color: #FAF9F6;
  margin-bottom: 24px;
  font-family: 'Outfit', sans-serif;
  letter-spacing: 0.5px;
}

/* Pill Input overrides */
:deep(.pill-input) {
  background-color: rgba(255, 255, 255, 0.06) !important;
  border: 1.5px solid rgba(255, 255, 255, 0.15) !important;
  color: white !important;
  border-radius: 24px !important;
  padding: 8px 18px !important;
}

:deep(.pill-input input), :deep(.pill-input .ant-input) {
  background: transparent !important;
  background-color: transparent !important;
  color: white !important;
  border: none !important;
  box-shadow: none !important;
}

:deep(.pill-input input::placeholder) {
  color: rgba(255, 255, 255, 0.35) !important;
}

:deep(.pill-input:hover), :deep(.pill-input:focus-within) {
  border-color: #BBE1DC !important;
  box-shadow: 0 0 0 2px rgba(187, 225, 220, 0.1) !important;
}

/* Force autofill background to match deep emerald theme instead of default browser white */
:deep(input:-webkit-autofill),
:deep(input:-webkit-autofill:hover), 
:deep(input:-webkit-autofill:focus), 
:deep(input:-webkit-autofill:active) {
  -webkit-box-shadow: 0 0 0 1000px #1E5652 inset !important;
  -webkit-text-fill-color: white !important;
  transition: background-color 5000s ease-in-out 0s;
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

.forgot-password-link {
  color: #BBE1DC;
  font-size: 12px;
  text-decoration: underline;
  transition: color 0.3s;
}

.forgot-password-link:hover {
  color: white;
}

/* Pill Login Button */
.btn-login-pill {
  width: 100%;
  height: 46px !important;
  border-radius: 24px !important;
  background-color: #FAF9F6 !important; /* Elegant light warm background from Sample 2 */
  border-color: #FAF9F6 !important;
  color: #1E5652 !important; /* Dark text matching background */
  font-weight: 800 !important;
  font-size: 15px !important;
  box-shadow: 0 6px 15px rgba(0,0,0,0.15) !important;
  transition: transform 0.2s, background-color 0.3s !important;
}

.btn-login-pill:hover {
  background-color: #EBF3E8 !important;
  transform: translateY(-1px);
}

.footer-links-signin {
  text-align: center;
  font-size: 13px;
  color: #BBE1DC;
}

.btn-register-link {
  color: white;
  font-weight: 800;
  text-decoration: underline;
}

.back-link-login {
  color: #BBE1DC;
  text-decoration: none;
  font-size: 13px;
  font-weight: 600;
  transition: color 0.3s;
  display: inline-block;
}

.back-link-login:hover {
  color: white;
}

.contact-us-footer {
  font-size: 11px;
  color: rgba(255, 255, 255, 0.4);
}

.support-email {
  color: rgba(255, 255, 255, 0.6);
  text-decoration: underline;
}

.support-email:hover {
  color: white;
}

@media (max-width: 850px) {
  .split-container {
    flex-direction: column;
    height: auto;
    max-width: 460px;
  }
  .scenery-panel-left {
    display: none;
  }
  .form-panel-right {
    padding: 40px 30px;
  }
}

</style>
