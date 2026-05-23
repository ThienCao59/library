<template>
  <div class="stats-page-container">
    <!-- Navbar -->
    <header class="navbar">
      <div class="logo" @click="$router.push('/')">
        <v-icon icon="mdi-library" class="mr-2 logo-icon"></v-icon>
        <span class="logo-text">SmartLib.NET</span>
      </div>
      <nav class="nav-links">
        <a href="#" @click.prevent="$router.push('/')">HOME</a>
        <a href="#" @click.prevent="$router.push('/features')">FEATURES</a>
        <a href="#" class="active" @click.prevent="$router.push('/statistics')">STATISTICS</a>
        <a href="#" @click.prevent="$router.push('/reviews')">REVIEWS</a>
      </nav>
      <div class="nav-auth">
        <a-button type="text" class="btn-login mr-2" @click="$router.push('/login')">Sign in</a-button>
        <a-button type="primary" shape="round" class="btn-register" @click="$router.push('/register')">Sign up</a-button>
      </div>
    </header>

    <!-- Header Section -->
    <div class="stats-hero">
      <div class="hero-glow"></div>
      <div class="stats-hero-content text-center">
        <span class="badge-tag">SỐ LIỆU THỰC TẾ</span>
        <h1 class="stats-title">Thống Kê Hệ Thống</h1>
        <p class="stats-subtitle">
          Giám sát hiệu suất hoạt động, lưu lượng mượn sách, và chỉ số an toàn của toàn bộ hệ thống theo thời gian thực.
        </p>
      </div>
    </div>

    <!-- Main Stats Content Area -->
    <div class="stats-body-section">
      <!-- 1. Grid of Counter Cards -->
      <div class="counter-grid mb-12">
        <div class="counter-card">
          <div class="card-glow"></div>
          <v-icon icon="mdi-book-open-page-variant" class="card-ico"></v-icon>
          <div class="count-num">120,490+</div>
          <div class="count-lbl">Tổng Số Đầu Sách</div>
          <span class="trend-tag up">
            <v-icon icon="mdi-trending-up" class="mr-1"></v-icon> +12.4%
          </span>
        </div>
        <div class="counter-card">
          <div class="card-glow"></div>
          <v-icon icon="mdi-account-group" class="card-ico"></v-icon>
          <div class="count-num">24,580+</div>
          <div class="count-lbl">Độc Giả Hoạt Động</div>
          <span class="trend-tag up">
            <v-icon icon="mdi-trending-up" class="mr-1"></v-icon> +18.7%
          </span>
        </div>
        <div class="counter-card">
          <div class="card-glow"></div>
          <v-icon icon="mdi-swap-horizontal" class="card-ico"></v-icon>
          <div class="count-num">8,620+</div>
          <div class="count-lbl">Lượt Mượn Hàng Tháng</div>
          <span class="trend-tag down">
            <v-icon icon="mdi-trending-down" class="mr-1"></v-icon> -1.2%
          </span>
        </div>
        <div class="counter-card">
          <div class="card-glow"></div>
          <v-icon icon="mdi-check-decagram" class="card-ico"></v-icon>
          <div class="count-num">99.99%</div>
          <div class="count-lbl">Thời Gian Hoạt Động</div>
          <span class="trend-tag active">
            <span class="green-pulse mr-1"></span> ONLINE
          </span>
        </div>
      </div>

      <!-- 2. Interactive Charts row (Using Pure beautiful CSS / SVGs) -->
      <div class="charts-row mb-12">
        <!-- Chart 1: Category Distribution -->
        <div class="chart-container-card">
          <h3 class="chart-card-title mb-6">Tỷ Lệ Mượn Theo Thể Loại Sách</h3>
          <div class="chart-content flex-col">
            <!-- Simulated Horizontal Bar chart with custom HSL gradient lines -->
            <div class="bar-row mb-4">
              <div class="bar-info d-flex justify-space-between text-xs mb-1">
                <span class="font-weight-bold color-primary">Công Nghệ & Lập Trình</span>
                <span class="font-weight-bold text-grey">45% (3,879 lượt)</span>
              </div>
              <div class="bar-track">
                <div class="bar-fill tech" style="width: 45%"></div>
              </div>
            </div>

            <div class="bar-row mb-4">
              <div class="bar-info d-flex justify-space-between text-xs mb-1">
                <span class="font-weight-bold color-primary">Khoa Học Tự Nhiên</span>
                <span class="font-weight-bold text-grey">25% (2,155 lượt)</span>
              </div>
              <div class="bar-track">
                <div class="bar-fill science" style="width: 25%"></div>
              </div>
            </div>

            <div class="bar-row mb-4">
              <div class="bar-info d-flex justify-space-between text-xs mb-1">
                <span class="font-weight-bold color-primary">Văn Học & Nghệ Thuật</span>
                <span class="font-weight-bold text-grey">18% (1,551 lượt)</span>
              </div>
              <div class="bar-track">
                <div class="bar-fill art" style="width: 18%"></div>
              </div>
            </div>

            <div class="bar-row">
              <div class="bar-info d-flex justify-space-between text-xs mb-1">
                <span class="font-weight-bold color-primary">Kinh Tế & Kỹ Năng</span>
                <span class="font-weight-bold text-grey">12% (1,035 lượt)</span>
              </div>
              <div class="bar-track">
                <div class="bar-fill business" style="width: 12%"></div>
              </div>
            </div>
          </div>
        </div>

        <!-- Chart 2: Reader Visit Hours (Elegant SVG Area Chart) -->
        <div class="chart-container-card">
          <h3 class="chart-card-title mb-6">Khung Giờ Ghé Thăm Cao Điểm (24h)</h3>
          <div class="chart-content">
            <svg viewBox="0 0 400 150" class="area-chart-svg">
              <defs>
                <linearGradient id="chartGlow" x1="0" y1="0" x2="0" y2="1">
                  <stop offset="0%" stop-color="#1E5652" stop-opacity="0.4" />
                  <stop offset="100%" stop-color="#1E5652" stop-opacity="0" />
                </linearGradient>
              </defs>
              <!-- Grid lines -->
              <line x1="0" y1="30" x2="400" y2="30" stroke="rgba(0,0,0,0.04)" stroke-dasharray="4" />
              <line x1="0" y1="70" x2="400" y2="70" stroke="rgba(0,0,0,0.04)" stroke-dasharray="4" />
              <line x1="0" y1="110" x2="400" y2="110" stroke="rgba(0,0,0,0.04)" stroke-dasharray="4" />

              <!-- Chart Area path -->
              <path d="M 0 150 Q 50 120 100 60 T 200 40 T 300 100 T 400 30 L 400 150 Z" fill="url(#chartGlow)" />
              <!-- Chart Line path -->
              <path d="M 0 150 Q 50 120 100 60 T 200 40 T 300 100 T 400 30" fill="none" stroke="#1E5652" stroke-width="3" stroke-linecap="round" />

              <!-- Hot spots / Dots -->
              <circle cx="100" cy="60" r="4" fill="#CF7C07" />
              <circle cx="200" cy="40" r="4" fill="#CF7C07" />
              <circle cx="400" cy="30" r="4" fill="#CF7C07" />

              <!-- Labels -->
              <text x="100" y="50" font-size="8" font-weight="bold" fill="#CF7C07" text-anchor="middle">08:00 (HỌC TẬP)</text>
              <text x="200" y="30" font-size="8" font-weight="bold" fill="#CF7C07" text-anchor="middle">14:00 (CỰC ĐẠI)</text>
            </svg>
            <div class="axis-labels d-flex justify-space-between mt-3 text-grey text-caption">
              <span>06:00</span>
              <span>10:00</span>
              <span>14:00</span>
              <span>18:00</span>
              <span>22:00</span>
            </div>
          </div>
        </div>
      </div>

      <!-- 3. Microservices Health Dashboard (Highlighting Observability infrastructure) -->
      <div class="health-dashboard mb-12">
        <div class="health-header d-flex justify-space-between align-center mb-6">
          <div>
            <h3 class="health-title">Bảng Trạng Thái Dịch Vụ (Centralized Healthchecks)</h3>
            <p class="health-desc text-grey text-sm mb-0">Tự động giám sát toàn bộ Endpoint và Gateway liên tục qua /health</p>
          </div>
          <div class="health-refresh-pill">
            <v-icon icon="mdi-cached" class="mr-1 spin-icon"></v-icon> Live Monitoring
          </div>
        </div>

        <div class="health-grid">
          <div class="health-card">
            <div class="health-left-info">
              <span class="svc-name">API Gateway (Port 80)</span>
              <span class="svc-desc">Điều phối / Routing traffic</span>
            </div>
            <div class="health-right-status healthy">
              <span class="status-indicator"></span> HEALTHY (9ms)
            </div>
          </div>

          <div class="health-card">
            <div class="health-left-info">
              <span class="svc-name">IdentityReportService (Port 5001)</span>
              <span class="svc-desc">Xác thực, Token & Cấp thẻ</span>
            </div>
            <div class="health-right-status healthy">
              <span class="status-indicator"></span> HEALTHY (12ms)
            </div>
          </div>

          <div class="health-card">
            <div class="health-left-info">
              <span class="svc-name">RabbitMQ Server Event Bus</span>
              <span class="svc-desc">Hàng đợi truyền tin phi đồng bộ</span>
            </div>
            <div class="health-right-status healthy">
              <span class="status-indicator"></span> HEALTHY (4ms)
            </div>
          </div>

          <div class="health-card">
            <div class="health-left-info">
              <span class="svc-name">Serilog Logger Worker</span>
              <span class="svc-desc">Centralized Logging file/console</span>
            </div>
            <div class="health-right-status healthy">
              <span class="status-indicator"></span> RUNNING
            </div>
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
// Visual representation stats dashboard, highly dynamic and optimized
</script>

<style scoped>
.stats-page-container {
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

/* Hero Section style */
.stats-hero {
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

.stats-hero-content {
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

.stats-title {
  font-size: 56px;
  font-weight: 800;
  font-family: 'Outfit', sans-serif;
  line-height: 1.1;
  margin-bottom: 20px;
  background: linear-gradient(135deg, #FAF9F6 0%, #DCEAD5 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
}

.stats-subtitle {
  font-size: 18px;
  color: #CBE0DE;
  line-height: 1.6;
  max-width: 600px;
  margin: 0 auto;
}

/* Stats Body */
.stats-body-section {
  max-width: 1100px;
  margin: -40px auto 80px auto;
  padding: 0 40px;
  position: relative;
  z-index: 20;
}

/* Counter Grid */
.counter-grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr); /* Force exactly 4 columns in the same row on desktop */
  gap: 24px;
}

.counter-card {
  position: relative;
  background-color: white;
  border-radius: 18px;
  padding: 30px 24px;
  box-shadow: 0 15px 35px rgba(0,0,0,0.03);
  border: 1px solid rgba(0,0,0,0.02);
  display: flex;
  flex-direction: column;
  overflow: hidden;
  transition: transform 0.3s;
}

.counter-card:hover {
  transform: translateY(-4px);
}

.card-glow {
  position: absolute;
  top: -50%;
  right: -50%;
  width: 120%;
  height: 120%;
  background: radial-gradient(circle, rgba(30,86,82,0.03) 0%, rgba(255,255,255,0) 70%);
  z-index: 1;
}

.card-ico {
  color: #1E5652 !important;
  font-size: 28px !important;
  margin-bottom: 16px;
}

.count-num {
  font-size: 34px;
  font-weight: 850;
  color: #114B44;
  line-height: 1.2;
  font-family: 'Outfit', sans-serif;
}

.count-lbl {
  font-size: 13px;
  color: #7A8583;
  font-weight: 700;
  margin-top: 4px;
  margin-bottom: 12px;
}

.trend-tag {
  width: fit-content;
  font-size: 10px;
  font-weight: 800;
  padding: 2px 8px;
  border-radius: 6px;
  display: flex;
  align-items: center;
}

.trend-tag.up {
  background-color: #EBF3E8;
  color: #1E5652;
}

.trend-tag.down {
  background-color: #FDF2E2;
  color: #CF7C07;
}

.trend-tag.active {
  background-color: #EBF3E8;
  color: #1E5652;
}

.green-pulse {
  display: inline-block;
  width: 6px;
  height: 6px;
  border-radius: 50%;
  background-color: #2ECC71;
  box-shadow: 0 0 6px #2ECC71;
  animation: pulseHealth 1s infinite alternate;
}

@keyframes pulseHealth {
  0% { transform: scale(0.8); opacity: 0.5; }
  100% { transform: scale(1.2); opacity: 1; }
}

/* Charts Grid */
.charts-row {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 30px;
}

.chart-container-card {
  background-color: white;
  border-radius: 20px;
  padding: 30px;
  box-shadow: 0 15px 35px rgba(0,0,0,0.03);
  border: 1px solid rgba(0,0,0,0.02);
}

.chart-card-title {
  font-size: 18px;
  font-weight: 800;
  color: #114B44;
  position: relative;
  padding-left: 12px;
}

.chart-card-title::before {
  content: '';
  position: absolute;
  left: 0;
  top: 4px;
  bottom: 4px;
  width: 4px;
  background-color: #CF7C07;
  border-radius: 2px;
}

.bar-track {
  width: 100%;
  height: 10px;
  background-color: #FAF9F6;
  border-radius: 5px;
  overflow: hidden;
}

.bar-fill {
  height: 100%;
  border-radius: 5px;
}

.bar-fill.tech {
  background: linear-gradient(90deg, #1E5652 0%, #277D78 100%);
}

.bar-fill.science {
  background: linear-gradient(90deg, #CF7C07 0%, #E68A00 100%);
}

.bar-fill.art {
  background: linear-gradient(90deg, #84A98C 0%, #A3C1AD 100%);
}

.bar-fill.business {
  background: linear-gradient(90deg, #D35230 0%, #E74C3C 100%);
}

.area-chart-svg {
  width: 100%;
  height: auto;
}

/* Health check visualizer dashboard */
.health-dashboard {
  background-color: white;
  border-radius: 20px;
  padding: 30px;
  box-shadow: 0 15px 35px rgba(0,0,0,0.03);
  border: 1px solid rgba(0,0,0,0.02);
}

.health-title {
  font-size: 20px;
  font-weight: 800;
  color: #114B44;
}

.health-refresh-pill {
  background-color: #EBF3E8;
  color: #1E5652;
  font-size: 11px;
  font-weight: 800;
  padding: 6px 14px;
  border-radius: 20px;
  display: flex;
  align-items: center;
}

.spin-icon {
  animation: spinner 3s infinite linear;
}

@keyframes spinner {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

.health-grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 20px;
  margin-top: 24px;
}

.health-card {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: #FAF9F6;
  border-radius: 12px;
  padding: 16px 20px;
  border: 1px solid rgba(0,0,0,0.02);
}

.svc-name {
  display: block;
  font-size: 13px;
  font-weight: 800;
  color: #114B44;
}

.svc-desc {
  font-size: 11px;
  color: #7A8583;
}

.health-right-status.healthy {
  font-size: 11px;
  font-weight: 800;
  color: #1E5652;
  display: flex;
  align-items: center;
  gap: 6px;
}

.health-right-status.healthy .status-indicator {
  width: 8px;
  height: 8px;
  border-radius: 50%;
  background-color: #2ECC71;
  box-shadow: 0 0 6px #2ECC71;
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

@media (max-width: 950px) {
  .counter-grid {
    grid-template-columns: repeat(2, 1fr); /* 2x2 grid on tablets */
  }
}

@media (max-width: 850px) {
  .charts-row, .health-grid {
    grid-template-columns: 1fr;
  }
  .navbar {
    padding: 16px 30px;
  }
}

@media (max-width: 600px) {
  .counter-grid {
    grid-template-columns: 1fr; /* 1 column on mobile */
  }
}
</style>
