import Vue from 'vue'
import Router from 'vue-router'
import auth from './modules/auth/routes'

Vue.use(Router)

export default new Router({
  routes: [
    auth
  ]
})
