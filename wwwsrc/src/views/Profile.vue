<template>
  <div class="profile">
    <div class="row justify-content-between">
      <button class="btn btn-warning mt-1 ml-1 text-white" @click="goHome">
        <i class="far fa-caret-square-left text-white"></i>
      </button>
    </div>
    <div class="row justify-content-center mt-2">
      <h5>This is your profile, {{user.username}}</h5>
    </div>
    <div class="row justify-content-center">
      <div class="col-2">
        <CreateKeepModal />
        <button
          class="btn btn-primary mb-2"
          data-toggle="modal"
          data-target="#create-keep-modal"
        >NEW KEEP</button>
      </div>
      <!-- <div class="col-2">
        <CreateVaultModal />
        <button
          class="btn btn-primary mb-2"
          data-toggle="modal"
          data-target="#create-vault-modal"
        >NEW VAULT</button>
      </div>-->
    </div>
    <div class="row justify-content-around">
      <Keeps class="col-3 mb-2" v-for="keep in userKeeps" :keepProp="keep" :key="keep._id" />
    </div>
    <div class="row justify-content-around">
      <div class="border border-dark rounded row justify-content-around mb-2">
        <!-- <Vaults
          class="col mb-2 ml-1 mr-1"
          v-for="vault in vaults"
          :vaultProp="vault"
          :key="vault._id"
        />-->
      </div>
    </div>
  </div>
</template>
<script>
import Auth from "../AuthService";
import Keeps from "../Components/Keeps";
// import Vaults from "../Components/Vaults";
import CreateKeepModal from "../Components/CreateKeepModal";
// import CreateVaultModal from "../Components/CreateVaultModal";
export default {
  name: "profile",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getUserKeeps");
    // this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
    // vaults() {
    //   return this.$store.state.vaults;
    // }
  },
  methods: {
    goHome() {
      this.$router.push("/");
    }
  },
  components: {
    Keeps,
    // Vaults,
    CreateKeepModal
    // CreateVaultModal
  }
};
</script>