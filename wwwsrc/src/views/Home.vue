<template>
  <div class="home container-fluid">
    <div class="row justify-content-between">
      <div class="col-1 mt-2 ml-n2">
        <button class="btn btn-success" v-if="user.id" @click="logout">Logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </div>
      <div class="col-1 mt-1">
        <button class="btn btn-warning mt-1" @click="goProfile">
          <i class="far fa-caret-square-right text-white"></i>
        </button>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-10 col-sm-6">
        <h1>Welcome home, {{user.username}}!</h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-1">
        <CreateKeepModal />
        <button class="btn btn-primary" data-toggle="modal" data-target="#create-keep-modal">
          <i class="fa fa-plus"></i>
        </button>
      </div>
    </div>
    <div class="row justify-content-left mt-2 mb-2 ml-n3 mr-1">
      <Keeps v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
import Auth from "../AuthService";
import Keeps from "../Components/Keeps";
import CreateKeepModal from "../Components/CreateKeepModal";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      const toast = swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 2000
      });
      swal
        .fire({
          title: "Are you sure?",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Logout"
        })
        .then(result => {
          if (result.value) {
            this.$store.dispatch("logout");
            toast.fire("logged out!", "", "success");
          }
        });
    },
    goProfile() {
      this.$router.push("profile");
    }
  },
  components: {
    Keeps,
    CreateKeepModal
  }
};
</script>