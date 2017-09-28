<template>
  <div id="login">
    Login module
  </div>
</template>

<script lang="ts">
  import Vue from 'vue'
  import Component from 'vue-class-component'

  @Component({ name: 'module-auth-login' })
  export default class ModuleAuthLogin extends Vue {

    mounted(): void {
      console.log('Module "auth login" mounted')
    }

  }
</script>
