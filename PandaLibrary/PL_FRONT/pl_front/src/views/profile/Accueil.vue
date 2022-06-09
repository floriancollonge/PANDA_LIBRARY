<template>
  <div>
    <button class="bg-green-700 hover:bg-green-900 text-white font-bold py-2 px-4 rounded" @click="test()">
              Test
            </button>
  </div>
</template>

<script>
import { request } from "@/js/communication/api_request";
import { targets } from "@/js/enums/targets";
export default {
  name: "Accueil",
  data() {
    return {
      
    }
  },
  created() {
  },
  methods: {
    test() {
      var self = this;
        request("/book/integrate", "post", self.input, false, targets.Reference)
          .then(async () => {
            console.log("OK");
          })
          .catch(function () {
            console.log("KO");
          });
    }
  }
}
</script>

<style scoped></style>
