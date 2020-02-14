<template>
  <div class="home container-fluid">
    <div class="row">
      <Navbar />
    </div>
    <div class="row justify-content-end">
      <div class="col-2 col-sm-6">
        <h1>Welcome home, {{user.username}}!</h1>
      </div>
      <div class="col-3 text-right">
        <CreateKeepModal />
        <button class="btn btn-primary mt-1" data-toggle="modal" data-target="#create-keep-modal">
          <i class="fa fa-plus"></i>
        </button>
      </div>
    </div>
    <div class="row justify-content-around mt-2 mb-2 ml-n3 mr-2">
      <Keeps v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
import Auth from "../AuthService";
import Navbar from "../Components/Navbar";
import Keeps from "../Components/Keeps";
import CreateKeepModal from "../Components/CreateKeepModal";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
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
    CreateKeepModal,
    Navbar
  }
};
</script>