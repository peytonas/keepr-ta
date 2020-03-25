import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from '../router'
import AuthService from '../AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 5000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keep: {},
    keeps: [],
    userKeeps: [],
    vault: {},
    vaults: [],
    vaultKeep: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      state.user = {}
    },
    setKeep(state, payload) {
      state.keep = payload
    },
    setKeeps(state, payload) {
      state.keeps = payload
    },
    setUserKeeps(state, payload) {
      state.userKeeps = payload
    },
    setVault(state, payload) {
      state.vault = payload
    },
    setVaults(state, payload) {
      state.vaults = payload
    },
    setVaultKeep(state, payload) {
      state.vaultKeep = payload
    },
    setVaultKeeps(state, payload) {
      state.vaultKeeps = payload
    }
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    async createKeep({ commit, dispatch }, payload) {
      try {
        await api.post("keeps", payload)
        dispatch("getKeeps")
        dispatch("getUserKeeps")
      } catch (error) {
        console.error(error)
      }
    },

    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get(`keeps`)
        commit('setKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get(`keeps/user`)
        commit('setUserKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async deleteKeep({ commit, dispatch }, keepId) {
      try {
        await api.delete(`keeps/${keepId}`)
        dispatch("getKeeps")
        dispatch("getUserKeeps")
      } catch (error) {
        console.error(error)
      }
    },

    async editKeep({ commit, dispatch }, payload) {
      try {
        await api.put(`keeps/` + payload.id, payload)
        // dispatch("getKeeps")
        // dispatch("getUserKeeps")
      } catch (error) {
        console.error(error)
      }
    },

    async createVault({ commit, dispatch }, payload) {
      try {
        await api.post("vaults", payload)
        dispatch("getVaults")
      } catch (error) {
        console.error(error)
      }
    },

    async getVault({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get(`vaults/${vaultId}`)
        commit("setVault", res.data)
        dispatch('getVaultKeeps', vaultId)
      } catch (error) {
        console.error(error)
      }
    },

    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get(`vaults`)
        commit('setVaults', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async getVaultKeeps({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get(`vaultkeeps/${vaultId}`)
        commit('setKeeps', res.data)
        commit('setVaultKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async deleteVault({ commit, dispatch }, vaultId) {
      try {
        await api.delete(`vaults/${vaultId}`)
        dispatch("getVaults")
      } catch (error) {
        console.error(error)
      }
    },

    async addToVault({ commit, dispatch }, payload) {
      try {
        await api.put('keeps/' + payload.id, payload)
        dispatch("getKeeps")
        dispatch("getUserKeeps")
      } catch (e) {
        console.error(e)
      }
    },

    async storeKeep({ commit, dispatch }, payload) {
      try {
        await api.post('vaultkeeps', payload)
        await api.get('keeps/' + payload.keepId)
        dispatch('getKeeps')
      } catch (error) {
        console.error(error)
      }
    },

    async removeKeep({ commit, dispatch }, payload) {
      try {
        await api.put('vaultkeeps', payload)
        dispatch("getVault", payload.vaultId)
      } catch (error) {
        console.error(error)
      }
    }
  }
})
