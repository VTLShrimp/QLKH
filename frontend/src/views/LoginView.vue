<template>
  <div class="login-container">
    <div class="login-form">
      <h1>Đăng nhập</h1>
      <div class="form-group">
        <label for="username">Tên đăng nhập</label>
        <input
          type="text"
          id="username"
          v-model="loginModel.userName"
          placeholder="Nhập tên đăng nhập"
        />
      </div>
      <div class="form-group">
        <label for="password">Mật khẩu</label>
        <input
          type="password"
          id="password"
          v-model="loginModel.password"
          placeholder="Nhập mật khẩu"
          @keyup.enter="handleLogin"
        />
      </div>
      <div class="form-group checkbox-container">
        <input type="checkbox" id="remember" v-model="loginModel.rememberMe" />
        <label for="remember" class="checkbox-label">Ghi nhớ đăng nhập</label>
      </div>
      <div class="error-message" v-if="errorMessage">{{ errorMessage }}</div>
      <button class="login-button" @click="handleLogin" :disabled="isLoading">
        <span v-if="isLoading" class="loader"></span>
        <span v-else>Đăng nhập</span>
      </button>
      <div class="bottom-links">
        <router-link to="/register" class="register-link"
          >Đăng ký tài khoản mới</router-link
        >
        <router-link to="/forgot-password" class="forgot-link"
          >Quên mật khẩu?</router-link
        >
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import authApi, { type LoginModel } from "@/api/auth.api";
import { useRouter } from "vue-router";
import Cookies from "js-cookie";

export default defineComponent({
  name: "LoginView",
  setup() {
    const router = useRouter();
    return { router };
  },
  data() {
    return {
      loginModel: {
        userName: "",
        password: "",
        rememberMe: false,
      } as LoginModel,
      isLoading: false,
      errorMessage: "",
    };
  },
  methods: {
    async handleLogin() {
      if (!this.loginModel.userName || !this.loginModel.password) {
        this.errorMessage = "Vui lòng điền đầy đủ thông tin đăng nhập";
        return;
      }

      this.isLoading = true;
      this.errorMessage = "";

      try {
        console.log("Đang gửi yêu cầu đăng nhập...");
        const result = await authApi.login(this.loginModel);
        console.log("Phản hồi từ API:", result);

        // Kiểm tra token
        if (!result || !result.token) {
          throw new Error("Token không hợp lệ từ phản hồi API");
        }

        // Lưu token vào cả localStorage và Cookies
        localStorage.setItem("authToken", result.token);
        Cookies.set("authToken", result.token);

        // Lưu thông tin người dùng nếu có
        if (result.userName) {
          localStorage.setItem("userName", result.userName);
        }
        if (result.email) {
          localStorage.setItem("userEmail", result.email);
        }

        console.log("Đăng nhập thành công", result);

        // Chuyển hướng sau khi đăng nhập thành công
        this.router.push("/").catch((err) => {
          console.error("Lỗi chuyển hướng:", err);
        });
      } catch (error: any) {
        console.error("Lỗi đăng nhập:", error);

        // Hiển thị thông báo lỗi chi tiết nếu có
        if (error.response && error.response.data) {
          console.log("Chi tiết lỗi từ API:", error.response.data);
          this.errorMessage =
            error.response.data.message || "Lỗi không xác định từ máy chủ";
        } else if (error.message) {
          this.errorMessage = error.message;
        } else {
          this.errorMessage =
            "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin!";
        }
      } finally {
        this.isLoading = false;
      }
    },

    // Kiểm tra xem người dùng đã đăng nhập chưa và token có hợp lệ không
    async checkAuth() {
      const token =
        localStorage.getItem("authToken") || Cookies.get("authToken");

      // Chỉ kiểm tra khi có token
      if (token) {
        try {
          // Kiểm tra token có hợp lệ không (tùy chọn)
          // Nếu bạn có API để xác thực token, bạn có thể thêm ở đây
          // await authApi.verifyToken(token);

          console.log("Đã đăng nhập, chuyển hướng đến trang chủ");
          this.router.push("/");
        } catch (error) {
          console.error("Token không hợp lệ:", error);
          // Xóa token không hợp lệ
          localStorage.removeItem("authToken");
          Cookies.remove("authToken");
        }
      }
    },
  },

  created() {
    // Kiểm tra trạng thái đăng nhập khi component được tạo
    // Chỉ kiểm tra nếu không có force=true trong query params
    if (!this.$route.query.force) {
      this.checkAuth();
    }
  },
});
</script>

<style scoped>
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #f5f5f5;
  background-image: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
}

.login-form {
  width: 100%;
  max-width: 400px;
  padding: 2.5rem;
  background: white;
  border-radius: 10px;
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
}

h1 {
  margin-bottom: 1.5rem;
  text-align: center;
  color: #333;
  font-weight: 600;
}

.form-group {
  margin-bottom: 1.25rem;
}

.checkbox-container {
  display: flex;
  align-items: center;
  margin-bottom: 1rem;
}

.checkbox-container input[type="checkbox"] {
  width: auto;
  margin-right: 8px;
}

.checkbox-label {
  font-weight: normal;
  margin-bottom: 0;
  font-size: 0.9rem;
  color: #666;
}

label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: 500;
  color: #444;
}

input {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 6px;
  font-size: 1rem;
  transition: border-color 0.3s, box-shadow 0.3s;
}

input:focus {
  outline: none;
  border-color: #4caf50;
  box-shadow: 0 0 0 2px rgba(76, 175, 80, 0.2);
}

.login-button {
  position: relative;
  width: 100%;
  padding: 0.85rem;
  background-color: #4caf50;
  color: white;
  border: none;
  border-radius: 6px;
  font-size: 1rem;
  font-weight: 500;
  cursor: pointer;
  margin-top: 0.5rem;
  transition: background-color 0.3s;
  display: flex;
  justify-content: center;
  align-items: center;
}

.login-button:hover {
  background-color: #3d9140;
}

.login-button:disabled {
  background-color: #cccccc;
  cursor: not-allowed;
}

.error-message {
  color: #f44336;
  font-size: 0.875rem;
  margin-top: 0.5rem;
  padding: 0.5rem;
  background-color: rgba(244, 67, 54, 0.1);
  border-radius: 4px;
  text-align: center;
}

.bottom-links {
  display: flex;
  justify-content: space-between;
  margin-top: 1.5rem;
  font-size: 0.9rem;
}

.register-link,
.forgot-link {
  color: #4caf50;
  text-decoration: none;
  transition: color 0.3s;
}

.register-link:hover,
.forgot-link:hover {
  color: #3d9140;
  text-decoration: underline;
}

/* Loading spinner */
.loader {
  width: 20px;
  height: 20px;
  border: 3px solid rgba(255, 255, 255, 0.3);
  border-radius: 50%;
  border-top-color: white;
  animation: spin 1s ease infinite;
}

@keyframes spin {
  to {
    transform: rotate(360deg);
  }
}

/* Responsive */
@media (max-width: 480px) {
  .login-form {
    padding: 1.5rem;
    max-width: 90%;
  }

  h1 {
    font-size: 1.5rem;
  }

  .bottom-links {
    flex-direction: column;
    align-items: center;
    gap: 0.75rem;
  }
}
</style>
