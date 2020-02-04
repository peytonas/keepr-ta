import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from '../views/Home.vue'
// @ts-ignore
import Login from '../views/Login.vue'
// @ts-ignore
import Profile from '../views/Profile.vue'
// @ts-ignore
import Vault from '../views/Vault.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/profile',
      name: 'profile',
      component: Profile
    },
    {
      path: '/vaultkeeps/:vaultId',
      name: 'vaultKeeps',
      component: Vault
    },
  ]
})
