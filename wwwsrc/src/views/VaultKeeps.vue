<template>
  <div class="profile container-fluid">
    <div class="row">
      <Navbar />
    </div>
    <div class="row justify-content-left ml-1 mr-1">
      <button class="btn btn-warning mt-2" @click="goProfile">
        <i class="far fa-caret-square-left text-white"></i>
      </button>
    </div>
    <h1>{{this.vault.name}}</h1>
    <div class="row justify-content-around mt-2 mb-2 ml-n3 mr-1">
      <Keeps v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
    </div>
  </div>
</template>
<script>
import Keeps from "../Components/Keeps";
import Navbar from "../Components/Navbar";

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
    }
  },
  mounted() {
    this.$store.dispatch("getVault", this.$route.params.vaultId);
  },
  components: {
    Keeps,
    Navbar
  }
};
</script>