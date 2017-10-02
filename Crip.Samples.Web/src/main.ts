import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { extensions } from './extensions/log'
import 'font-awesome/scss/font-awesome.scss'

extensions.install(Vue.prototype)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  render: h => h(App),
})
