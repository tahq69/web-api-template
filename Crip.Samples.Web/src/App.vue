<template>
  <div id="app">
    Hello from Vue.js
  </div>
</template>

<script lang="ts">
  import Vue from 'vue'
  import Component from 'vue-class-component'

  @Component({ name: 'app' })
  export default class App extends Vue {

    mounted(): void {
      console.log('Application mounted')
    }

  }
</script>

<style lang="scss">
  @import "styles";
</style>
