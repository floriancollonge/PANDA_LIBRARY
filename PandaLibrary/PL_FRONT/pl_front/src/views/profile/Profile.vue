<template>
  <div class="h-screen w-screen">
    <Menu></Menu>
    <router-view></router-view>
  </div>
</template>

<script>
import { getAccessToken, getRefreshToken, isTokenExpired } from '@/js/communication/authentification_handler';
import Menu from '@/components/Menu.vue'

export default {
  name: "profile",
  data() {
    return {
    }
  },
  created() {
    if (isTokenExpired(getAccessToken()) && isTokenExpired(getRefreshToken())){
      self.$router.push({ name: "Login" });
    }
  },
  components: {
    Menu
  }
}
</script>

<style scoped></style>
