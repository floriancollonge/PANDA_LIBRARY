<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/img/LOGO_FDBLANC.svg" />
    <HelloWorld msg="Panda's Library !" />
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from "@/components/HelloWorld.vue";

export default {
  name: "Home",
  components: {
    HelloWorld,
  },
};
</script>
