<template>
  <div class="navbar col-12 navbar-dark bg-dark">
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarToggleExternalContent"
      aria-controls="navbarToggleExternalContent"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse" id="navbarToggleExternalContent">
      <div v-if="this.$route.name != `home`" class="pr-3">
        <router-link :to="{name: `home`}">Dashboard</router-link>
      </div>
      <div v-if="this.$route.name != `profile`" class="pr-3">
        <router-link :to="{name: `profile`}">Profile</router-link>
      </div>
      <div class="pr-2">
        <p @click="logout" aria-placeholder="Logout-Button" class="logout" v-if="user.id">Logout</p>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </div>
    </div>
  </div>
</template>
<script>
import Auth from "../AuthService";
import router from "../router/index";
import NotificationService from "../NotificationService";
export default {
  name: "Navbar",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    async logout() {
      if (
        await NotificationService.confirmAction(
          "Are you sure you want to log out?"
        )
      ) {
        this.$store.dispatch("logout");
      }
    },
    goDashboard() {
      this.$router.push({ name: "home" });
    }
  },
  components: {}
};
</script>


<style scoped>
/* .navbar-toggler {
} */

.logout {
  color: red;
  cursor: pointer;
  margin-bottom: 5px;
}
button:focus {
  outline: 0;
}
.logout:hover {
  color: white;
  text-decoration: solid underline;
}
.dashboard-link {
  cursor: pointer;
}
.dashboard-link:hover {
  color: white;
  text-decoration: solid underline;
}
</style>