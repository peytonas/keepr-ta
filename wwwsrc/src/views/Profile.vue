<template>
  <div class="profile container-fluid">
    <div class="row">
      <Navbar />
    </div>
    <div class="row mt-2 ml-1 justify-content-left">
      <div class="col-2">
        <h2>Your Keeps:</h2>
      </div>
    </div>
    <div class="row justify-content-end">
      <div class="col-1">
        <CreateKeepModal />
        <button class="btn btn-primary mb-2" data-toggle="modal" data-target="#create-keep-modal">
          <i class="fa fa-plus"></i>
        </button>
      </div>
      <div class="col-1">
        <CreateVaultModal />
        <button class="btn btn-success mb-2" data-toggle="modal" data-target="#create-vault-modal">
          <i class="fa fa-plus"></i>
        </button>
      </div>
    </div>
    <div class="row justify-content-around mt-2 mb-2 ml-n3 mr-2">
      <Keeps v-for="keep in userKeeps" :keepProp="keep" :key="keep._id" />
    </div>
    <div class="row justify-content-left border rounded border-dark mb-2 ml-1 mr-1">
      <Vaults class="col-1" v-for="vault in vaults" :vaultProp="vault" :key="vault._id" />
    </div>
  </div>
</template>
<script>
import Auth from "../AuthService";
import Keeps from "../Components/Keeps";
import Vaults from "../Components/Vaults";
import Navbar from "../Components/Navbar";
import CreateKeepModal from "../Components/CreateKeepModal";
import CreateVaultModal from "../Components/CreateVaultModal";
export default {
  name: "profile",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    goHome() {
      this.$router.push("/");
    }
  },
  components: {
    Keeps,
    Vaults,
    Navbar,
    CreateKeepModal,
    CreateVaultModal
  }
};
</script>