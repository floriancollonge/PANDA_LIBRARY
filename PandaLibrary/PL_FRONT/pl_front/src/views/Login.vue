<template>
  <div class="content-login">
    <h1>Connexion à Panda's Library</h1>
    <br />
    <div id="login" v-if="step === steps.Login">
      <v-text-field
        label="E-mail"
        v-model="input.login"
        placeholder="jean.dupont@gmail.com"
        autofocus
      ></v-text-field>
      <p v-if="loginError.length > 0" class="errorLabel">{{ loginError }}</p>
      <div id="login-btn">
        <v-btn
          @click="generateOtp()"
          :loading="isLoading"
          v-shortkey="['enter']"
          @shortkey="generateOtp()"
          :rounded="true"
          class="btn"
        >
          Générer
        </v-btn>
      </div>
    </div>
    <div id="otp" v-if="step === steps.Otp">
      <v-text-field
        label="Code généré"
        v-model="input.otp"
        placeholder="001122"
        autofocus
      ></v-text-field>
      <p v-if="otpError.length > 0" class="errorLabel">{{ otpError }}</p>
      <div id="login-btn">
        <v-btn
          @click="validateOtp()"
          :loading="isLoading"
          v-shortkey="['enter']"
          @shortkey="validateOtp()"
          :rounded="true"
          class="btn"
        >
          Se connecter
        </v-btn>
      </div>
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
      step: this.steps.Login,
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
  methods: {
    generateOtp() {
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
            self.isLoading = false;
            if (response.status == 200) {
              self.step = self.steps.Otp;
            } else {
              self.loginError = self.errorMessages.login.unknown;
            }
          })
          .catch(function () {
            self.isLoading = false;
            self.passwordError = self.errorMessages.login.unknown;
          });
      } else {
        this.isLoading = false;
      }
    },
    validateOtp() {
      this.isLoading = true;
      if (this.validateInputs()) {
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
      } else {
        this.isLoading = false;
      }
    },
    create() {
      this.$router.push({ name: "subscribe" });
    },
    validateInputs() {
      this.loginError = "";
      this.otpError = "";
      if (this.input.login === "") {
        this.loginError = this.errorMessages.empty;
      }
      if (this.input.otp === "") {
        this.otpError = this.errorMessages.empty;
      }
      if (this.loginError === "" && this.otpError === "") {
        return true;
      }
      return false;
    },
  },
};
</script>
<style scoped></style>
