<template>
  <div class="dashboard-container">
    <!-- Route Protection Overlay -->
    <div v-if="!isAuthorized" class="access-denied">
      <div class="denied-card">
        <div class="denied-icon">🔒</div>
        <h2>Access Denied</h2>
        <p>Bạn không có quyền truy cập vào bảng quản trị này. Trang web này chỉ dành cho Admin hoặc Thủ thư!</p>
        <a-button type="primary" class="btn-home" @click="goHome">Quay lại Trang chủ</a-button>
      </div>
    </div>

    <template v-else>
      <!-- LEFT SIDEBAR (Perfect brand alignment: Deep Academic Emerald Teal #114B44) -->
      <aside class="dashboard-sidebar">
        <div class="sidebar-profile">
          <div class="profile-avatar">
            <span class="avatar-emoji">👤</span>
          </div>
          <h3 class="profile-name">{{ currentUser }}</h3>
          <p class="profile-email">{{ currentUser.toLowerCase() }}@smartlib.net</p>
        </div>

        <!-- Dynamic Sidebar Menu based on Role -->
        <nav class="sidebar-menu">
          <!-- ADMIN MENU -->
          <template v-if="currentRole === 'Admin'">
            <div class="menu-group-label">HỆ THỐNG ADMIN</div>
            <a class="menu-item" :class="{ active: currentTab === 'overview' }" @click="switchTab('overview')">
              <span class="icon">📊</span> Overview Dashboard
            </a>
            <a class="menu-item" :class="{ active: currentTab === 'books' }" @click="switchTab('books')">
              <span class="icon">📖</span> Danh mục Sách (N1)
            </a>
            <a class="menu-item" :class="{ active: currentTab === 'rules' }" @click="switchTab('rules')">
              <span class="icon">⚙️</span> Quy tắc mượn trả
            </a>
            <a class="menu-item" :class="{ active: currentTab === 'readers-list' }" @click="switchTab('readers-list')">
              <span class="icon">👥</span> Quản lý Độc giả
            </a>
            <a class="menu-item" :class="{ active: currentTab === 'cards-list' }" @click="switchTab('cards-list')">
              <span class="icon">💳</span> Thẻ Thư Viện
            </a>
          </template>

          <!-- LIBRARIAN MENU -->
          <template v-if="currentRole === 'Librarian'">
            <div class="menu-group-label">NGHIỆP VỤ THỦ THƯ</div>
            <a class="menu-item" :class="{ active: currentTab === 'loan-processing' }" @click="currentTab = 'loan-processing'">
              <span class="icon">🔄</span> Xử lý Phiếu mượn/trả
            </a>
            <a class="menu-item" :class="{ active: currentTab === 'search-status' }" @click="currentTab = 'search-status'">
              <span class="icon">🔍</span> Tra cứu Tình trạng
            </a>
            <a class="menu-item" :class="{ active: currentTab === 'confirm-return' }" @click="currentTab = 'confirm-return'">
              <span class="icon">📥</span> Xác nhận Trả sách
            </a>
          </template>
        </nav>

        <div class="sidebar-footer">
          <div class="role-badge-container">
            <span class="role-tag" :class="currentRole.toLowerCase()">{{ currentRole }} Portal</span>
          </div>
          <button class="btn-logout" @click="handleLogout">
            <span class="logout-icon">🔑</span> Logout
          </button>
        </div>
      </aside>

      <!-- MAIN CONTENT AREA (Harmonized background aligned with system Ivory #FAF9F6) -->
      <main class="dashboard-main">
        <!-- TOP BAR (Exactly matching reference with Welcome, Search and Action icons) -->
        <header class="dashboard-topbar">
          <div class="welcome-text">
            <h2>Welcome {{ currentUser }} !</h2>
          </div>
          <div class="topbar-actions">
            <div class="search-box-pill">
              <span class="search-icon">🔍</span>
              <input type="text" placeholder="Search..." />
            </div>
            <div class="action-icon-btn theme-toggle">☀️</div>
            <div class="action-icon-btn notifications" @click="message.info('Không có thông báo mới')">🔔</div>
          </div>
        </header>

        <!-- ==================== 1. ADMIN - OVERVIEW TAB ==================== -->
        <template v-if="currentRole === 'Admin' && currentTab === 'overview'">
          <div class="tab-content animate-fade-in">
            <div class="content-header-row">
              <h3>Over View</h3>
              <span class="year-badge">2026</span>
            </div>

            <!-- OVER VIEW CARDS (Cohesive, unified borders for high-end professional appearance) -->
            <div class="overview-cards-row">
              <div class="ov-card brand-border clickable" @click="openDetailModal('readers')">
                <div class="ov-icon-wrapper teal-bg">👥</div>
                <div class="ov-info">
                  <div class="ov-value">{{ getUserStat('TotalUsers') }}</div>
                  <div class="ov-label">Total Readers</div>
                </div>
              </div>

              <div class="ov-card brand-border clickable" @click="openDetailModal('cards')">
                <div class="ov-icon-wrapper gold-bg">💳</div>
                <div class="ov-info">
                  <div class="ov-value">{{ getCardStat('TotalCards') }}</div>
                  <div class="ov-label">Active Cards</div>
                </div>
              </div>

              <div class="ov-card brand-border clickable" @click="openDetailModal('borrows')">
                <div class="ov-icon-wrapper teal-bg">🔄</div>
                <div class="ov-info">
                  <div class="ov-value">0</div>
                  <div class="ov-label">Total Borrows</div>
                </div>
              </div>

              <!-- Highlighted card exactly matching the reference outline look but in SmartLib Warm Gold -->
              <div class="ov-card gold-highlight clickable" @click="openDetailModal('books')">
                <div class="ov-icon-wrapper gold-bg">📚</div>
                <div class="ov-info">
                  <div class="ov-value">0</div>
                  <div class="ov-label">Total Books</div>
                </div>
                <span class="info-tooltip" @click.stop="message.info('Đầu sách đồng bộ từ Catalog Service')">i</span>
              </div>
            </div>

            <!-- GRAPHICS GRID (Exactly matching reference mid layout) -->
            <div class="graphics-grid">
              <!-- Left Column Panels -->
              <div class="graphics-left-col">
                <div class="mid-panels-row">
                  <!-- Panel 1: No of Users -->
                  <div class="white-panel users-count-panel">
                    <h4>No of users</h4>
                    <div class="user-stats-visual">
                      <div class="user-icon-circle">👥</div>
                      <div class="large-number">{{ stats?.UserStats?.TotalUsers * 100 || 583 }} K</div>
                      <div class="sub-label">Total Customers</div>
                    </div>
                  </div>

                  <!-- Panel 2: Cohesive Donut Chart representation -->
                  <div class="white-panel pie-chart-panel">
                    <h4>Card Activity Index</h4>
                    <div class="pie-chart-container">
                      <div class="svg-pie">
                        <svg viewBox="0 0 36 36" class="circular-chart">
                          <path class="circle-bg"
                            d="M18 2.0845 a 15.9155 15.9155 0 0 1 0 31.831 a 15.9155 15.9155 0 0 1 0 -31.831"
                          />
                          <path class="circle"
                            stroke-dasharray="75, 100"
                            d="M18 2.0845 a 15.9155 15.9155 0 0 1 0 31.831 a 15.9155 15.9155 0 0 1 0 -31.831"
                          />
                        </svg>
                        <div class="pie-percentage">75%</div>
                      </div>
                      <div class="pie-legend">
                        <div class="legend-item"><span class="dot active"></span> Active (75%)</div>
                        <div class="legend-item"><span class="dot locked"></span> Locked (25%)</div>
                      </div>
                    </div>
                  </div>
                </div>

                <!-- Panel 3: Borrowing Trends Area Chart (Clean, professional dual-wave teal & gold curves) -->
                <div class="white-panel area-chart-panel">
                  <div class="chart-header">
                    <h4>Borrowing Trends</h4>
                    <span class="sub-label">Last 6 months</span>
                  </div>
                  <div class="svg-area-chart-container">
                    <svg viewBox="0 0 500 150" class="area-chart-svg">
                      <defs>
                        <linearGradient id="gradientTeal" x1="0" y1="0" x2="0" y2="1">
                          <stop offset="0%" stop-color="#1E5652" stop-opacity="0.25"/>
                          <stop offset="100%" stop-color="#1E5652" stop-opacity="0"/>
                        </linearGradient>
                        <linearGradient id="gradientGold" x1="0" y1="0" x2="0" y2="1">
                          <stop offset="0%" stop-color="#CF7C07" stop-opacity="0.15"/>
                          <stop offset="100%" stop-color="#CF7C07" stop-opacity="0"/>
                        </linearGradient>
                      </defs>
                      <!-- Wave 1 (Teal) -->
                      <path d="M 0 120 C 100 80, 200 130, 300 70 C 400 30, 450 60, 500 40 L 500 150 L 0 150 Z" fill="url(#gradientTeal)"/>
                      <path d="M 0 120 C 100 80, 200 130, 300 70 C 400 30, 450 60, 500 40" fill="none" stroke="#1E5652" stroke-width="3"/>
                      
                      <!-- Wave 2 (Gold) -->
                      <path d="M 0 100 C 80 110, 180 70, 280 90 C 380 110, 420 50, 500 60 L 500 150 L 0 150 Z" fill="url(#gradientGold)"/>
                      <path d="M 0 100 C 80 110, 180 70, 280 90 C 380 110, 420 50, 500 60" fill="none" stroke="#CF7C07" stroke-width="2" stroke-dasharray="4 4"/>
                      
                      <!-- Markers -->
                      <circle cx="300" cy="70" r="5" fill="#1E5652"/>
                      <circle cx="420" cy="50" r="5" fill="#CF7C07"/>
                    </svg>
                    <!-- Indicators tags matching reference design but in system palette -->
                    <span class="indicator-tag peak" style="left: 60%; top: 35%">Highest Peak</span>
                    <span class="indicator-tag active-tag" style="left: 82%; top: 22%">Active</span>
                    
                    <div class="chart-months">
                      <span>Dec</span><span>Jan</span><span>Feb</span><span>Mar</span><span>Apr</span><span>May</span><span>Jun</span>
                    </div>
                  </div>
                </div>
              </div>

              <!-- Right Column Panel: Top Books bar chart with cohesive system shades -->
              <div class="graphics-right-col">
                <div class="white-panel horizontal-bars-panel">
                  <h4>Top Borrowed Books</h4>
                  <div class="hbar-list">
                    <div class="hbar-item">
                      <div class="hbar-label-row">
                        <span class="book-name">Lập Trình Hướng Đối Tượng C#</span>
                        <span class="book-qty">874</span>
                      </div>
                      <div class="progress-track">
                        <div class="progress-bar bar-teal-primary" style="width: 85%"></div>
                      </div>
                    </div>

                    <div class="hbar-item">
                      <div class="hbar-label-row">
                        <span class="book-name">Clean Code - Mã Sạch</span>
                        <span class="book-qty">721</span>
                      </div>
                      <div class="progress-track">
                        <div class="progress-bar bar-gold" style="width: 75%"></div>
                      </div>
                    </div>

                    <div class="hbar-item">
                      <div class="hbar-label-row">
                        <span class="book-name">Kiến Trúc Microservices</span>
                        <span class="book-qty">598</span>
                      </div>
                      <div class="progress-track">
                        <div class="progress-bar bar-teal-secondary" style="width: 60%"></div>
                      </div>
                    </div>

                    <div class="hbar-item">
                      <div class="hbar-label-row">
                        <span class="book-name">Javascript Nâng Cao</span>
                        <span class="book-qty">506</span>
                      </div>
                      <div class="progress-track">
                        <div class="progress-bar bar-teal-muted" style="width: 50%"></div>
                      </div>
                    </div>

                    <div class="hbar-item">
                      <div class="hbar-label-row">
                        <span class="book-name">Cơ Sở Dữ Liệu SQL Server</span>
                        <span class="book-qty">395</span>
                      </div>
                      <div class="progress-track">
                        <div class="progress-bar bar-gold-muted" style="width: 40%"></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </template>

        <!-- ==================== 7. ADMIN - READERS MANAGEMENT ==================== -->
        <template v-if="currentRole === 'Admin' && currentTab === 'readers-list'">
          <div class="tab-content animate-fade-in">
            <div class="content-header-row">
              <div class="title-with-subtitle">
                <h3>👥 Quản lý Danh sách Độc giả</h3>
                <p class="subtitle-text">Xem và quản lý thông tin các độc giả đăng ký trong hệ thống</p>
              </div>
              <span class="stats-pill">Tổng cộng: {{ filteredReaders.length }} độc giả</span>
            </div>

            <!-- Search and Filter Panel -->
            <div class="white-panel search-filter-panel brand-border">
              <div class="search-input-pill">
                <span class="search-icon">🔍</span>
                <input v-model="readersSearchQuery" type="text" placeholder="Tìm theo tên, email, tên đăng nhập..." />
              </div>
              <div class="filter-group">
                <span class="filter-label">Trạng thái:</span>
                <select v-model="readersStatusFilter" class="custom-select-pill">
                  <option value="all">Tất cả độc giả</option>
                  <option value="active">Đang hoạt động</option>
                  <option value="inactive">Bị khóa</option>
                </select>
              </div>
            </div>

            <div v-if="detailLoading" class="page-loading-spinner-wrapper">
              <div class="spinner-spinner"></div>
              <p>Đang tải danh sách độc giả từ Database...</p>
            </div>

            <div v-else-if="filteredReaders.length === 0" class="empty-state-card">
              <div class="empty-icon">🤷‍♂️</div>
              <h4>Không tìm thấy độc giả nào</h4>
              <p>Vui lòng thử lại với từ khóa hoặc bộ lọc khác.</p>
            </div>

            <div v-else class="readers-grid-layout">
              <div v-for="reader in filteredReaders" :key="reader.Id || reader.id" class="reader-card-new">
                <div class="reader-card-top-decoration"></div>
                <div class="reader-card-avatar-wrapper">
                  <div class="avatar-ring">
                    <span class="avatar-emoji">👤</span>
                  </div>
                </div>
                <div class="reader-card-body">
                  <h4 class="reader-card-name">{{ reader.FullName || reader.fullName }}</h4>
                  <span class="reader-card-username">@{{ reader.Username || reader.username }}</span>
                  
                  <div class="reader-card-meta">
                    <div class="meta-item">
                      <span class="m-icon">📧</span>
                      <span class="m-text" :title="reader.Email || reader.email">{{ reader.Email || reader.email }}</span>
                    </div>
                    <div class="meta-item">
                      <span class="m-icon">💳</span>
                      <span class="m-text">
                        Thẻ: <strong class="text-teal">{{ reader.LibraryCard?.CardNumber || reader.libraryCard?.cardNumber || 'Chưa cấp' }}</strong>
                      </span>
                    </div>
                  </div>
                </div>
                <div class="reader-card-footer">
                  <span class="status-badge" :class="(reader.IsActive || reader.isActive) ? 'instock' : 'outstock'">
                    {{ (reader.IsActive || reader.isActive) ? 'Hoạt động' : 'Bị khóa' }}
                  </span>
                  <button class="btn-action-small" :class="(reader.IsActive || reader.isActive) ? 'btn-lock' : 'btn-unlock'" @click="toggleUserStatus(reader)">
                    {{ (reader.IsActive || reader.isActive) ? '🔒 Khóa' : '🔓 Mở khóa' }}
                  </button>
                </div>
              </div>
            </div>
          </div>
        </template>

        <!-- ==================== 8. ADMIN - CARDS MANAGEMENT ==================== -->
        <template v-if="currentRole === 'Admin' && currentTab === 'cards-list'">
          <div class="tab-content animate-fade-in">
            <div class="content-header-row">
              <div class="title-with-subtitle">
                <h3>💳 Danh sách Thẻ Thư Viện</h3>
                <p class="subtitle-text">Xem và quản lý thẻ thư viện của các độc giả</p>
              </div>
              <span class="stats-pill">Tổng cộng: {{ filteredCards.length }} thẻ</span>
            </div>

            <!-- Search and Filter Panel -->
            <div class="white-panel search-filter-panel brand-border">
              <div class="search-input-pill">
                <span class="search-icon">🔍</span>
                <input v-model="cardsSearchQuery" type="text" placeholder="Tìm theo mã thẻ, tên chủ thẻ..." />
              </div>
              <div class="filter-group">
                <span class="filter-label">Trạng thái:</span>
                <select v-model="cardsStatusFilter" class="custom-select-pill">
                  <option value="all">Tất cả trạng thái</option>
                  <option value="active">Active (Hoạt động)</option>
                  <option value="locked">Locked (Bị khóa)</option>
                  <option value="expired">Expired (Hết hạn)</option>
                </select>
              </div>
            </div>

            <div v-if="detailLoading" class="page-loading-spinner-wrapper">
              <div class="spinner-spinner"></div>
              <p>Đang tải danh sách thẻ...</p>
            </div>

            <div v-else-if="filteredCards.length === 0" class="empty-state-card">
              <div class="empty-icon">🤷‍♂️</div>
              <h4>Không tìm thấy thẻ nào</h4>
              <p>Vui lòng thử lại với từ khóa hoặc bộ lọc khác.</p>
            </div>

            <div v-else class="cards-grid-layout">
              <div v-for="card in filteredCards" :key="card.CardNumber || card.cardNumber" class="library-credit-card" :class="(card.Status || card.status).toLowerCase()">
                <!-- Front design of realistic credit card -->
                <div class="card-inner-glass">
                  <!-- Top Row: Logo and Status -->
                  <div class="card-header-row">
                    <span class="card-brand-logo">📚 SmartLib</span>
                    <span class="card-status-dot-badge">
                      <span class="pulse-dot"></span>
                      {{ card.Status || card.status }}
                    </span>
                  </div>

                  <!-- Chip and Contactless -->
                  <div class="card-chip-row">
                    <div class="gold-chip"></div>
                    <span class="wifi-icon">📶</span>
                  </div>

                  <!-- Card Number with nice wide spacing -->
                  <div class="card-number-display">
                    {{ formatCardNumber(card.CardNumber || card.cardNumber) }}
                  </div>

                  <!-- Bottom Details Row -->
                  <div class="card-details-row">
                    <div class="detail-col">
                      <span class="detail-lbl">CARD HOLDER</span>
                      <span class="detail-val">{{ card.OwnerName || card.ownerName || 'READ ONLY' }}</span>
                    </div>
                    <div class="detail-col text-right">
                      <span class="detail-lbl">EXPIRED</span>
                      <span class="detail-val">{{ formatDate(card.ExpiryDate || card.expiryDate) }}</span>
                    </div>
                  </div>
                </div>

                <!-- Action overlay or buttons displayed under the realistic card in the card container -->
                <div class="card-action-underlay">
                  <div class="issue-date-label">Ngày cấp: {{ formatDate(card.IssueDate || card.issueDate) }}</div>
                  <button class="btn-action-card-toggle" @click="toggleCardStatus(card)">
                    {{ (card.Status || card.status) === 'Active' ? '🔒 Khóa Thẻ' : '🔓 Kích Hoạt' }}
                  </button>
                </div>
              </div>
            </div>
          </div>
        </template>

        <!-- ==================== 2. ADMIN - BOOKS TAB (N1) ==================== -->
        <template v-if="currentRole === 'Admin' && currentTab === 'books'">
          <div class="tab-content animate-fade-in">
            <div class="content-header-row">
              <h3>📖 Danh mục Sách (Catalog)</h3>
              <a-button type="primary" class="btn-action-pastel" @click="showAddBookModal">
                ➕ Thêm Sách Mới
              </a-button>
            </div>

            <div class="white-panel table-panel">
              <table class="pastel-table">
                <thead>
                  <tr>
                    <th>Mã Sách</th>
                    <th>Tên Đầu Sách</th>
                    <th>Tác Giả</th>
                    <th>Thể Loại</th>
                    <th>Số Lượng</th>
                    <th>Trạng Thái</th>
                    <th>Hành Động</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="book in mockBooks" :key="book.id">
                    <td class="text-teal font-bold">{{ book.code }}</td>
                    <td class="font-bold text-dark">{{ book.title }}</td>
                    <td>{{ book.author }}</td>
                    <td><span class="genre-badge">{{ book.genre }}</span></td>
                    <td>{{ book.qty }}</td>
                    <td>
                      <span class="status-badge" :class="book.qty > 0 ? 'instock' : 'outstock'">
                        {{ book.qty > 0 ? 'Còn sách' : 'Hết sách' }}
                      </span>
                    </td>
                    <td>
                      <div class="action-buttons">
                        <button class="btn-edit-inline" @click="editBook(book)">✏️</button>
                        <button class="btn-delete-inline" @click="deleteBook(book.id)">🗑️</button>
                      </div>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </template>

        <!-- ==================== 3. ADMIN - RULES TAB ==================== -->
        <template v-if="currentRole === 'Admin' && currentTab === 'rules'">
          <div class="tab-content animate-fade-in">
            <div class="content-header-row">
              <h3>⚙️ Quy tắc Mượn/Trả sách</h3>
              <a-button type="primary" class="btn-action-pastel" @click="saveRules">
                💾 Lưu Thay Đổi
              </a-button>
            </div>

            <div class="rules-grid">
              <div class="white-panel rule-settings-card">
                <h4>📌 Hạn mức Độc giả</h4>
                <div class="form-group-custom">
                  <label>Số sách được mượn tối đa / lần</label>
                  <a-input-number v-model:value="rulesState.maxBorrowLimit" :min="1" :max="10" class="num-input" />
                  <span class="input-desc">Khuyên dùng: 5 cuốn</span>
                </div>
                <div class="form-group-custom">
                  <label>Số ngày mượn tối đa / cuốn</label>
                  <a-input-number v-model:value="rulesState.maxBorrowDays" :min="1" :max="90" class="num-input" />
                  <span class="input-desc">Khuyên dùng: 14 ngày</span>
                </div>
              </div>

              <div class="white-panel rule-settings-card">
                <h4>💸 Quy định Phí Phạt</h4>
                <div class="form-group-custom">
                  <label>Phí phạt quá hạn mỗi ngày (VND)</label>
                  <a-input-number v-model:value="rulesState.penaltyPerDay" :min="0" :step="1000" class="num-input" />
                  <span class="input-desc">Khuyên dùng: 5.000đ / ngày</span>
                </div>
                <div class="form-group-custom">
                  <label>Thời gian ân hạn phạt (Ngày)</label>
                  <a-input-number v-model:value="rulesState.gracePeriod" :min="0" :max="7" class="num-input" />
                  <span class="input-desc">Độc giả không bị phạt trong khoảng ngày này</span>
                </div>
              </div>
            </div>
          </div>
        </template>

        <!-- ==================== 4. LIBRARIAN - LOAN PROCESSING TAB ==================== -->
        <template v-if="currentRole === 'Librarian' && currentTab === 'loan-processing'">
          <div class="tab-content animate-fade-in">
            <div class="content-header-row">
              <h3>🔄 Xử lý Yêu cầu Mượn / Trả</h3>
              <span class="pending-badge-count">{{ mockLoans.filter(l => l.status === 'Chờ duyệt').length }} pending</span>
            </div>

            <div class="white-panel table-panel">
              <table class="pastel-table">
                <thead>
                  <tr>
                    <th>Mã Phiếu</th>
                    <th>Độc Giả</th>
                    <th>Mã Thẻ</th>
                    <th>Sách Đăng Ký</th>
                    <th>Ngày Đăng Ký</th>
                    <th>Trạng Thái</th>
                    <th>Hành Động</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="loan in mockLoans" :key="loan.id">
                    <td class="text-teal font-bold">#{{ loan.code }}</td>
                    <td class="font-bold text-dark">{{ loan.readerName }}</td>
                    <td><span class="card-number-badge">{{ loan.cardNo }}</span></td>
                    <td>{{ loan.bookTitle }}</td>
                    <td>{{ loan.requestDate }}</td>
                    <td>
                      <span class="status-badge" :class="loan.status.toLowerCase().replace(' ', '-')">
                        {{ loan.status }}
                      </span>
                    </td>
                    <td>
                      <div class="action-buttons" v-if="loan.status === 'Chờ duyệt'">
                        <button class="btn-approve" @click="approveLoan(loan.id)">✅ Duyệt</button>
                        <button class="btn-reject" @click="rejectLoan(loan.id)">❌ Từ chối</button>
                      </div>
                      <span v-else class="text-muted">Đã xử lý</span>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </template>

        <!-- ==================== 5. LIBRARIAN - SEARCH STATUS TAB ==================== -->
        <template v-if="currentRole === 'Librarian' && currentTab === 'search-status'">
          <div class="tab-content animate-fade-in">
            <div class="content-header-row">
              <h3>🔍 Tra cứu Tình trạng Độc giả</h3>
            </div>

            <div class="white-panel search-panel">
              <div class="search-input-group">
                <a-input v-model:value="searchCardNo" placeholder="Nhập Mã Thẻ thư viện (Ví dụ: LIB-577064)..." class="search-input-pill" />
                <a-button type="primary" class="btn-search-pill" @click="handleSearchCard">Tìm kiếm</a-button>
              </div>

              <!-- Search Results -->
              <div v-if="searchResult" class="search-results-box animate-fade-in">
                <div class="result-header">
                  <div class="user-info-large">
                    <h3>{{ searchResult.name }}</h3>
                    <span class="card-no">{{ searchResult.cardNo }}</span>
                  </div>
                  <span class="status-badge instock">Thẻ Hoạt Động</span>
                </div>

                <div class="details-grid-custom">
                  <div class="detail-item-box">
                    <span class="lbl">Sách đang mượn</span>
                    <span class="val">{{ searchResult.borrowedBooks }} cuốn</span>
                  </div>
                  <div class="detail-item-box">
                    <span class="lbl">Sách quá hạn</span>
                    <span class="val text-danger">{{ searchResult.overdueBooks }} cuốn</span>
                  </div>
                  <div class="detail-item-box">
                    <span class="lbl">Tiền phạt tích lũy</span>
                    <span class="val text-gold">{{ searchResult.penaltyAmt }} VND</span>
                  </div>
                </div>

                <div class="active-loans-list">
                  <h4>📚 Các cuốn sách đang mượn:</h4>
                  <div class="loan-item-row" v-for="b in searchResult.activeLoans" :key="b.title">
                    <span class="title">{{ b.title }}</span>
                    <span class="date">Hạn trả: {{ b.dueDate }}</span>
                    <span class="badge-status-loan" :class="b.status">{{ b.status === 'overdue' ? 'Quá hạn' : 'Đang mượn' }}</span>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </template>

        <!-- ==================== 6. LIBRARIAN - CONFIRM RETURN TAB ==================== -->
        <template v-if="currentRole === 'Librarian' && currentTab === 'confirm-return'">
          <div class="tab-content animate-fade-in">
            <div class="content-header-row">
              <h3>📥 Xác nhận Trả sách</h3>
            </div>

            <div class="white-panel return-panel">
              <div class="steps-flow">
                <div class="step-item" :class="{ completed: returnStep >= 1 }">
                  <span class="step-num">1</span>
                  <span class="step-txt">Nhập mã sách</span>
                </div>
                <div class="step-item" :class="{ completed: returnStep >= 2 }">
                  <span class="step-num">2</span>
                  <span class="step-txt">Kiểm tra vật lý</span>
                </div>
                <div class="step-item" :class="{ completed: returnStep >= 3 }">
                  <span class="step-num">3</span>
                  <span class="step-txt">Hoàn tất</span>
                </div>
              </div>

              <!-- Step 1 Layout -->
              <div v-if="returnStep === 1" class="step-content-box">
                <p>Nhập mã sách để bắt đầu quy trình thu hồi:</p>
                <div class="input-inline">
                  <a-input v-model:value="returnBookCode" placeholder="Nhập mã sách (e.g. MS-OOP-001)..." class="pill-input-custom" />
                  <a-button type="primary" class="btn-next-step" @click="returnStep = 2">Tiếp tục ➡️</a-button>
                </div>
              </div>

              <!-- Step 2 Layout -->
              <div v-if="returnStep === 2" class="step-content-box">
                <p>Xác nhận tình trạng sách trả lại:</p>
                <div class="checkbox-group-custom">
                  <a-checkbox v-model:checked="bookCondition.intact">Sách còn nguyên vẹn, không rách nát</a-checkbox>
                  <a-checkbox v-model:checked="bookCondition.clean">Sách sạch sẽ, không bị vẽ bậy</a-checkbox>
                  <a-checkbox v-model:checked="bookCondition.noLate">Sách trả đúng hạn</a-checkbox>
                </div>
                <div class="step-actions mt-6">
                  <a-button class="btn-prev" @click="returnStep = 1">⬅️ Quay lại</a-button>
                  <a-button type="primary" class="btn-next-step" @click="handleConfirmReturn">Xác nhận Hoàn trả</a-button>
                </div>
              </div>

              <!-- Step 3 Layout -->
              <div v-if="returnStep === 3" class="step-content-box text-center">
                <div class="success-icon-large">🎉</div>
                <h3>Thu hồi sách thành công!</h3>
                <p class="text-teal">Đầu sách đã được tự động cộng lại kho lưu trữ Catalog (N1).</p>
                <a-button type="primary" class="btn-restart" @click="resetReturnWizard">Thu hồi cuốn khác</a-button>
              </div>
            </div>
          </div>
        </template>
      </main>
    </template>

    <!-- ==================== DETAIL MODALS ==================== -->

    <!-- READERS DETAIL MODAL -->
    <a-modal v-model:open="showReadersModal" title="👥 Danh sách Độc giả" width="750px" :footer="null" class="detail-modal">
      <div v-if="detailLoading" class="modal-loading">⏳ Đang tải dữ liệu từ Database...</div>
      <div v-else-if="readersList.length === 0" class="modal-empty">Chưa có độc giả nào trong hệ thống.</div>
      <table v-else class="pastel-table modal-table">
        <thead>
          <tr>
            <th>Họ Tên</th>
            <th>Username</th>
            <th>Email</th>
            <th>Mã Thẻ</th>
            <th>Trạng Thái</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="reader in readersList" :key="reader.Id || reader.id">
            <td class="font-bold text-dark">{{ reader.FullName || reader.fullName }}</td>
            <td>{{ reader.Username || reader.username }}</td>
            <td>{{ reader.Email || reader.email }}</td>
            <td><span class="card-number-badge">{{ reader.LibraryCard?.CardNumber || reader.libraryCard?.cardNumber || 'Chưa cấp' }}</span></td>
            <td>
              <span class="status-badge" :class="(reader.IsActive || reader.isActive) ? 'instock' : 'outstock'">
                {{ (reader.IsActive || reader.isActive) ? 'Hoạt động' : 'Bị khóa' }}
              </span>
            </td>
          </tr>
        </tbody>
      </table>
    </a-modal>

    <!-- CARDS DETAIL MODAL -->
    <a-modal v-model:open="showCardsModal" title="💳 Danh sách Thẻ thư viện" width="750px" :footer="null" class="detail-modal">
      <div v-if="detailLoading" class="modal-loading">⏳ Đang tải dữ liệu từ Database...</div>
      <div v-else-if="cardsList.length === 0" class="modal-empty">Chưa có thẻ thư viện nào trong hệ thống.</div>
      <table v-else class="pastel-table modal-table">
        <thead>
          <tr>
            <th>Mã Thẻ</th>
            <th>Chủ thẻ</th>
            <th>Ngày cấp</th>
            <th>Ngày hết hạn</th>
            <th>Trạng Thái</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="card in cardsList" :key="card.CardNumber || card.cardNumber">
            <td class="text-teal font-bold">{{ card.CardNumber || card.cardNumber }}</td>
            <td class="font-bold text-dark">{{ card.OwnerName || card.ownerName }}</td>
            <td>{{ formatDate(card.IssueDate || card.issueDate) }}</td>
            <td>{{ formatDate(card.ExpiryDate || card.expiryDate) }}</td>
            <td>
              <span class="status-badge" :class="(card.Status || card.status) === 'Active' ? 'instock' : 'outstock'">
                {{ card.Status || card.status }}
              </span>
            </td>
          </tr>
        </tbody>
      </table>
    </a-modal>

    <!-- BORROWS DETAIL MODAL -->
    <a-modal v-model:open="showBorrowsModal" title="🔄 Chi tiết Lượt mượn" width="500px" :footer="null" class="detail-modal">
      <div class="modal-pending">
        <div class="pending-icon">🔗</div>
        <h3>Chờ kết nối Circulation Service (N2)</h3>
        <p>Dữ liệu chi tiết lượt mượn sẽ được đồng bộ tự động khi nhóm N2 hoàn thành và kết nối API Gateway.</p>
      </div>
    </a-modal>

    <!-- BOOKS DETAIL MODAL -->
    <a-modal v-model:open="showBooksModal" title="📚 Chi tiết Tổng sách" width="500px" :footer="null" class="detail-modal">
      <div class="modal-pending">
        <div class="pending-icon">🔗</div>
        <h3>Chờ kết nối Catalog Service (N1)</h3>
        <p>Dữ liệu chi tiết danh mục sách sẽ được đồng bộ tự động khi nhóm N1 hoàn thành và kết nối API Gateway.</p>
      </div>
    </a-modal>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed, reactive } from 'vue'
import { useRouter } from 'vue-router'
import { message } from 'ant-design-vue'
import axios from 'axios'

const router = useRouter()
const loading = ref(false)
const stats = ref<any>(null)

// Get state from localStorage
const currentRole = ref(localStorage.getItem('role') || 'Admin')
const currentUser = ref(localStorage.getItem('username') || 'Nirmal')
const accessToken = ref(localStorage.getItem('accessToken') || '')

// Authorize guard
const isAuthorized = computed(() => {
  return (currentRole.value === 'Admin' || currentRole.value === 'Librarian')
})

// Tab active state
const currentTab = ref(currentRole.value === 'Admin' ? 'overview' : 'loan-processing')

const switchTab = (tabName: string) => {
  currentTab.value = tabName
  if (tabName === 'readers-list') {
    fetchReadersData()
  } else if (tabName === 'cards-list') {
    fetchCardsData()
  }
}

const goHome = () => {
  router.push('/')
}

const handleLogout = () => {
  localStorage.clear()
  message.success('Đăng xuất thành công!')
  router.push('/')
}

// -------------------------------------------------------------
// [DATA MOCKING & API INTEGRATIONS]
// -------------------------------------------------------------

// N1 - Catalog Books Mock List
const mockBooks = ref([
  { id: 1, code: 'MS-OOP-001', title: 'Lập Trình Hướng Đối Tượng C#', author: 'Nguyễn Văn A', genre: 'Giáo trình', qty: 15 },
  { id: 2, code: 'MS-CC-002', title: 'Clean Code - Mã Sạch', author: 'Robert C. Martin', genre: 'Lập trình', qty: 8 },
  { id: 3, code: 'MS-MS-003', title: 'Kiến Trúc Microservices Thực Tế', author: 'Trần Văn B', genre: 'Kiến trúc PM', qty: 3 },
  { id: 4, code: 'MS-JS-004', title: 'Javascript Nâng Cao', author: 'Lê Hoàng C', genre: 'Lập trình', qty: 0 }
])

const showAddBookModal = () => {
  message.info('Catalog Service (N1) đang hoạt động. Tính năng tạo trực tiếp trên UI admin đang được kết nối!')
}

const editBook = (book: any) => {
  message.success(`Đang mở chỉnh sửa sách: ${book.title}`)
}

const deleteBook = (id: number) => {
  mockBooks.value = mockBooks.value.filter(b => b.id !== id)
  message.success('Xóa sách thành công khỏi Catalog!')
}

// Admin - Cấu hình Quy tắc mượn trả
const rulesState = reactive({
  maxBorrowLimit: 5,
  maxBorrowDays: 14,
  penaltyPerDay: 5000,
  gracePeriod: 0
})

const saveRules = () => {
  message.loading('Đang đồng bộ cấu hình sang Circulation Service (N2)...', 1)
  setTimeout(() => {
    message.success('Đã lưu cấu hình quy tắc mượn trả thành công!')
  }, 1000)
}

// Librarian - Xử lý Phiếu mượn trả
const mockLoans = ref([
  { id: 1, code: 'PH-9921', readerName: 'Lê Thùy Dung', cardNo: 'LIB-577064', bookTitle: 'Clean Code - Mã Sạch', requestDate: '18/05/2026', status: 'Chờ duyệt' },
  { id: 2, code: 'PH-9922', readerName: 'Nguyễn Hoàng Nam', cardNo: 'LIB-128941', bookTitle: 'Lập Trình Hướng Đối Tượng C#', requestDate: '17/05/2026', status: 'Chờ duyệt' },
  { id: 3, code: 'PH-9810', readerName: 'Phạm Minh Đức', cardNo: 'LIB-338291', bookTitle: 'Javascript Nâng Cao', requestDate: '15/05/2026', status: 'Đã phê duyệt' }
])

const approveLoan = (id: number) => {
  const loan = mockLoans.value.find(l => l.id === id)
  if (loan) {
    loan.status = 'Đã phê duyệt'
    message.success(`Đã phê duyệt cho Độc giả ${loan.readerName} mượn sách!`)
  }
}

const rejectLoan = (id: number) => {
  const loan = mockLoans.value.find(l => l.id === id)
  if (loan) {
    loan.status = 'Từ chối'
    message.warning(`Đã từ chối phiếu mượn của ${loan.readerName}.`)
  }
}

// Librarian - Tra cứu tình trạng
const searchCardNo = ref('')
const searchResult = ref<any>(null)

const handleSearchCard = () => {
  if (!searchCardNo.value) {
    message.error('Vui lòng nhập mã thẻ để tra cứu!')
    return
  }
  
  message.loading('Đang tra cứu cơ sở dữ liệu...', 0.5)
  setTimeout(() => {
    searchResult.value = {
      name: 'Lê Thùy Dung',
      cardNo: searchCardNo.value,
      borrowedBooks: 2,
      overdueBooks: 0,
      penaltyAmt: 0,
      activeLoans: [
        { title: 'Clean Code - Mã Sạch', dueDate: '01/06/2026', status: 'active' },
        { title: 'Kiến Trúc Microservices Thực Tế', dueDate: '25/05/2026', status: 'active' }
      ]
    }
    message.success('Tìm thấy thông tin độc giả!')
  }, 500)
}

// Librarian - Xác nhận trả sách
const returnStep = ref(1)
const returnBookCode = ref('')
const bookCondition = reactive({
  intact: true,
  clean: true,
  noLate: true
})

const handleConfirmReturn = () => {
  returnStep.value = 3
}

const resetReturnWizard = () => {
  returnStep.value = 1
  returnBookCode.value = ''
  bookCondition.intact = true
  bookCondition.clean = true
  bookCondition.noLate = true
}

// Report Data call
const fetchDashboardData = async () => {
  if (!accessToken.value) return
  
  loading.value = true
  try {
    const response = await axios.get('http://localhost:5208/api/Report/dashboard', {
      headers: {
        Authorization: `Bearer ${accessToken.value}`
      }
    })
    stats.value = response.data
  } catch (error: any) {
    console.error('Fetch Dashboard Error:', error)
    // Fallback with zeros - real data loads when backend is online
    stats.value = {
      UserStats: { TotalUsers: 0, ActiveUsers: 0, InactiveUsers: 0 },
      CardStats: { TotalCards: 0, ActiveCards: 0, LockedCards: 0, ExpiredCards: 0 },
      MonthlyBorrowStats: [],
      TopPopularBooks: []
    }
  } finally {
    loading.value = false
  }
}

// ----- Detail Modals State -----
const showReadersModal = ref(false)
const showCardsModal = ref(false)
const showBorrowsModal = ref(false)
const showBooksModal = ref(false)
const detailLoading = ref(false)
const readersList = ref<any[]>([])
const cardsList = ref<any[]>([])

const formatDate = (dateStr: string) => {
  if (!dateStr) return '-'
  const d = new Date(dateStr)
  return d.toLocaleDateString('vi-VN')
}

// Helper: handle both camelCase (from .NET JSON) and PascalCase
const getUserStat = (key: string) => {
  if (!stats.value) return 0
  const us = stats.value.UserStats || stats.value.userStats
  if (!us) return 0
  const camelKey = key.charAt(0).toLowerCase() + key.slice(1)
  return us[key] ?? us[camelKey] ?? 0
}

const getCardStat = (key: string) => {
  if (!stats.value) return 0
  const cs = stats.value.CardStats || stats.value.cardStats
  if (!cs) return 0
  const camelKey = key.charAt(0).toLowerCase() + key.slice(1)
  return cs[key] ?? cs[camelKey] ?? 0
}

const readersSearchQuery = ref('')
const readersStatusFilter = ref('all')
const cardsSearchQuery = ref('')
const cardsStatusFilter = ref('all')

const filteredReaders = computed(() => {
  if (!readersList.value) return []
  return readersList.value.filter((r: any) => {
    const name = (r.FullName || r.fullName || '').toLowerCase()
    const email = (r.Email || r.email || '').toLowerCase()
    const username = (r.Username || r.username || '').toLowerCase()
    const q = readersSearchQuery.value.toLowerCase()
    
    const matchesSearch = name.includes(q) || email.includes(q) || username.includes(q)
    
    const isActive = r.IsActive ?? r.isActive ?? false
    let matchesStatus = true
    if (readersStatusFilter.value === 'active') {
      matchesStatus = isActive === true
    } else if (readersStatusFilter.value === 'inactive') {
      matchesStatus = isActive === false
    }
    
    return matchesSearch && matchesStatus
  })
})

const filteredCards = computed(() => {
  if (!cardsList.value) return []
  return cardsList.value.filter((c: any) => {
    const cardNum = (c.CardNumber || c.cardNumber || '').toLowerCase()
    const owner = (c.OwnerName || c.ownerName || '').toLowerCase()
    const q = cardsSearchQuery.value.toLowerCase()
    
    const matchesSearch = cardNum.includes(q) || owner.includes(q)
    
    const status = (c.Status || c.status || '').toLowerCase()
    let matchesStatus = true
    if (cardsStatusFilter.value === 'active') {
      matchesStatus = status === 'active'
    } else if (cardsStatusFilter.value === 'locked') {
      matchesStatus = status === 'locked'
    } else if (cardsStatusFilter.value === 'expired') {
      matchesStatus = status === 'expired'
    }
    
    return matchesSearch && matchesStatus
  })
})

const toggleUserStatus = async (user: any) => {
  message.loading('Đang cập nhật trạng thái người dùng...', 0.5)
  try {
    const res = await axios.put(`http://localhost:5208/api/User/users/${user.Id || user.id}/toggle-status`, {}, {
      headers: { Authorization: `Bearer ${accessToken.value}` }
    })
    message.success(res.data.Message || 'Cập nhật trạng thái thành công!')
    if (user.IsActive !== undefined) user.IsActive = !user.IsActive
    if (user.isActive !== undefined) user.isActive = !user.isActive
    
    // Sync overview stats
    if (stats.value && stats.value.UserStats) {
      stats.value.UserStats.ActiveUsers = readersList.value.filter((r: any) => r.IsActive || r.isActive).length
    }
  } catch (err: any) {
    console.error(err)
    message.error(err.response?.data?.Message || 'Cập nhật trạng thái thất bại!')
  }
}

const toggleCardStatus = async (card: any) => {
  const newStatus = (card.Status || card.status) === 'Active' ? 'Locked' : 'Active'
  message.loading('Đang cập nhật trạng thái thẻ...', 0.5)
  try {
    const res = await axios.put(`http://localhost:5208/api/User/cards/${card.CardNumber || card.cardNumber}/status`, {
      status: newStatus
    }, {
      headers: { Authorization: `Bearer ${accessToken.value}` }
    })
    message.success(res.data.Message || 'Cập nhật trạng thái thẻ thành công!')
    card.Status = newStatus
    card.status = newStatus
    
    // Sync overview stats
    if (stats.value && stats.value.CardStats) {
      stats.value.CardStats.ActiveCards = cardsList.value.filter((c: any) => (c.Status || c.status) === 'Active').length
    }
  } catch (err: any) {
    console.error(err)
    message.error(err.response?.data?.Message || 'Cập nhật trạng thái thẻ thất bại!')
  }
}

const formatCardNumber = (numStr: string) => {
  if (!numStr) return 'LIB - XXXX - XXXX'
  const cleaned = numStr.replace(/-/g, ' ')
  return cleaned.toUpperCase()
}

const fetchReadersData = async () => {
  detailLoading.value = true
  try {
    const res = await axios.get('http://localhost:5208/api/User/readers', {
      headers: { Authorization: `Bearer ${accessToken.value}` }
    })
    readersList.value = res.data
    if (stats.value && stats.value.UserStats) {
      stats.value.UserStats.TotalUsers = res.data.length
      stats.value.UserStats.ActiveUsers = res.data.filter((r: any) => r.IsActive || r.isActive).length
    }
  } catch (err) {
    console.error('Fetch readers error:', err)
    readersList.value = []
  } finally {
    detailLoading.value = false
  }
}

const fetchCardsData = async () => {
  detailLoading.value = true
  try {
    const res = await axios.get('http://localhost:5208/api/User/cards', {
      headers: { Authorization: `Bearer ${accessToken.value}` }
    })
    cardsList.value = res.data
    if (stats.value && stats.value.CardStats) {
      stats.value.CardStats.TotalCards = res.data.length
      stats.value.CardStats.ActiveCards = res.data.filter((c: any) => (c.Status || c.status) === 'Active').length
    }
  } catch (err) {
    console.error('Fetch cards error:', err)
    cardsList.value = []
  } finally {
    detailLoading.value = false
  }
}

const openDetailModal = (type: string) => {
  if (type === 'readers') {
    switchTab('readers-list')
  } else if (type === 'cards') {
    switchTab('cards-list')
  } else if (type === 'borrows') {
    showBorrowsModal.value = true
  } else if (type === 'books') {
    showBooksModal.value = true
  }
}

onMounted(() => {
  if (!isAuthorized.value) {
    message.error('Bạn cần tài khoản Admin hoặc Thủ thư để xem trang này!')
    setTimeout(() => {
      router.push('/')
    }, 2000)
  } else {
    fetchDashboardData()
  }
})
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Outfit:wght@300;400;500;600;700&family=Inter:wght@300;400;500;600;700&display=swap');

.dashboard-container {
  display: flex;
  min-height: 100vh;
  /* Perfect mix-match with general application background #FAF9F6 */
  background-color: #FAF9F6;
  font-family: 'Outfit', 'Inter', sans-serif;
  color: #2d3748;
  overflow-x: hidden;
}

/* Access Denied Overlay */
.access-denied {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100vw;
  height: 100vh;
  background: rgba(255, 255, 255, 0.9);
  position: fixed;
  top: 0;
  left: 0;
  z-index: 9999;
}

.denied-card {
  background: white;
  border: 1px solid rgba(0,0,0,0.1);
  padding: 40px;
  border-radius: 24px;
  text-align: center;
  max-width: 480px;
  box-shadow: 0 20px 40px rgba(0,0,0,0.05);
}

.denied-icon {
  font-size: 64px;
  margin-bottom: 20px;
}

.denied-card h2 {
  font-weight: 700;
  color: #1E5652;
}

.btn-home {
  background-color: #CF7C07 !important;
  border-color: #CF7C07 !important;
  border-radius: 20px !important;
  font-weight: 600 !important;
  height: auto !important;
}

/* LEFT SIDEBAR (Aligned perfectly with official primary Teal color #1E5652) */
.dashboard-sidebar {
  width: 290px;
  background: #114B44; /* Official deep theme background */
  border-right: 1px solid rgba(255, 255, 255, 0.08);
  padding: 40px 24px 30px 24px;
  display: flex;
  flex-direction: column;
  color: #FAF9F6;
  flex-shrink: 0;
}

.sidebar-profile {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  margin-bottom: 40px;
  border-bottom: 1px solid rgba(255, 255, 255, 0.08);
  padding-bottom: 25px;
}

.profile-avatar {
  width: 76px;
  height: 76px;
  border-radius: 50%;
  background: linear-gradient(135deg, #CF7C07 0%, #1E5652 100%);
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 15px;
  border: 3px solid rgba(250, 249, 246, 0.15);
  box-shadow: 0 10px 20px rgba(17, 75, 68, 0.3);
}

.avatar-emoji {
  font-size: 36px;
}

.profile-name {
  font-size: 18px;
  font-weight: 700;
  color: #ffffff;
  margin: 0 0 4px 0;
  letter-spacing: 0.5px;
}

.profile-email {
  font-size: 12px;
  color: rgba(250, 249, 246, 0.5);
  margin: 0;
}

.menu-group-label {
  font-size: 10px;
  color: rgba(250, 249, 246, 0.3);
  font-weight: 800;
  letter-spacing: 1.5px;
  margin: 20px 0 10px 10px;
}

.sidebar-menu {
  display: flex;
  flex-direction: column;
  gap: 8px;
  flex-grow: 1;
}

.menu-item {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 14px 20px;
  border-radius: 16px;
  color: rgba(250, 249, 246, 0.65);
  font-weight: 600;
  font-size: 14px;
  transition: all 0.3s ease;
  cursor: pointer;
}

.menu-item:hover {
  background: rgba(250, 249, 246, 0.05);
  color: #CF7C07;
}

.menu-item.active {
  background: #FAF9F6 !important;
  color: #114B44 !important;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.05);
  font-weight: 700;
}

.sidebar-footer {
  border-top: 1px solid rgba(250, 249, 246, 0.08);
  padding-top: 25px;
  display: flex;
  flex-direction: column;
  gap: 15px;
}

.role-badge-container {
  display: flex;
  justify-content: center;
}

.role-tag {
  font-size: 11px;
  padding: 4px 12px;
  border-radius: 20px;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.role-tag.admin {
  background-color: rgba(207, 124, 7, 0.15);
  color: #CF7C07;
  border: 1px solid rgba(207, 124, 7, 0.3);
}

.role-tag.librarian {
  background-color: rgba(30, 86, 82, 0.2);
  color: #CBE0DE;
  border: 1px solid rgba(30, 86, 82, 0.3);
}

.btn-logout {
  background: transparent;
  border: 1.5px solid rgba(250, 249, 246, 0.15);
  color: rgba(250, 249, 246, 0.65);
  padding: 12px;
  border-radius: 16px;
  font-weight: 700;
  font-size: 13px;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
  transition: all 0.3s ease;
}

.btn-logout:hover {
  background: rgba(255, 91, 91, 0.15);
  color: #ff5b5b;
  border-color: rgba(255, 91, 91, 0.3);
}

/* MAIN CONTENT AREA (Harmonized background aligned with system Ivory #FAF9F6) */
.dashboard-main {
  flex-grow: 1;
  padding: 40px;
  overflow-y: auto;
  max-height: 100vh;
  display: flex;
  flex-direction: column;
  gap: 30px;
  background-color: #FAF9F6;
}

/* TOP BAR (Layout from Nirmal design reference) */
.dashboard-topbar {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: #ffffff;
  padding: 16px 30px;
  border-radius: 20px;
  box-shadow: 0 4px 20px rgba(0,0,0,0.015);
  border: 1.5px solid rgba(30, 86, 82, 0.05);
}

.welcome-text h2 {
  font-weight: 700;
  font-size: 22px;
  color: #114B44;
  margin: 0;
}

.topbar-actions {
  display: flex;
  align-items: center;
  gap: 15px;
}

.search-box-pill {
  display: flex;
  align-items: center;
  background: #F4F3ED; /* Matches off-white cream background */
  border-radius: 20px;
  padding: 8px 16px;
  gap: 8px;
  width: 260px;
  border: 1px solid rgba(0, 0, 0, 0.03);
}

.search-box-pill input {
  border: none;
  background: transparent;
  outline: none;
  font-size: 13px;
  color: #4b5563;
  width: 100%;
}

.action-icon-btn {
  width: 38px;
  height: 38px;
  border-radius: 50%;
  background: #F4F3ED;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  transition: all 0.2s ease;
  font-size: 16px;
  color: #1E5652;
}

.action-icon-btn:hover {
  background: #e5e7eb;
}

/* CONTENT HEADER */
.content-header-row {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;
}

.content-header-row h3 {
  font-size: 20px;
  font-weight: 700;
  color: #114B44;
  margin: 0;
}

.year-badge {
  font-size: 13px;
  font-weight: 700;
  color: #CF7C07;
  background: rgba(207, 124, 7, 0.1);
  padding: 4px 12px;
  border-radius: 12px;
}

/* OVER VIEW CARDS (Cohesive brand colors) */
.overview-cards-row {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 20px;
  margin-bottom: 10px;
}

.ov-card {
  background: #ffffff;
  border-radius: 20px;
  padding: 24px;
  display: flex;
  align-items: center;
  gap: 20px;
  box-shadow: 0 8px 24px rgba(0,0,0,0.01);
  position: relative;
  transition: all 0.3s ease;
  border: 1.5px solid rgba(30, 86, 82, 0.05);
}

.ov-card.clickable {
  cursor: pointer;
}

.ov-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 12px 30px rgba(0,0,0,0.02);
}

.ov-card.brand-border { border-left: 4px solid #1E5652; }

/* Highlighted card exactly matching the reference outline look but in SmartLib Warm Gold */
.ov-card.gold-highlight {
  border: 1.5px solid rgba(207, 124, 7, 0.3);
  background: #fffdf9;
}

.ov-icon-wrapper {
  width: 54px;
  height: 54px;
  border-radius: 14px;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 26px;
}

.teal-bg { background: rgba(30, 86, 82, 0.08); color: #1E5652; }
.gold-bg { background: rgba(207, 124, 7, 0.1); color: #CF7C07; }

.ov-value {
  font-size: 26px;
  font-weight: 700;
  color: #114B44;
  line-height: 1.2;
}

.ov-label {
  font-size: 13px;
  color: #6C7A78;
  font-weight: 600;
}

.info-tooltip {
  position: absolute;
  top: 10px;
  right: 12px;
  width: 16px;
  height: 16px;
  border-radius: 50%;
  background: rgba(0,0,0,0.03);
  color: #718096;
  font-size: 10px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  font-weight: bold;
}

/* GRAPHICS GRID */
.graphics-grid {
  display: grid;
  grid-template-columns: 1.3fr 1fr;
  gap: 25px;
}

.graphics-left-col {
  display: flex;
  flex-direction: column;
  gap: 25px;
}

.mid-panels-row {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 25px;
}

.white-panel {
  background: #ffffff;
  border-radius: 20px;
  padding: 24px;
  box-shadow: 0 8px 24px rgba(0,0,0,0.01);
  border: 1.5px solid rgba(30, 86, 82, 0.05);
}

.white-panel h4 {
  font-size: 16px;
  font-weight: 700;
  color: #114B44;
  margin: 0 0 20px 0;
}

/* User Count Panel */
.user-stats-visual {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 20px 0;
}

.user-icon-circle {
  width: 50px;
  height: 50px;
  border-radius: 50%;
  background: rgba(30, 86, 82, 0.08);
  color: #1E5652;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 22px;
  margin-bottom: 12px;
}

.large-number {
  font-size: 32px;
  font-weight: 700;
  color: #114B44;
}

.sub-label {
  font-size: 12px;
  color: #6C7A78;
  font-weight: 600;
}

/* Donut Panel */
.pie-chart-container {
  display: flex;
  align-items: center;
  gap: 20px;
  justify-content: center;
}

.svg-pie {
  position: relative;
  width: 90px;
  height: 90px;
}

.circular-chart {
  display: block;
  width: 100%;
  height: 100%;
}

.circle-bg {
  fill: none;
  stroke: #F4F3ED;
  stroke-width: 3.8;
}

.circle {
  fill: none;
  stroke: #1E5652;
  stroke-width: 3.8;
  stroke-linecap: round;
  transition: stroke-dasharray 0.3s ease;
}

.pie-percentage {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  font-weight: 700;
  font-size: 16px;
  color: #114B44;
}

.pie-legend {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.legend-item {
  font-size: 12px;
  font-weight: 700;
  color: #5c6765;
  display: flex;
  align-items: center;
  gap: 6px;
}

.legend-item .dot {
  width: 8px;
  height: 8px;
  border-radius: 50%;
}

.legend-item .dot.active { background: #1E5652; }
.legend-item .dot.locked { background: #F4F3ED; border: 1px solid rgba(0,0,0,0.05); }

/* Area Chart Panel */
.area-chart-panel {
  position: relative;
}

.chart-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;
}

.chart-header h4 { margin: 0; }

.svg-area-chart-container {
  position: relative;
  width: 100%;
}

.area-chart-svg {
  width: 100%;
  height: auto;
}

/* Indicators styled professionally */
.indicator-tag {
  position: absolute;
  padding: 4px 8px;
  border-radius: 6px;
  font-size: 10px;
  font-weight: 700;
  color: white;
  box-shadow: 0 5px 10px rgba(0,0,0,0.1);
}

.indicator-tag.peak {
  background: #CF7C07;
}

.indicator-tag.active-tag {
  background: #1E5652;
}

.chart-months {
  display: flex;
  justify-content: space-between;
  margin-top: 10px;
  padding: 0 10px;
}

.chart-months span {
  font-size: 11px;
  color: #6C7A78;
  font-weight: 700;
}

/* Horizontal progress bars style (Exactly matching reference right column but using brand green/gold shades) */
.horizontal-bars-panel {
  height: 100%;
  display: flex;
  flex-direction: column;
}

.hbar-list {
  display: flex;
  flex-direction: column;
  gap: 20px;
  flex-grow: 1;
  justify-content: space-around;
}

.hbar-item {
  display: flex;
  flex-direction: column;
  gap: 6px;
}

.hbar-label-row {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.book-name {
  font-size: 13px;
  font-weight: 700;
  color: #114B44;
}

.book-qty {
  font-size: 12px;
  font-weight: 700;
  color: #6C7A78;
}

.progress-track {
  width: 100%;
  height: 8px;
  background: #F4F3ED;
  border-radius: 10px;
  overflow: hidden;
}

.progress-bar {
  height: 100%;
  border-radius: 10px;
}

.bar-teal-primary { background: #1E5652; }
.bar-gold { background: #CF7C07; }
.bar-teal-secondary { background: rgba(30, 86, 82, 0.7); }
.bar-teal-muted { background: rgba(30, 86, 82, 0.4); }
.bar-gold-muted { background: rgba(207, 124, 7, 0.4); }

/* Brand Aligned Table */
.pastel-table {
  width: 100%;
  border-collapse: collapse;
}

.pastel-table th {
  background: rgba(30, 86, 82, 0.04);
  text-align: left;
  padding: 16px;
  font-weight: 700;
  color: #1E5652;
  border-bottom: 1.5px solid rgba(30, 86, 82, 0.1);
}

.pastel-table td {
  padding: 16px;
  border-bottom: 1px solid rgba(0,0,0,0.03);
  font-size: 14px;
}

.pastel-table tr:hover {
  background: rgba(30, 86, 82, 0.02);
}

.btn-action-pastel {
  background: linear-gradient(135deg, #1E5652 0%, #CF7C07 100%) !important;
  border: none !important;
  color: #FAF9F6 !important;
  font-weight: 700 !important;
  border-radius: 20px !important;
  height: auto !important;
  padding: 8px 24px !important;
  box-shadow: 0 6px 15px rgba(30, 86, 82, 0.15) !important;
}

.btn-action-pastel:hover {
  transform: translateY(-2px);
  box-shadow: 0 10px 20px rgba(30, 86, 82, 0.2) !important;
}

.genre-badge {
  background: rgba(30, 86, 82, 0.08);
  color: #1E5652;
  padding: 4px 10px;
  border-radius: 8px;
  font-size: 11px;
  font-weight: 700;
}

.status-badge {
  font-size: 11px;
  font-weight: 700;
  padding: 4px 10px;
  border-radius: 8px;
}

.status-badge.instock, .status-badge.đã-phê-duyệt {
  background: rgba(46, 204, 113, 0.15);
  color: #27ae60;
}

.status-badge.outstock, .status-badge.chờ-duyệt {
  background: rgba(207, 124, 7, 0.15);
  color: #CF7C07;
}

.status-badge.từ-chối {
  background: rgba(231, 76, 60, 0.15);
  color: #c0392b;
}

.card-number-badge {
  background: rgba(30, 86, 82, 0.05);
  border: 1px solid rgba(30, 86, 82, 0.1);
  font-family: monospace;
  padding: 2px 8px;
  border-radius: 6px;
  font-size: 12px;
  color: #1E5652;
  font-weight: bold;
}

/* Custom Buttons for inline actions */
.btn-edit-inline, .btn-delete-inline, .btn-approve, .btn-reject {
  border: none;
  background: rgba(0,0,0,0.03);
  padding: 6px 12px;
  border-radius: 8px;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s ease;
}

.btn-edit-inline:hover { background: rgba(30, 86, 82, 0.1); }
.btn-delete-inline:hover { background: rgba(231, 76, 60, 0.1); color: #c0392b; }
.btn-approve { background: rgba(46, 204, 113, 0.15); color: #27ae60; }
.btn-reject { background: rgba(231, 76, 60, 0.1); color: #c0392b; }

.btn-approve:hover { transform: scale(1.05); }
.btn-reject:hover { transform: scale(1.05); }

/* Rules page inputs */
.num-input {
  width: 100% !important;
  background: #ffffff !important;
  border: 1.5px solid rgba(30, 86, 82, 0.15) !important;
  color: #114B44 !important;
  border-radius: 12px !important;
  height: 40px !important;
  display: flex;
  align-items: center;
}

.form-group-custom {
  display: flex;
  flex-direction: column;
  gap: 8px;
  margin-bottom: 20px;
}

.form-group-custom label {
  font-size: 13px;
  font-weight: 700;
  color: #114B44;
}

/* Search Results UI */
.search-input-pill {
  border: 1.5px solid rgba(30, 86, 82, 0.15) !important;
  border-radius: 20px !important;
  height: 45px !important;
}

.btn-search-pill {
  background: linear-gradient(135deg, #1E5652 0%, #CF7C07 100%) !important;
  border: none !important;
  border-radius: 20px !important;
  height: 45px !important;
  font-weight: 700 !important;
}

.search-results-box {
  background: #ffffff;
  border: 1px solid rgba(30, 86, 82, 0.1);
  border-radius: 16px;
  padding: 25px;
  margin-top: 25px;
}

.result-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-bottom: 1.5px solid rgba(30, 86, 82, 0.08);
  padding-bottom: 15px;
  margin-bottom: 20px;
}

.user-info-large h3 { font-size: 18px; font-weight: 700; color: #114B44; }
.user-info-large .card-no { font-family: monospace; font-size: 12px; color: #6C7A78; }

.details-grid-custom {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 15px;
  margin-bottom: 25px;
}

.detail-item-box {
  background: #F4F3ED;
  border: 1px solid rgba(0,0,0,0.02);
  padding: 15px;
  border-radius: 12px;
  display: flex;
  flex-direction: column;
}

.detail-item-box .lbl { font-size: 11px; color: #6C7A78; }
.detail-item-box .val { font-size: 18px; font-weight: 700; color: #114B44; }

.active-loans-list h4 {
  font-size: 13px;
  font-weight: 700;
  color: #114B44;
  margin-bottom: 15px;
}

.loan-item-row {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: #ffffff;
  padding: 12px 18px;
  border-radius: 10px;
  margin-bottom: 8px;
  border: 1.5px solid rgba(30, 86, 82, 0.05);
}

.loan-item-row .title { font-weight: 700; font-size: 13px; color: #114B44; }

/* Return Sách Steps Flow */
.steps-flow {
  display: flex;
  justify-content: space-around;
  margin-bottom: 40px;
}

.step-item {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 8px;
}

.step-num {
  width: 32px;
  height: 32px;
  border-radius: 50%;
  background: #F4F3ED;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: 700;
  color: #6C7A78;
}

.step-txt {
  font-size: 12px;
  font-weight: 700;
  color: #6C7A78;
}

.step-item.completed .step-num {
  background: #1E5652;
  color: white;
}

.step-item.completed .step-txt {
  color: #1E5652;
}

.step-content-box {
  background: #ffffff;
  border: 1.5px solid rgba(30, 86, 82, 0.05);
  padding: 30px;
  border-radius: 16px;
}

.pill-input-custom {
  border: 1.5px solid rgba(30, 86, 82, 0.15) !important;
  border-radius: 12px !important;
  height: 42px !important;
}

.btn-next-step {
  background: linear-gradient(135deg, #1E5652 0%, #CF7C07 100%) !important;
  border: none !important;
  border-radius: 12px !important;
  font-weight: 700 !important;
  height: 42px !important;
}

.checkbox-group-custom {
  display: flex;
  flex-direction: column;
  gap: 15px;
}

.checkbox-group-custom .ant-checkbox-wrapper {
  color: #114B44 !important;
  font-weight: 600;
}

.success-icon-large {
  font-size: 64px;
}

.btn-restart {
  background: #1E5652 !important;
  border: none !important;
  border-radius: 12px !important;
  font-weight: 700 !important;
}

/* Animations */
.animate-fade-in {
  animation: fadeIn 0.4s ease-out;
}

@keyframes fadeIn {
  from { opacity: 0; transform: translateY(10px); }
  to { opacity: 1; transform: translateY(0); }
}

/* Responsive adjustment */
@media (max-width: 1200px) {
  .overview-cards-row { grid-template-columns: repeat(2, 1fr); }
  .graphics-grid { grid-template-columns: 1fr; }
}

@media (max-width: 768px) {
  .dashboard-container { flex-direction: column; }
  .dashboard-sidebar { width: 100%; border-right: none; }
}

/* Detail Modal Styles */
.modal-table {
  width: 100%;
}

.modal-loading,
.modal-empty {
  text-align: center;
  padding: 40px 20px;
  font-size: 15px;
  color: #7a8583;
  font-weight: 600;
}

.modal-pending {
  text-align: center;
  padding: 40px 20px;
}

.modal-pending .pending-icon {
  font-size: 48px;
  margin-bottom: 16px;
}

.modal-pending h3 {
  font-size: 18px;
  font-weight: 700;
  color: #114B44;
  margin-bottom: 8px;
}

.modal-pending p {
  font-size: 13px;
  color: #7a8583;
  line-height: 1.6;
}

/* ==========================================================================
   NEW TABS STYLING (Readers & Realistic Library Cards)
   ========================================================================== */

/* Subtitle Title */
.title-with-subtitle h3 {
  font-size: 22px;
  font-weight: 700;
  color: #114B44;
  margin: 0 0 4px 0;
}
.title-with-subtitle .subtitle-text {
  font-size: 13px;
  color: #6C7A78;
  margin: 0;
}

.stats-pill {
  background: rgba(30, 86, 82, 0.08);
  color: #1E5652;
  font-size: 13px;
  font-weight: 700;
  padding: 6px 16px;
  border-radius: 20px;
  border: 1px solid rgba(30, 86, 82, 0.15);
}

/* Search Filter Panel */
.search-filter-panel {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 20px;
  background: #ffffff;
  padding: 20px 30px;
  border-radius: 20px;
  box-shadow: 0 4px 20px rgba(0,0,0,0.015);
  margin-bottom: 25px;
}

.search-filter-panel .search-input-pill {
  flex-grow: 1;
  max-width: 480px;
  display: flex;
  align-items: center;
  background: #F4F3ED;
  border-radius: 20px;
  padding: 6px 16px;
  gap: 10px;
  border: 1px solid rgba(30, 86, 82, 0.1);
}

.search-filter-panel .search-input-pill input {
  border: none;
  background: transparent;
  outline: none;
  font-size: 14px;
  color: #2d3748;
  width: 100%;
}

.filter-group {
  display: flex;
  align-items: center;
  gap: 10px;
}

.filter-label {
  font-size: 13px;
  font-weight: 700;
  color: #114B44;
}

.custom-select-pill {
  background: #F4F3ED;
  border: 1px solid rgba(30, 86, 82, 0.1);
  padding: 8px 16px;
  border-radius: 20px;
  outline: none;
  font-size: 13px;
  font-weight: 600;
  color: #114B44;
  cursor: pointer;
  transition: all 0.2s ease;
}

.custom-select-pill:hover {
  border-color: #1E5652;
}

/* Loading and Spinner */
.page-loading-spinner-wrapper {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 60px 20px;
  gap: 15px;
}

.spinner-spinner {
  width: 40px;
  height: 40px;
  border: 4px solid rgba(30, 86, 82, 0.1);
  border-left-color: #1E5652;
  border-radius: 50%;
  animation: spin 0.8s linear infinite;
}

@keyframes spin {
  to { transform: rotate(360deg); }
}

.empty-state-card {
  background: white;
  border: 1.5px dashed rgba(30, 86, 82, 0.15);
  border-radius: 24px;
  padding: 50px 30px;
  text-align: center;
  max-width: 500px;
  margin: 40px auto;
}

.empty-icon {
  font-size: 54px;
  margin-bottom: 15px;
}

.empty-state-card h4 {
  font-size: 18px;
  font-weight: 700;
  color: #114B44;
  margin: 0 0 8px 0;
}

.empty-state-card p {
  font-size: 14px;
  color: #6C7A78;
  margin: 0;
}

/* Readers Grid Layout */
.readers-grid-layout {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
  gap: 25px;
  margin-top: 10px;
}

.reader-card-new {
  background: white;
  border-radius: 20px;
  border: 1.5px solid rgba(30, 86, 82, 0.05);
  box-shadow: 0 10px 25px rgba(0,0,0,0.015);
  overflow: hidden;
  position: relative;
  transition: all 0.3s cubic-bezier(0.25, 0.8, 0.25, 1);
  display: flex;
  flex-direction: column;
}

.reader-card-new:hover {
  transform: translateY(-5px);
  box-shadow: 0 15px 35px rgba(30, 86, 82, 0.08);
  border-color: rgba(30, 86, 82, 0.15);
}

.reader-card-top-decoration {
  height: 60px;
  background: linear-gradient(135deg, #114B44 0%, #1E5652 100%);
}

.reader-card-avatar-wrapper {
  position: absolute;
  top: 25px;
  left: 50%;
  transform: translateX(-50%);
}

.avatar-ring {
  width: 70px;
  height: 70px;
  border-radius: 50%;
  background: #ffffff;
  border: 3.5px solid #ffffff;
  box-shadow: 0 6px 15px rgba(0,0,0,0.1);
  display: flex;
  justify-content: center;
  align-items: center;
}

.avatar-ring .avatar-emoji {
  font-size: 34px;
}

.reader-card-body {
  padding: 50px 24px 20px 24px;
  text-align: center;
  flex-grow: 1;
}

.reader-card-name {
  font-size: 17px;
  font-weight: 700;
  color: #114B44;
  margin: 0 0 2px 0;
}

.reader-card-username {
  font-size: 13px;
  color: #CF7C07;
  font-weight: 600;
  display: inline-block;
  margin-bottom: 20px;
}

.reader-card-meta {
  display: flex;
  flex-direction: column;
  gap: 10px;
  text-align: left;
  border-top: 1px solid rgba(30, 86, 82, 0.06);
  padding-top: 15px;
}

.meta-item {
  display: flex;
  align-items: center;
  gap: 10px;
}

.meta-item .m-icon {
  font-size: 15px;
}

.meta-item .m-text {
  font-size: 13px;
  color: #4A5568;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 100%;
}

.reader-card-footer {
  padding: 16px 24px;
  background: #FDFDFB;
  border-top: 1px solid rgba(30, 86, 82, 0.05);
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.btn-action-small {
  border: none;
  padding: 6px 14px;
  border-radius: 12px;
  font-size: 12px;
  font-weight: 700;
  cursor: pointer;
  transition: all 0.2s ease;
}

.btn-action-small.btn-lock {
  background: rgba(231, 76, 60, 0.1);
  color: #e74c3c;
}

.btn-action-small.btn-lock:hover {
  background: #e74c3c;
  color: white;
}

.btn-action-small.btn-unlock {
  background: rgba(46, 204, 113, 0.1);
  color: #2ecc71;
}

.btn-action-small.btn-unlock:hover {
  background: #2ecc71;
  color: white;
}

/* Cards Grid Layout */
.cards-grid-layout {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(330px, 1fr));
  gap: 30px;
  margin-top: 10px;
}

/* REALISTIC CREDIT CARD */
.library-credit-card {
  perspective: 1000px;
  position: relative;
  border-radius: 20px;
  overflow: hidden;
  box-shadow: 0 10px 30px rgba(0,0,0,0.06);
  transition: all 0.4s cubic-bezier(0.165, 0.84, 0.44, 1);
  aspect-ratio: 1.586;
  background-size: cover;
  border: 1px solid rgba(255,255,255,0.1);
}

.library-credit-card:hover {
  transform: translateY(-8px) scale(1.02);
  box-shadow: 0 20px 40px rgba(17, 75, 68, 0.15);
}

/* Realistic Credit Card Colors depending on status */
.library-credit-card.active {
  background: linear-gradient(135deg, #114B44 0%, #1E5652 45%, #2D8A80 100%);
}

.library-credit-card.locked {
  background: linear-gradient(135deg, #4A0E17 0%, #7B1113 45%, #A81C1C 100%);
}

.library-credit-card.expired {
  background: linear-gradient(135deg, #2D3748 0%, #4A5568 50%, #718096 100%);
}

.card-inner-glass {
  width: 100%;
  height: 100%;
  padding: 24px;
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  background: rgba(255, 255, 255, 0.03);
  backdrop-filter: blur(4px);
  -webkit-backdrop-filter: blur(4px);
}

.card-header-row {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.card-brand-logo {
  font-size: 18px;
  font-weight: 800;
  color: #ffffff;
  letter-spacing: 0.5px;
  text-shadow: 0 2px 4px rgba(0,0,0,0.2);
}

.card-status-dot-badge {
  font-size: 11px;
  font-weight: 700;
  color: #ffffff;
  background: rgba(255, 255, 255, 0.15);
  padding: 4px 10px;
  border-radius: 12px;
  display: flex;
  align-items: center;
  gap: 6px;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.pulse-dot {
  width: 7px;
  height: 7px;
  border-radius: 50%;
  background: #2ecc71;
  display: inline-block;
  box-shadow: 0 0 8px #2ecc71;
}

.library-credit-card.locked .pulse-dot {
  background: #e74c3c;
  box-shadow: 0 0 8px #e74c3c;
}

.library-credit-card.expired .pulse-dot {
  background: #f1c40f;
  box-shadow: 0 0 8px #f1c40f;
}

/* Metallic gold chip */
.card-chip-row {
  display: flex;
  align-items: center;
  gap: 15px;
  margin-top: 10px;
}

.gold-chip {
  width: 44px;
  height: 32px;
  background: linear-gradient(135deg, #f5d061 0%, #e6b31e 50%, #c4960d 100%);
  border-radius: 6px;
  box-shadow: inset 0 1px 1px rgba(255,255,255,0.3), 0 2px 4px rgba(0,0,0,0.1);
  position: relative;
}

.gold-chip::before {
  content: '';
  position: absolute;
  top: 4px;
  left: 6px;
  right: 6px;
  bottom: 4px;
  border: 1px solid rgba(0,0,0,0.12);
  border-radius: 4px;
}

.wifi-icon {
  color: rgba(255, 255, 255, 0.6);
  font-size: 16px;
}

/* Card NumberDisplay */
.card-number-display {
  font-family: monospace;
  font-size: 19px;
  color: #ffffff;
  letter-spacing: 2px;
  margin: 15px 0;
  text-shadow: 0 2px 4px rgba(0, 0, 0, 0.3);
  font-weight: 600;
}

.card-details-row {
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
}

.detail-col {
  display: flex;
  flex-direction: column;
  gap: 2px;
}

.detail-lbl {
  font-size: 9px;
  color: rgba(255, 255, 255, 0.5);
  font-weight: 700;
  letter-spacing: 1px;
}

.detail-val {
  font-size: 13px;
  color: #ffffff;
  font-weight: 700;
  letter-spacing: 0.5px;
  text-shadow: 0 1px 2px rgba(0,0,0,0.2);
}

.text-right {
  text-align: right;
}

/* Card action panel displayed directly under the realistic credit card */
.card-action-underlay {
  background: white;
  padding: 16px 20px;
  border-top: 1px solid rgba(30, 86, 82, 0.05);
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-radius: 0 0 20px 20px;
  margin-top: -20px; /* Overlaps card container bottom nicely */
  z-index: 1;
  position: relative;
  box-shadow: 0 8px 20px rgba(0,0,0,0.02);
}

/* Adjust card container gap to show action underlay perfectly */
.cards-grid-layout > div {
  display: flex;
  flex-direction: column;
}

.issue-date-label {
  font-size: 11px;
  color: #6C7A78;
  font-weight: 600;
}

.btn-action-card-toggle {
  border: none;
  background: #F4F3ED;
  color: #114B44;
  padding: 6px 12px;
  border-radius: 12px;
  font-size: 11px;
  font-weight: 700;
  cursor: pointer;
  transition: all 0.2s ease;
  border: 1px solid rgba(30, 86, 82, 0.08);
}

.btn-action-card-toggle:hover {
  background: #114B44;
  color: white;
  border-color: #114B44;
}
</style>
