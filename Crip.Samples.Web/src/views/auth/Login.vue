<template>
  <div id="login">
    <button @click="login">Login.vue</button>
    Some text under 
  </div>
</template>

<script lang="ts">
import http from "axios"
import Vue from "vue"

export default Vue.extend({
  methods: {
    async login() {
      const url = `/api/auth/login`
      const response = await http.post(url, { Username: "Username", Password: "Password" })
      console.log(response)
    },
  },

  mounted() {
    console.log("Module 'auth login' mounted")
  },
})
</script>
