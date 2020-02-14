<template>
  <div class="profile container-fluid">
    <div class="row">
      <Navbar />
    </div>
    <div class="row mt-2 ml-1 justify-content-between text-center">
      <div class="col-2">
        <h2>Your Keeps:</h2>
      </div>
      <div class="col-1 offset-7">
        <CreateKeepModal />
        <button
          class="btn btn-success mb-2 create"
          data-toggle="modal"
          data-target="#create-keep-modal"
        >
          <i class="fa fa-plus"></i>
        </button>
      </div>
      <div class="col-1">
        <CreateVaultModal />
        <button
          class="btn btn-secondary mb-2"
          data-toggle="modal"
          data-target="#create-vault-modal"
        >
          <i class="fa fa-plus"></i>
        </button>
      </div>
      <div class="dropdown">
        <button
          class="btn btn-warning text-white mr-2"
          type="button"
          id="dropdownMenuButton"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        >Vaults ({{this.vaults.length}})</button>
        <div
          class="dropdown-menu dropdown-menu-right text-left"
          aria-labelledby="dropdownMenuButton"
        >
          <Vaults v-for="vault in vaults" :vaultProp="vault" :key="vault._id" />
        </div>
      </div>
    </div>
    <div class="row justify-content-around mt-2 mb-2 ml-n3 mr-2">
      <Keeps v-for="keep in userKeeps" :keepProp="keep" :key="keep._id" />
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
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaults");
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
<style>
.col-1 {
  margin-right: -45px;
}
.create {
  margin-right: -65px;
}
</style>