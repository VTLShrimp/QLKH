<template>
  <div class="home-container">
    <div class="hero-section">
      <h1>Hệ Thống Quản Lý Kho Hàng</h1>

      <div class="action-buttons">
        <router-link to="/login" class="login-btn">Đăng nhập</router-link>
        <router-link to="/register" class="register-btn">Đăng ký</router-link>
      </div>
    </div>

    <div class="features-section">
      <div class="feature">
        <div class="feature-icon">
          <i class="fas fa-users"></i>
        </div>
        <h3>Quản lý khách hàng</h3>
        <p>Lưu trữ và quản lý thông tin khách hàng một cách hiệu quả</p>
      </div>

      <div class="feature">
        <div class="feature-icon">
          <i class="fas fa-chart-line"></i>
        </div>
        <h3>Phân tích dữ liệu</h3>
        <p>Báo cáo và thống kê chuyên sâu về hoạt động kinh doanh</p>
      </div>

      <div class="feature">
        <div class="feature-icon">
          <i class="fas fa-tasks"></i>
        </div>
        <h3>Quản lý kho</h3>
        <p>Theo dõi và quản lý các nhiệm vụ liên quan đến kho</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HomeView",
  components: {},
  data() {
    return {
      isLoggedIn: false,
    };
  },
  methods: {
    checkLoginStatus() {
      // Kiểm tra trạng thái đăng nhập của người dùng
      // Ví dụ: kiểm tra token trong localStorage
      const token = localStorage.getItem("token");
      this.isLoggedIn = !!token;
    },
  },
  mounted() {
    this.checkLoginStatus();
  },
};
</script>

<style scoped>
.home-container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
}

.hero-section {
  text-align: center;
  padding: 4rem 1rem;
  background-color: #f9f9f9;
  border-radius: 8px;
  margin-bottom: 3rem;
}

.hero-section h1 {
  font-size: 2.5rem;
  color: #333;
  margin-bottom: 1rem;
}

.hero-section p {
  font-size: 1.2rem;
  color: #666;
  margin-bottom: 2rem;
}

.action-buttons {
  display: flex;
  justify-content: center;
  gap: 1rem;
}

.login-btn,
.register-btn {
  display: inline-block;
  padding: 0.8rem 1.5rem;
  border-radius: 4px;
  text-decoration: none;
  font-weight: bold;
  transition: all 0.3s ease;
}

.login-btn {
  background-color: #4caf50;
  color: white;
}

.login-btn:hover {
  background-color: #45a049;
}

.register-btn {
  background-color: transparent;
  color: #4caf50;
  border: 1px solid #4caf50;
}

.register-btn:hover {
  background-color: #f0f8f0;
}

.features-section {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 2rem;
}

.feature {
  padding: 1.5rem;
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
  text-align: center;
  transition: transform 0.3s ease;
}

.feature:hover {
  transform: translateY(-5px);
}

.feature-icon {
  font-size: 2rem;
  color: #4caf50;
  margin-bottom: 1rem;
}

.feature h3 {
  font-size: 1.2rem;
  margin-bottom: 0.5rem;
  color: #333;
}

.feature p {
  color: #666;
}

@media (max-width: 768px) {
  .hero-section h1 {
    font-size: 2rem;
  }

  .hero-section p {
    font-size: 1rem;
  }

  .features-section {
    grid-template-columns: 1fr;
  }
}
</style>
