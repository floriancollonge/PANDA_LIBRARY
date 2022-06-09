<template>
  <div class="h-screen">
    <div class="float-left w-1/2 h-screen border-r border-gray-300">
      <img src="../assets/img/panda_book.png" />
    </div>
    <div class="float-right w-1/2 h-full flex justify-center items-center">
      <div class="w-3/4 h-1/2 border border-gray-300 relative  min-h-300 max-h-500 bg-gray">
        <TitleH1 text="Connexion" class="height-1/5"></TitleH1>
        <div id="login" class="flex flex-col items-center justify-center h-3/5">
          <label 
            for="email" 
            class="form-label inline-block mb-2 text-gray-700"
            >
            E-mail
          </label>
          <input
            type="text"
            class="
              form-control
              block
              w-1/2
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
          <p v-if="loginError.length > 0" class="errorLabel">{{ loginError }}</p> <!--ease-in ease-out-->
          <transition
            enter-active-class="duration-500 "
            enter-from-class="transform opacity-0"
            enter-to-class="opacity-100 "
            leave-active-class="duration-500 "
            leave-from-class="opacity-100"
            leave-to-class="transform opacity-0"
          >
            <div id="otp" v-if="step === steps.Otp" class="mt-2.5">
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
            </div>
          </transition>
          <div id="login-btn" class="absolute bottom-2 w-full flex items-center justify-center">
            <button class="bg-green-700 hover:bg-green-900 text-white font-bold py-2 px-4 rounded" @click="generateOtp()" v-if="step === steps.Login">
              Générer
            </button>
            <button class="bg-green-700 hover:bg-green-900 text-white font-bold py-2 px-4 rounded" @click="validateOtp()" v-if="step === steps.Otp">
                Se connecter
              </button>
          </div>
        </div>
        
      </div>
    </div>
    <div style="clear:both"></div>
    <!-- <div id="other-actions">
      <span>New user ?</span> <a v-on:click="create()">Subscribe for an account</a>
    </div> -->
  </div>
</template>
<script>
import { request } from "@/js/communication/api_request";
import TitleH1 from '@/components/TitleH1'
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
        login: {
        },
        otp: {
          unknown: "Mot de passe temporaire invalide."
        }
      },
      input: {
        login: "",
        otp: "",
        client_id: process.env.VUE_APP_CLIENT_ID,
        client_secret: process.env.VUE_APP_CLIENT_SECRET,
      },
    };
  },
  components: {
    TitleH1,
  },
  mounted() {
    this.step = this.steps.Login;
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
            if (response.status == 204) {
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
              self.$router.push({ name: "Accueil" });
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
