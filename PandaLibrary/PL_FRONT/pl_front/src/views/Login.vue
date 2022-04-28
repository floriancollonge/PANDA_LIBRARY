<template>
  <div class="content-login">
    <h1>Connexion à Panda's Library</h1>
    <br />
    <div id="login" v-if="step === steps.Login">
      <label for="email" class="form-label inline-block mb-2 text-gray-700">E-mail</label>
      <input
        type="text"
        class="
          form-control
          block
          w-full
          px-3
          py-1.5
          text-base
          font-normal
          text-gray-700
          bg-white bg-clip-padding
          border border-solid border-gray-300
          rounded
          transition
          ease-in-out
          m-0
          focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none
        "
        id="email"
        v-model="input.login"
        autofocus
        placeholder="jean.dupont@gmail.com"
      />
      <p v-if="loginError.length > 0" class="errorLabel">{{ loginError }}</p>
      <div id="login-btn">
        <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" @click="generateOtp()">
          Générer
        </button>
      </div>
    </div>
    <!-- <div id="otp" v-if="step === steps.Otp"> -->
      <label for="otp" class="form-label inline-block mb-2 text-gray-700">Code généré</label>
      <input
        type="text"
        class="
          form-control
          block
          w-full
          px-3
          py-1.5
          text-base
          font-normal
          text-gray-700
          bg-white bg-clip-padding
          border border-solid border-gray-300
          rounded
          transition
          ease-in-out
          m-0
          focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none
        "
        id="otp"
        v-model="input.otp"
        autofocus
        placeholder="001122"
      />
      <p v-if="otpError.length > 0" class="errorLabel">{{ otpError }}</p>
      <div id="login-btn">
        <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" @click="validateOtp()">
          Se connecter
        </button>
      <!-- </div> -->
    </div>

    <!-- <div id="other-actions">
      <span>New user ?</span> <a v-on:click="create()">Subscribe for an account</a>
    </div> -->
  </div>
</template>
<script>
import { request } from "@/js/communication/api_request";
import {
  setRefreshToken,
  setAccessToken,
} from "@/js/communication/authentification_handler";
import { targets } from "@/js/enums/targets";

export default {
  name: "login",
  data() {
    return {
      steps: {
        Login: "login",
        Otp: "otp",
      },
      step: "",
      isLoading: false,
      loginError: "",
      otpError: "",
      errorMessages: {
        empty: "Cet élément ne peut être laissé vide.",
        login: {},
      },
      input: {
        login: "",
        otp: "",
        client_id: process.env.VUE_APP_CLIENT_ID,
        client_secret: process.env.VUE_APP_CLIENT_SECRET,
      },
    };
  },
  mounted() {
    this.step = this.steps.Login;
  },
  methods: {
    generateOtp() {
      console.log("generate " + this.validateInputs());
      this.isLoading = true;
      if (this.validateInputs()) {
        let self = this;
        request(
          "/v1/user/authorize",
          "post",
          self.input,
          false,
          targets.Barrier
        )
          .then(async (response) => {
            console.log("ok");
            self.isLoading = false;
            if (response.status == 201) {
              self.step = self.steps.Otp;
            } else {
              self.loginError = self.errorMessages.login.unknown;
            }
          })
          .catch(function (err) {
            console.log(err);
            self.isLoading = false;
            self.passwordError = self.errorMessages.login.unknown;
          });
      } else {
        this.isLoading = false;
      }
    },
    validateOtp() {
      this.isLoading = true;
      // if (this.validateInputs()) {
        var self = this;
        request("/v1/token", "post", self.input, false, targets.Barrier)
          .then(async (response) => {
            if (response.status == 200) {
              setRefreshToken(response.data.refresh_token);
              setAccessToken(response.data.access_token);
              self.$router.push({ name: "home" });
            } else {
              self.isLoading = false;
              self.otpError = self.errorMessages.otp.unknown;
            }
          })
          .catch(function () {
            self.isLoading = false;
            self.otpError = self.errorMessages.otp.unknown;
          });
      // } else {
      //   this.isLoading = false;
      // }
    },
    create() {
      this.$router.push({ name: "subscribe" });
    },
    validateInputs() {
      this.loginError = "";
      this.otpError = "";
      if (this.step === this.steps.Login && this.input.login === "") {
        this.loginError = this.errorMessages.empty;
      }
      if (this.step === this.steps.Otp && this.input.otp === "") {
        this.otpError = this.errorMessages.empty;
      }
      return this.loginError === "" && this.otpError === "";
    },
  },
};
</script>
<style scoped></style>
