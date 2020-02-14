<template>
  <div class="profile container-fluid">
    <div class="row">
      <Navbar />
    </div>
    <div class="row justify-content-center">
      <h1>{{this.vault.name}}</h1>
      <p class="btn fab" @click="deleteVault">&times;</p>
    </div>
    <div class="row justify-content-around mt-2 mb-2 ml-n3 mr-1">
      <VaultKeeps v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
    </div>
  </div>
</template>
<script>
import VaultKeeps from "../Components/VaultKeeps";
import Navbar from "../Components/Navbar";
import swal from "sweetalert2";
export default {
  name: "vaultKeep",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vault() {
      return this.$store.state.vault;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    goProfile() {
      this.$router.push("/profile");
    },
    deleteVault() {
      const toast = swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 2000
      });
      swal
        .fire({
          title: "Are you sure?",
          showCancelButton: true,
          background: "#cec9cc",
          confirmButtonColor: "#4f43ae",
          cancelButtonColor: "#de4337",
          confirmButtonText: "Logout"
        })
        .then(result => {
          if (result.value) {
            this.$store.dispatch("deleteVault", this.$route.params.vaultId);
            toast.fire("it's gone jim!", "", "success");
            this.$router.push({ name: "profile" });
          }
        });
    }
  },
  mounted() {
    this.$store.dispatch("getVault", this.$route.params.vaultId);
  },
  components: {
    VaultKeeps,
    Navbar
  }
};
</script>
<style>
.pos {
  position: absolute;
  right: -2rem;
  top: -1rem;
}
.btn.fab {
  height: 30px;
  width: 30px;
  font-size: 12px;
  right: -2.5rem;
  top: -1rem;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>