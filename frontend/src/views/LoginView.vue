<template>
  <div class="login-container">
    <div class="login-form">
      <h1 class="login-title">Đăng nhập</h1>

      <div v-if="errorMessage" class="error-message">
        {{ errorMessage }}
      </div>

      <div class="form-group">
        <label for="username">Tên đăng nhập</label>
        <input
          type="text"
          id="username"
          v-model="loginForm.userName"
          placeholder="Nhập tên đăng nhập"
          @keyup.enter="login"
        />
      </div>

      <div class="form-group">
        <label for="password">Mật khẩu</label>
        <input
          type="password"
          id="password"
          v-model="loginForm.password"
          placeholder="Nhập mật khẩu"
          @keyup.enter="login"
        />
      </div>

      <div class="form-actions">
        <button class="login-button" @click="login" :disabled="isLoading">
          <span v-if="isLoading">Đang xử lý...</span>
          <span v-else>Đăng nhập</span>
        </button>
      </div>

      <div class="form-footer">
        <router-link to="/register" class="register-link"
          >Chưa có tài khoản? Đăng ký ngay</router-link
        >
        <router-link to="/forgot-password" class="forgot-password-link"
          >Quên mật khẩu?</router-link
        >
      </div>
    </div>
  </div>
</template>

<script>
import authApi from "@/api/auth.api";

export default {
  name: "LoginView",
  data() {
    return {
      loginForm: {
        userName: "",
        password: "",
      },
      isLoading: false,
      errorMessage: "",
    };
  },
  methods: {
    async login() {
      // Validate form
      if (!this.loginForm.userName || !this.loginForm.password) {
        this.errorMessage = "Vui lòng nhập đầy đủ thông tin đăng nhập";
        return;
      }

      try {
        this.isLoading = true;
        this.errorMessage = "";

        const response = await authApi.login(this.loginForm);

        // Lưu thông tin người dùng và token vào localStorage
        localStorage.setItem("token", response.token);
        localStorage.setItem("user", JSON.stringify(response.user));

        // Chuyển hướng đến trang dashboard hoặc trang chính
        this.$router.push("/");
      } catch (error) {
        console.error("Login error:", error);
        this.errorMessage =
          error.message || "Đăng nhập không thành công. Vui lòng thử lại.";
      } finally {
        this.isLoading = false;
      }
    },
  },
};
</script>

<style scoped>
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #f5f5f5;
  padding: 1rem;
}

.login-form {
  width: 100%;
  max-width: 400px;
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  padding: 2rem;
}

.login-title {
  text-align: center;
  color: #333;
  margin-bottom: 1.5rem;
  font-size: 1.8rem;
}

.error-message {
  background-color: #ffebee;
  color: #c62828;
  padding: 0.75rem;
  border-radius: 4px;
  margin-bottom: 1rem;
  font-size: 0.9rem;
}

.form-group {
  margin-bottom: 1.5rem;
}

.form-group label {
  display: block;
  margin-bottom: 0.5rem;
  color: #555;
  font-weight: 500;
}

.form-group input {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
  transition: border-color 0.3s;
}

.form-group input:focus {
  border-color: #4caf50;
  outline: none;
}

.form-actions {
  margin-top: 2rem;
}

.login-button {
  width: 100%;
  padding: 0.75rem;
  background-color: #4caf50;
  color: white;
  border: none;
  border-radius: 4px;
  font-size: 1rem;
  font-weight: 500;
  cursor: pointer;
  transition: background-color 0.3s;
}

.login-button:hover {
  background-color: #45a049;
}

.login-button:disabled {
  background-color: #a5d6a7;
  cursor: not-allowed;
}

.form-footer {
  margin-top: 1.5rem;
  text-align: center;
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.register-link,
.forgot-password-link {
  color: #4caf50;
  text-decoration: none;
  font-size: 0.9rem;
}

.register-link:hover,
.forgot-password-link:hover {
  text-decoration: underline;
}
</style>
