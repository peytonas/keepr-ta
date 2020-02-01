// @ts-ignore
import Account from '../views/Account.vue'
// @ts-ignore
import Dashboard from '../views/Dashboard.vue'
// @ts-ignore
import Poll from '../views/Poll.vue'
// @ts-ignore
import Question from '../views/Question.vue'
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
  },
  // children: [{
  //   path: '/account/dashboard',
  //   name: 'account.dashboard',
  //   component: Dashboard
  // },
  // {
  //   path: '/account/:pollId',
  //   name: 'account.poll',
  //   component: Poll
  // },
  // {
  //   path: '/account/:pollId/question/:id',
  //   name: 'account.pollId.question.id',
  //   component: Question
  // }]
}