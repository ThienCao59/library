<template>
  <div class="reviews-page-container">
    <!-- Navbar -->
    <header class="navbar">
      <div class="logo" @click="$router.push('/')">
        <v-icon icon="mdi-library" class="mr-2 logo-icon"></v-icon>
        <span class="logo-text">SmartLib.NET</span>
      </div>
      <nav class="nav-links">
        <a href="#" @click.prevent="$router.push('/')">HOME</a>
        <a href="#" @click.prevent="$router.push('/features')">FEATURES</a>
        <a href="#" @click.prevent="$router.push('/statistics')">STATISTICS</a>
        <a href="#" class="active" @click.prevent="$router.push('/reviews')">REVIEWS</a>
      </nav>
      <div class="nav-auth">
        <a-button type="text" class="btn-login mr-2" @click="$router.push('/login')">Sign in</a-button>
        <a-button type="primary" shape="round" class="btn-register" @click="$router.push('/register')">Sign up</a-button>
      </div>
    </header>

    <!-- Header Section -->
    <div class="reviews-hero">
      <div class="hero-glow"></div>
      <div class="reviews-hero-content text-center">
        <span class="badge-tag">ĐỘC GIẢ NÓI GÌ</span>
        <h1 class="reviews-title">Đánh Giá Từ Cộng Đồng</h1>
        <p class="reviews-subtitle">
          Những trải nghiệm và chia sẻ thực tế nhất của các bạn học viên, giảng viên và thủ thư khi tham gia thư viện.
        </p>
      </div>
    </div>

    <!-- Review Masonry and Submission form container -->
    <div class="reviews-body-section">
      <div class="reviews-split-grid">
        <!-- LEFT PANEL: Dynamic Reactive Review Grid -->
        <div class="reviews-list-col">
          <h2 class="list-section-title mb-6">Độc Giả Chia Sẻ</h2>
          
          <div class="review-cards-wrapper">
            <!-- Loop through reviews with high visual fidelity -->
            <div v-for="(review, index) in reviewsList" :key="index" class="review-comment-card">
              <div class="review-card-header d-flex justify-space-between align-center mb-4">
                <div class="d-flex align-center gap-3">
                  <div class="avatar-bubble" :style="{ backgroundColor: review.avatarColor }">
                    {{ review.name.charAt(0).toUpperCase() }}
                  </div>
                  <div>
                    <h4 class="reviewer-name">{{ review.name }}</h4>
                    <span class="reviewer-role">{{ review.role }}</span>
                  </div>
                </div>
                <div class="stars-row">
                  <v-icon 
                    v-for="star in 5" 
                    :key="star" 
                    :icon="star <= review.rating ? 'mdi-star' : 'mdi-star-outline'" 
                    class="gold-star"
                  ></v-icon>
                </div>
              </div>
              <p class="review-text">"{{ review.text }}"</p>
              <span class="review-date-tag">{{ review.date }}</span>
            </div>
          </div>
        </div>

        <!-- RIGHT PANEL: Beautiful Interactive Submit Review Form -->
        <div class="submit-review-col">
          <div class="sticky-form-box">
            <h3 class="form-card-title mb-4">Gửi Đánh Giá Của Bạn</h3>
            <p class="form-card-desc mb-6 text-grey text-sm">Chia sẻ cảm nhận của bạn để giúp chúng tôi ngày càng cải thiện dịch vụ tốt hơn.</p>

            <a-form :model="formState" @finish="onFormSubmit" layout="vertical">
              <a-form-item
                label="Họ và Tên"
                name="name"
                :rules="[{ required: true, message: 'Vui lòng điền họ tên!' }]"
              >
                <a-input v-model:value="formState.name" placeholder="Họ và tên của bạn" class="pill-input-light" />
              </a-form-item>

              <a-form-item
                label="Vai Trò / Nghề Nghiệp"
                name="role"
                :rules="[{ required: true, message: 'Vui lòng điền vai trò của bạn!' }]"
              >
                <a-input v-model:value="formState.role" placeholder="Ví dụ: Sinh viên CNTT, Giảng viên..." class="pill-input-light" />
              </a-form-item>

              <!-- Star Rating selection tool -->
              <div class="form-star-select mb-6">
                <span class="d-block text-xs font-weight-bold text-grey-darken-2 mb-2">Đánh Giá Số Sao:</span>
                <div class="stars-selector-row">
                  <v-icon 
                    v-for="star in 5" 
                    :key="star" 
                    :icon="star <= selectedStars ? 'mdi-star' : 'mdi-star-outline'" 
                    class="stars-selector-btn"
                    :class="{ selected: star <= selectedStars }"
                    @click="selectedStars = star"
                  ></v-icon>
                  <span class="stars-desc ml-3 font-weight-bold">{{ starsText[selectedStars - 1] }}</span>
                </div>
              </div>

              <a-form-item
                label="Nội dung nhận xét"
                name="text"
                :rules="[{ required: true, message: 'Vui lòng điền nội dung nhận xét!' }]"
              >
                <a-textarea v-model:value="formState.text" placeholder="Cảm nghĩ của bạn về thư viện số thông minh..." class="textarea-input-light" :rows="4" />
              </a-form-item>

              <a-button type="primary" html-type="submit" class="btn-submit-review mt-2" :loading="submitLoading">
                Gửi Đánh Giá Ngay
              </a-button>
            </a-form>
          </div>
        </div>
      </div>
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
import { reactive, ref } from 'vue'
import { message } from 'ant-design-vue'

// Initial beautiful reviews list
const reviewsList = ref([
  {
    name: 'Nguyễn Tiến Dũng',
    role: 'Sinh viên năm 3 CNTT',
    avatarColor: '#1E5652',
    rating: 5,
    text: 'Quá bất ngờ với tốc độ cấp thẻ thư viện trực tuyến! Chỉ tốn đúng 3 giây là có ngay một chiếc thẻ số vô cùng sang xịn với mã QR để đi quét mượn sách. Giao diện mượt mà và cực kỳ hiện đại.',
    date: '10/05/2026'
  },
  {
    name: 'ThS. Nguyễn Thị Mai',
    role: 'Giảng viên Đại học',
    avatarColor: '#CF7C07',
    rating: 5,
    text: 'Một giải pháp thư viện tuyệt vời cho trường đại học. Việc phân quyền vai trò độc giả, thủ thư rõ ràng giúp việc quản lý và phê duyệt sách diễn ra cực kỳ chuẩn xác và minh bạch.',
    date: '14/05/2026'
  },
  {
    name: 'Trần Minh Hải',
    role: 'Lập trình viên & Thủ thư',
    avatarColor: '#533527',
    rating: 4,
    text: 'Với tư cách là một lập trình viên, tôi đánh giá cực kỳ cao kiến trúc Microservices và Ocelot API Gateway của hệ thống này. Backend chạy vô cùng mượt mà đi kèm log Serilog chi tiết.',
    date: '16/05/2026'
  }
])

// Form state
const formState = reactive({
  name: '',
  role: '',
  text: ''
})

const selectedStars = ref(5)
const submitLoading = ref(false)

const starsText = [
  'Rất tệ 😞',
  'Tạm được 😐',
  'Khá tốt 🙂',
  'Tuyệt vời 😍',
  'Xuất sắc vượt trội! 🏆'
]

// Form submission handler
const onFormSubmit = () => {
  submitLoading.value = true
  
  setTimeout(() => {
    // Generate a random avatar color for the new reviewer
    const colors = ['#277D78', '#CF7C07', '#533527', '#D35230', '#1E5652', '#84A98C']
    const randomColor = colors[Math.floor(Math.random() * colors.length)] ?? '#1E5652'
    
    // Add to list
    reviewsList.value.unshift({
      name: formState.name,
      role: formState.role,
      avatarColor: randomColor,
      rating: selectedStars.value,
      text: formState.text,
      date: new Date().toLocaleDateString('vi-VN')
    })
    
    // Reset Form
    formState.name = ''
    formState.role = ''
    formState.text = ''
    selectedStars.value = 5
    submitLoading.value = false
    
    message.success('Cảm ơn đóng góp của bạn! Đánh giá đã được đăng thành công.')
  }, 1000)
}
</script>

<style scoped>
.reviews-page-container {
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

/* Reviews Hero Subheader */
.reviews-hero {
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

.reviews-hero-content {
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

.reviews-title {
  font-size: 56px;
  font-weight: 800;
  font-family: 'Outfit', sans-serif;
  line-height: 1.1;
  margin-bottom: 20px;
  background: linear-gradient(135deg, #FAF9F6 0%, #DCEAD5 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
}

.reviews-subtitle {
  font-size: 18px;
  color: #CBE0DE;
  line-height: 1.6;
  max-width: 600px;
  margin: 0 auto;
}

/* Main content */
.reviews-body-section {
  max-width: 1100px;
  margin: 60px auto 80px auto;
  padding: 0 40px;
}

.reviews-split-grid {
  display: grid;
  grid-template-columns: 1.4fr 1fr;
  gap: 50px;
  align-items: start;
}

.list-section-title {
  font-size: 24px;
  font-weight: 800;
  color: #114B44;
  position: relative;
  padding-left: 12px;
}

.list-section-title::before {
  content: '';
  position: absolute;
  left: 0;
  top: 4px;
  bottom: 4px;
  width: 4px;
  background-color: #CF7C07;
  border-radius: 2px;
}

/* Review Cards wrapper */
.review-cards-wrapper {
  display: flex;
  flex-direction: column;
  gap: 20px;
}

.review-comment-card {
  background-color: white;
  border-radius: 16px;
  padding: 24px;
  box-shadow: 0 15px 35px rgba(0,0,0,0.03);
  border: 1px solid rgba(0,0,0,0.02);
  transition: transform 0.3s;
}

.review-comment-card:hover {
  transform: translateY(-2px);
}

.avatar-bubble {
  width: 44px;
  height: 44px;
  border-radius: 50%;
  display: flex;
  justify-content: center;
  align-items: center;
  color: white;
  font-weight: 800;
  font-size: 16px;
  box-shadow: 0 4px 10px rgba(0,0,0,0.1);
}

.reviewer-name {
  font-size: 15px;
  font-weight: 800;
  color: #114B44;
  margin: 0;
}

.reviewer-role {
  font-size: 11px;
  color: #7A8583;
  font-weight: 700;
}

.gold-star {
  color: #CF7C07 !important;
  font-size: 16px !important;
}

.review-text {
  font-size: 14px;
  color: #434D4B;
  line-height: 1.6;
  font-style: italic;
}

.review-date-tag {
  font-size: 11px;
  color: #A5B0AE;
  font-weight: 700;
}

/* Submit Form styling */
.sticky-form-box {
  background-color: white;
  border-radius: 20px;
  padding: 32px;
  box-shadow: 0 15px 35px rgba(0,0,0,0.03);
  border: 1px solid rgba(0,0,0,0.02);
  position: sticky;
  top: 120px;
}

.form-card-title {
  font-size: 20px;
  font-weight: 800;
  color: #114B44;
}

/* Form controls overrides */
.pill-input-light {
  border-radius: 20px !important;
  background-color: #FAF9F6 !important;
  border: 1.5px solid rgba(0,0,0,0.05) !important;
  padding: 8px 16px !important;
  font-size: 13px !important;
}

.textarea-input-light {
  border-radius: 12px !important;
  background-color: #FAF9F6 !important;
  border: 1.5px solid rgba(0,0,0,0.05) !important;
  padding: 10px 16px !important;
  font-size: 13px !important;
}

:deep(.ant-form-item-label > label) {
  font-weight: 700 !important;
  font-size: 12px !important;
  color: #5C6765 !important;
}

/* Stars Selector row */
.stars-selector-row {
  display: flex;
  align-items: center;
  gap: 6px;
}

.stars-selector-btn {
  color: #CDD5D3 !important;
  font-size: 26px !important;
  cursor: pointer;
  transition: transform 0.2s, color 0.2s;
}

.stars-selector-btn.selected, .stars-selector-btn:hover {
  color: #CF7C07 !important;
  transform: scale(1.15);
}

.stars-desc {
  font-size: 12px;
  color: #CF7C07;
}

/* Submit Review Button */
.btn-submit-review {
  width: 100%;
  height: 44px !important;
  border-radius: 24px !important;
  background-color: #1E5652 !important;
  border-color: #1E5652 !important;
  color: white !important;
  font-weight: 800 !important;
  font-size: 14px !important;
  box-shadow: 0 6px 15px rgba(30, 86, 82, 0.2) !important;
  transition: all 0.2s !important;
}

.btn-submit-review:hover {
  background-color: #153E3B !important;
  transform: translateY(-1px);
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
  .reviews-split-grid {
    grid-template-columns: 1fr;
    gap: 40px;
  }
  .navbar {
    padding: 16px 30px;
  }
}
</style>
