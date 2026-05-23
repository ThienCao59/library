<template>
  <div class="landing-container">
    <!-- 1. Thanh điều hướng (Header Navigation) -->
    <header class="navbar">
      <div class="logo">
        <v-icon icon="mdi-library" class="mr-2 logo-icon"></v-icon>
        <span class="logo-text">SmartLib.NET</span>
      </div>
      <nav class="nav-links">
        <a href="#" class="active" @click.prevent="$router.push('/')">HOME</a>
        <a href="#" @click.prevent="$router.push('/features')">FEATURES</a>
        <a href="#" @click.prevent="$router.push('/statistics')">STATISTICS</a>
        <a href="#" @click.prevent="$router.push('/reviews')">REVIEWS</a>
      </nav>
      <div class="nav-auth">
        <a-button type="text" class="btn-login mr-2" @click="$router.push('/login')">Sign in</a-button>
        <a-button type="primary" shape="round" class="btn-register" @click="$router.push('/register')">Sign up</a-button>
      </div>
    </header>

    <!-- 2. Khu vực Chào mừng (Hero Section - Trọng tâm) -->
    <main class="hero-section">
      <div class="hero-left">
        <h1 class="hero-title">Online library</h1>
        <p class="hero-description">
          Thư viện Số Thông minh thế hệ mới - Mở cánh cửa tri thức, kiến tạo tương lai. 
          Hệ thống cấp thẻ thư viện trực tuyến tự động chỉ trong 3 giây, hỗ trợ tìm kiếm sách 
          và quản lý thông tin mượn trả tiện lợi thông qua API Gateway hiện đại.
        </p>
        <button class="btn-learn-more" @click="$router.push('/register')">
          Cấp thẻ trực tuyến
        </button>
      </div>

      <!-- Wavy separator and bookshelf graphic -->
      <div class="hero-right">
        <!-- SVG wave masking for fluid border exactly like user image -->
        <svg class="wave-separator" viewBox="0 0 100 100" preserveAspectRatio="none">
          <path d="M0,0 H100 C70,12 95,25 50,38 C95,50 65,65 85,78 C55,88 75,100 0,100 Z" fill="#FAF9F6" />
        </svg>
        
        <!-- Bookshelf representation -->
        <div class="bookshelf-container">
          <div class="shelf" v-for="shelfIndex in 3" :key="shelfIndex">
            <div class="shelf-wood"></div>
            <div class="books-container">
              <div 
                v-for="(book, index) in getBooksForShelf(shelfIndex)" 
                :key="index"
                class="book"
                :class="[book.color, book.height, book.leaning ? 'leaning' : '']"
                :style="book.leaning ? `transform: rotate(${book.angle}deg)` : ''"
              >
                <div class="book-spine">
                  <div class="book-title">{{ book.title }}</div>
                  <div class="spine-lines"></div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>

    <!-- 3. Giới thiệu Tính năng nổi bật (Features Section) -->
    <section id="features" class="features-section py-16 px-8">
      <h2 class="section-title text-center mb-12">Hệ Thống Tính Năng Vượt Trội</h2>
      <v-container>
        <v-row>
          <v-col cols="12" md="4">
            <v-card class="feature-card mx-auto pa-6 text-center elevation-3">
              <div class="feature-icon-wrapper mb-4">
                <v-icon icon="mdi-card-account-details-outline" size="x-large" color="primary"></v-icon>
              </div>
              <h3 class="feature-name mb-3">Thẻ Thư Viện Thông Minh</h3>
              <p class="feature-desc">
                Đăng ký tài khoản nhận ngay thẻ số trực tuyến sau 3 giây. Hỗ trợ độc giả tự theo dõi thời hạn, khóa/mở khóa hoặc gia hạn thẻ ngay trên hệ thống.
              </p>
              <div class="feature-badge mt-4">Nhóm 3 Services</div>
            </v-card>
          </v-col>

          <v-col cols="12" md="4">
            <v-card class="feature-card mx-auto pa-6 text-center elevation-3">
              <div class="feature-icon-wrapper mb-4">
                <v-icon icon="mdi-book-open-page-variant-outline" size="x-large" color="primary"></v-icon>
              </div>
              <h3 class="feature-name mb-3">Tra Cứu Sách Tức Thì</h3>
              <p class="feature-desc">
                Kho sách số khổng lồ được catalog chi tiết. Tìm kiếm sách thông minh theo tên, tác giả, thể loại hay từ khóa chỉ trong nháy mắt.
              </p>
              <div class="feature-badge mt-4">Nhóm 1 Services</div>
            </v-card>
          </v-col>

          <v-col cols="12" md="4">
            <v-card class="feature-card mx-auto pa-6 text-center elevation-3">
              <div class="feature-icon-wrapper mb-4">
                <v-icon icon="mdi-swap-horizontal" size="x-large" color="primary"></v-icon>
              </div>
              <h3 class="feature-name mb-3">Mượn Trả Siêu Tốc</h3>
              <p class="feature-desc">
                Đặt mượn sách trước trực tuyến mọi lúc mọi nơi. Nhận sách nhanh gọn tại quầy thông qua API đồng bộ cực kỳ mượt mà.
              </p>
              <div class="feature-badge mt-4">Nhóm 2 Services</div>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </section>

    <!-- 4. Các con số ấn tượng (Statistics Counter Section) -->
    <section id="stats" class="stats-section py-16 px-8 text-white">
      <v-container>
        <v-row class="text-center">
          <v-col cols="6" md="3">
            <div class="stat-item">
              <div class="stat-number">10,000+</div>
              <div class="stat-label">Cuốn sách phong phú</div>
            </div>
          </v-col>
          <v-col cols="6" md="3">
            <div class="stat-item">
              <div class="stat-number">5,000+</div>
              <div class="stat-label">Độc giả tin dùng</div>
            </div>
          </v-col>
          <v-col cols="6" md="3">
            <div class="stat-item">
              <div class="stat-number">200,000+</div>
              <div class="stat-label">Lượt mượn sách thành công</div>
            </div>
          </v-col>
          <v-col cols="6" md="3">
            <div class="stat-item">
              <div class="stat-number">99%</div>
              <div class="stat-label">Độc giả hài lòng</div>
            </div>
          </v-col>
        </v-row>
      </v-container>
    </section>

    <!-- 5. Đánh giá của Độc giả (Testimonial Section) -->
    <section id="testimonials" class="testimonials-section py-16 px-8 bg-light">
      <h2 class="section-title text-center mb-12">Độc Giả Nói Gì Về Chúng Tôi?</h2>
      <div class="carousel-wrapper mx-auto" style="max-width: 800px;">
        <a-carousel autoplay>
          <div class="testimonial-slide pa-8 text-center">
            <v-avatar size="80" class="mb-4 elevation-2">
              <v-img src="https://api.dicebear.com/7.x/adventurer/svg?seed=Felix"></v-img>
            </v-avatar>
            <p class="testimonial-text mb-6">
              "Thật không thể tin nổi! Tôi vừa hoàn thành đăng ký tài khoản và ngay lập tức nhận được thẻ thư viện ảo cực kỳ đẹp mắt. Việc tự theo dõi thời hạn thẻ và gia hạn trực tuyến giúp tôi tiết kiệm rất nhiều thời gian."
            </p>
            <div class="testimonial-author">- Nguyễn Anh Tuấn, Sinh viên CNTT</div>
          </div>

          <div class="testimonial-slide pa-8 text-center">
            <v-avatar size="80" class="mb-4 elevation-2">
              <v-img src="https://api.dicebear.com/7.x/adventurer/svg?seed=Aria"></v-img>
            </v-avatar>
            <p class="testimonial-text mb-6">
              "Giao diện Dashboard báo cáo của thư viện hiển thị cực kỳ trực quan và chi tiết. Tôi có thể dễ dàng xem biểu đồ mượn sách hàng tháng và tìm kiếm những đầu sách hot nhất để mượn về nghiên cứu."
            </p>
            <div class="testimonial-author">- Trần Thị Mai, Độc giả Tự do</div>
          </div>
        </a-carousel>
      </div>
    </section>

    <!-- 6. Chân trang (Footer) -->
    <footer class="footer py-12 px-8 text-white">
      <v-container>
        <v-row>
          <v-col cols="12" md="4">
            <div class="footer-brand mb-4">
              <v-icon icon="mdi-library" class="mr-2" color="secondary"></v-icon>
              <span class="logo-text text-white">SmartLib.NET</span>
            </div>
            <p class="footer-desc text-grey-lighten-1">
              Hệ thống quản lý và cấp thẻ thư viện thông minh thế hệ mới. Đem đến trải nghiệm học tập và nghiên cứu trọn vẹn nhất cho sinh viên và độc giả cả nước.
            </p>
          </v-col>
          <v-col cols="12" md="4" class="d-flex flex-column align-md-center">
            <h4 class="footer-title mb-4">Liên Kết Nhanh</h4>
            <ul class="footer-links">
              <li><a href="#">Trang chủ</a></li>
              <li><a href="#features">Tính năng</a></li>
              <li><a href="#stats">Thống kê số liệu</a></li>
              <li><a href="#testimonials">Phản hồi</a></li>
            </ul>
          </v-col>
          <v-col cols="12" md="4">
            <h4 class="footer-title mb-4">Thông Tin Liên Hệ</h4>
            <p class="footer-contact-item text-grey-lighten-1 mb-2">
              <v-icon icon="mdi-map-marker" class="mr-2" color="secondary"></v-icon>
              Đường 3/2, Xuân Khánh, Ninh Kiều, Cần Thơ
            </p>
            <p class="footer-contact-item text-grey-lighten-1 mb-2">
              <v-icon icon="mdi-phone" class="mr-2" color="secondary"></v-icon>
              Hotline: 1900 6789
            </p>
            <p class="footer-contact-item text-grey-lighten-1 mb-2">
              <v-icon icon="mdi-clock-outline" class="mr-2" color="secondary"></v-icon>
              Giờ mở cửa: 07:30 - 21:00 (Thứ 2 - Thứ 7)
            </p>
          </v-col>
        </v-row>
        <v-divider class="my-6 border-grey-darken-2"></v-divider>
        <div class="footer-bottom d-flex justify-space-between align-center flex-wrap">
          <p class="copyright text-grey-lighten-2 mb-0">© 2026 SmartLib.NET. Nhóm 3 - All Rights Reserved.</p>
          <div class="social-icons">
            <v-btn icon="mdi-facebook" variant="text" color="grey-lighten-2"></v-btn>
            <v-btn icon="mdi-github" variant="text" color="grey-lighten-2"></v-btn>
            <v-btn icon="mdi-twitter" variant="text" color="grey-lighten-2"></v-btn>
          </div>
        </div>
      </v-container>
    </footer>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'

const router = useRouter()

interface Book {
  title: string
  color: 'teal' | 'red' | 'ochre' | 'terracotta' | 'beige'
  height: 'tall' | 'medium' | 'short'
  leaning?: boolean
  angle?: number
}

const getBooksForShelf = (shelf: number): Book[] => {
  if (shelf === 1) {
    return [
      { title: 'Clean Code', color: 'teal', height: 'tall' },
      { title: 'Refactoring', color: 'red', height: 'medium' },
      { title: 'Patterns', color: 'ochre', height: 'short', leaning: true, angle: -12 },
      { title: 'Domain Driven', color: 'terracotta', height: 'tall' },
      { title: 'Microservices', color: 'beige', height: 'medium' },
      { title: 'Kubernetes', color: 'teal', height: 'short' }
    ]
  } else if (shelf === 2) {
    return [
      { title: 'Algorithms', color: 'red', height: 'tall' },
      { title: 'Rust Prog', color: 'ochre', height: 'medium' },
      { title: 'TypeScript', color: 'teal', height: 'short' },
      { title: 'VueJS 3', color: 'terracotta', height: 'medium', leaning: true, angle: 10 },
      { title: 'Pinia Store', color: 'beige', height: 'short' }
    ]
  } else {
    return [
      { title: 'C# 12 Deep', color: 'ochre', height: 'tall' },
      { title: 'ASP.NET Core', color: 'teal', height: 'medium' },
      { title: 'EF Core 9', color: 'red', height: 'short' },
      { title: 'RabbitMQ', color: 'terracotta', height: 'tall' },
      { title: 'Docker Dev', color: 'beige', height: 'medium' }
    ]
  }
}
</script>

<style scoped>
/* Scoped styles to implement the beautiful landing page */
.landing-container {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background-color: #FAF9F6; /* Soft warm ivory exactly like image background */
  overflow-x: hidden;
  padding-top: 80px; /* Offset for fixed navbar */
}

/* Navbar */
.navbar {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 16px 60px;
  background-color: rgba(250, 249, 246, 0.92); /* Glassmorphism ivory */
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px);
  z-index: 1000;
  border-bottom: 1px solid rgba(0, 0, 0, 0.05);
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.02);
  transition: all 0.3s ease;
}

.logo {
  display: flex;
  align-items: center;
}

.logo-icon {
  font-size: 28px;
  color: #1E5652 !important; /* Emerald color */
}

.logo-text {
  font-size: 24px;
  font-weight: 800;
  color: #1E5652; /* Emerald */
  letter-spacing: 1px;
}

.nav-links {
  display: flex;
  gap: 32px;
}

.nav-links a {
  text-decoration: none;
  font-size: 15px; /* Larger font size */
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
  font-size: 15px !important; /* Larger font size */
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
  transition: transform 0.3s, background-color 0.3s;
}

.btn-register:hover {
  background-color: #153E3B !important;
  transform: translateY(-1px);
}

/* Hero Section */
.hero-section {
  display: flex;
  min-height: calc(100vh - 80px);
  position: relative;
}

.hero-left {
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;
  padding: 0 60px 80px 100px;
  z-index: 5;
}

.hero-title {
  font-size: 72px;
  font-weight: 800;
  color: #114B44; /* Deep emerald color matches text */
  margin-bottom: 24px;
  line-height: 1.1;
  font-family: 'Outfit', sans-serif;
}

.hero-description {
  font-size: 16px;
  color: #5C6765;
  line-height: 1.8;
  margin-bottom: 40px;
  max-width: 480px;
}

.btn-learn-more {
  position: relative;
  overflow: hidden; /* Crucial for mirror/shine effect */
  background-color: #CF7C07; /* Warm ochre from image button */
  color: white;
  border: none;
  border-radius: 40px;
  padding: 16px 40px;
  font-size: 16px;
  font-weight: 700;
  cursor: pointer;
  width: fit-content;
  box-shadow: 0 6px 20px rgba(207, 124, 7, 0.35);
  transition: transform 0.3s, background-color 0.3s, box-shadow 0.3s;
}

/* Infinite Mirror/Shine Effect */
.btn-learn-more::after {
  content: '';
  position: absolute;
  top: -50%;
  left: -60%;
  width: 30%;
  height: 200%;
  background: rgba(255, 255, 255, 0.4);
  transform: rotate(30deg);
  transition: none;
  pointer-events: none;
  animation: btnShine 4.5s infinite ease-in-out;
}

@keyframes btnShine {
  0% {
    left: -60%;
  }
  15% {
    left: 140%;
  }
  100% {
    left: 140%;
  }
}

.btn-learn-more:hover {
  background-color: #B56C05;
  transform: translateY(-2px);
  box-shadow: 0 8px 24px rgba(207, 124, 7, 0.5);
}

/* Hero Right: Wave & Bookshelf */
.hero-right {
  flex: 1.1;
  position: relative;
  background-color: #26211F; /* Cozy dark bookshelf background from image */
  overflow: hidden;
}

/* Fluid Wavy SVG Divider */
.wave-separator {
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  width: 140px;
  height: 100%;
  z-index: 2;
  filter: drop-shadow(4px 0px 8px rgba(0,0,0,0.15));
}

/* Beautiful dynamic bookshelf */
.bookshelf-container {
  position: absolute;
  top: 60px;
  right: 60px;
  bottom: 60px;
  left: 160px;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  z-index: 3;
}

.shelf {
  position: relative;
  height: 200px;
  display: flex;
  align-items: flex-end;
  padding-bottom: 15px;
}

.shelf-wood {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  height: 15px;
  background: linear-gradient(90deg, #533527, #784C38);
  border-radius: 4px;
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.5);
}

.books-container {
  display: flex;
  align-items: flex-end;
  gap: 8px;
  padding-left: 20px;
  width: 100%;
}

/* Custom CSS books */
.book {
  position: relative;
  width: 36px;
  border-radius: 4px 4px 1px 1px;
  cursor: pointer;
  transition: transform 0.3s cubic-bezier(0.175, 0.885, 0.32, 1.275), box-shadow 0.3s;
  box-shadow: -3px 0 8px rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
}

.book:hover {
  transform: translateY(-15px) scale(1.05) !important;
  box-shadow: 0 12px 24px rgba(0, 0, 0, 0.5);
  z-index: 100 !important;
}

/* Book leaning style */
.book.leaning {
  transform-origin: bottom left;
  z-index: 5;
}

/* Book Sizes */
.book.tall { height: 150px; width: 38px; }
.book.medium { height: 125px; width: 34px; }
.book.short { height: 100px; width: 30px; }

/* Book Colors - curated to match the cozy bookshelf palette in the image */
.book.teal { background: linear-gradient(135deg, #19524F, #277D78); border-left: 5px solid #0F3331; }
.book.red { background: linear-gradient(135deg, #9C3328, #BF4E41); border-left: 5px solid #662019; }
.book.ochre { background: linear-gradient(135deg, #D48806, #F5B041); border-left: 5px solid #945F00; }
.book.terracotta { background: linear-gradient(135deg, #B25A38, #CF7C5C); border-left: 5px solid #7E3E25; }
.book.beige { background: linear-gradient(135deg, #E6E2D3, #F2EFE6); border-left: 5px solid #B8B3A0; }

/* Book spines details */
.book-spine {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  height: 100%;
  padding: 12px 2px;
  box-sizing: border-box;
}

.book-title {
  writing-mode: vertical-rl;
  text-orientation: mixed;
  transform: rotate(180deg);
  font-size: 10px;
  font-weight: 800;
  color: rgba(255, 255, 255, 0.85);
  letter-spacing: 1.5px;
  text-transform: uppercase;
  max-height: 90px;
  overflow: hidden;
}

.book.beige .book-title {
  color: #434D4B;
}

.spine-lines {
  width: 80%;
  height: 10px;
  border-top: 2px solid rgba(255, 255, 255, 0.35);
  border-bottom: 2px solid rgba(255, 255, 255, 0.35);
}

.book.beige .spine-lines {
  border-color: rgba(0, 0, 0, 0.15);
}

/* Features Section */
.features-section {
  background-color: #FAF9F6;
}

.section-title {
  font-size: 36px;
  font-weight: 800;
  color: #114B44;
  letter-spacing: 0.5px;
}

.feature-card {
  background-color: white !important;
  border-radius: 16px !important;
  transition: transform 0.3s, box-shadow 0.3s;
  height: 100%;
}

.feature-card:hover {
  transform: translateY(-8px);
  box-shadow: 0 15px 30px rgba(0,0,0,0.08) !important;
}

.feature-icon-wrapper {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 70px;
  height: 70px;
  background-color: rgba(30, 86, 82, 0.08);
  border-radius: 50%;
}

.feature-name {
  font-size: 20px;
  font-weight: 700;
  color: #1E5652;
}

.feature-desc {
  font-size: 14px;
  color: #6C7A78;
  line-height: 1.6;
}

.feature-badge {
  display: inline-block;
  background-color: rgba(207, 124, 7, 0.1);
  color: #CF7C07;
  font-size: 11px;
  font-weight: 700;
  padding: 4px 12px;
  border-radius: 20px;
  text-transform: uppercase;
  letter-spacing: 1px;
}

/* Statistics Section */
.stats-section {
  background: linear-gradient(135deg, #114B44, #1E5652);
}

.stat-item {
  padding: 20px 0;
}

.stat-number {
  font-size: 48px;
  font-weight: 800;
  color: #FAF9F6;
  margin-bottom: 8px;
}

.stat-label {
  font-size: 14px;
  color: #CBE0DE;
  font-weight: 600;
  letter-spacing: 0.5px;
}

/* Testimonials Section */
.testimonials-section {
  background-color: #F4F3ED; /* Slightly darker cream for depth */
}

.testimonial-slide {
  background-color: white;
  border-radius: 20px;
  box-shadow: 0 10px 25px rgba(0,0,0,0.04);
}

.testimonial-text {
  font-size: 16px;
  font-style: italic;
  color: #5C6765;
  line-height: 1.8;
}

.testimonial-author {
  font-size: 15px;
  font-weight: 700;
  color: #1E5652;
}

/* Ant design Carousel customization */
:deep(.ant-carousel .slick-dots li button) {
  background: #1E5652 !important;
}
:deep(.ant-carousel .slick-dots li.slick-active button) {
  background: #CF7C07 !important;
}

/* Footer Section */
.footer {
  background-color: #171B1A;
}

.footer-title {
  font-size: 16px;
  font-weight: 700;
  color: #FAF9F6;
  letter-spacing: 1px;
  text-transform: uppercase;
}

.footer-desc {
  font-size: 14px;
  line-height: 1.6;
}

.footer-links {
  list-style: none;
  padding: 0;
}

.footer-links li {
  margin-bottom: 12px;
}

.footer-links a {
  color: #9AA6A4;
  text-decoration: none;
  font-size: 14px;
  transition: color 0.3s;
}

.footer-links a:hover {
  color: #CF7C07;
}

.footer-contact-item {
  font-size: 14px;
  display: flex;
  align-items: center;
}

@media (max-width: 959px) {
  .hero-section {
    flex-direction: column;
  }
  .hero-left {
    padding: 60px 40px;
    align-items: center;
    text-align: center;
  }
  .hero-title {
    font-size: 54px;
  }
  .hero-description {
    max-width: 100%;
  }
  .hero-right {
    height: 500px;
  }
  .wave-separator {
    transform: rotate(90deg);
    top: -70px;
    left: 0;
    width: 100%;
    height: 140px;
  }
  .bookshelf-container {
    left: 40px;
    top: 80px;
    right: 40px;
    bottom: 40px;
  }
}
</style>
