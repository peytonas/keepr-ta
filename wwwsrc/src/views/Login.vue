<template>
  <div class="login">
    <form v-if="loginForm" @submit.prevent="loginUser">
      <input type="email" v-model="creds.email" placeholder="email" />
      <input type="password" v-model="creds.password" placeholder="password" />
      <button class="btn btn-warning" type="submit">Login</button>
    </form>
    <form v-else @submit.prevent="register">
      <input type="text" v-model="newUser.username" placeholder="name" />
      <input type="email" v-model="newUser.email" placeholder="email" />
      <input type="password" v-model="newUser.password" placeholder="password" />
      <button class="btn btn-warning" type="submit">Create Account</button>
    </form>
    <div @click="loginForm = !loginForm">
      <p v-if="loginForm">No account? Click here to Register</p>
      <p v-else>Already have an account? Click to Login</p>
    </div>
    <div class="row justify-content-around mt-2 mb-2 ml-n3 mr-1">
      <Keeps v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
    </div>
  </div>
</template>

<script>
import Keeps from "../Components/Keeps";
export default {
  name: "login",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  data() {
    return {
      loginForm: true,
      creds: {
        email: "",
        password: ""
      },
      newUser: {
        email: "",
        password: "",
        username: ""
      }
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  beforeCreate() {
    if (this.$store.state.user.id) {
      this.$router.push({ name: "home" });
    }
  },
  methods: {
    register() {
      this.$store.dispatch("register", this.newUser);
    },
    loginUser() {
      this.$store.dispatch("login", this.creds);
    }
  },
  components: { Keeps }
};
</script>