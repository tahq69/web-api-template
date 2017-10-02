<template>
  <div id="app">
    Hello from Vue.js
  </div>
</template>

<script lang="ts" >
  import Vue from 'vue'
  import Component from 'vue-class-component'
  import { status } from './modules/status/api'

  @Component({ name: 'app' })
  export default class App extends Vue {

    async mounted(): Promise<number> {
      console.log('Application mounted')
      console.log(await status.api.GetStatus())
      return 0
    }

  }
</script>

<style lang="scss">
  @import "styles";
</style>
