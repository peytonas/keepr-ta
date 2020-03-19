// @ts-ignore
import Account from '../views/Account.vue'
import store from '../store'
import AuthService from '../AuthService'

export default {
  path: "/account",
  component: Account,
  async beforeEnter(to, from, next) {
    if (store.state.user.id) {
      return next()
    }
    try {
      let user = await AuthService.Authenticate()
      if (!user) return next("/login")
      store.commit("setUser", user)
      next()
    } catch (e) {
      return next("/login")
    }
  }
}