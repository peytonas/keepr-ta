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
        <button class="btn btn-dark mb-2" data-toggle="modal" data-target="#create-vault-modal">
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
    <Chips @newChip="addChips" @deleteChip="deleteChip" @resetChips="resetChips" />
    <div class="row justify-content-around mt-2 mb-2 ml-n3 mr-2">
      <Keeps v-for="keep in gottenKeeps" :keepProp="keep" :key="keep._id" />
    </div>
  </div>
</template>
<script>
import Auth from "../AuthService";
import Keeps from "../Components/Keeps";
import Vaults from "../Components/Vaults";
import Navbar from "../Components/Navbar";
import Chips from "../Components/Chips";
import CreateKeepModal from "../Components/CreateKeepModal";
import CreateVaultModal from "../Components/CreateVaultModal";
export default {
  name: "profile",
  data() {
    return {
      chips: [],
      filteredKeeps: [],
      gottenKeeps: [],
      keepCount: 18,
      scrollCount: 0
    };
  },
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaults");
    this.scrollKeeps();
  },
  computed: {
    user() {
      return this.$store.state.user;
    },

    userKeeps() {
      if (this.filteredKeeps.length > 0) {
        return this.filteredKeeps;
      } else {
        return this.$store.state.userKeeps;
      }
    },

    vaults() {
      return this.$store.state.vaults;
    },

    initialKeeps() {
      for (var i = 0; i <= this.keepCount; i++) {
        this.gottenKeeps.push(this.keeps[i]);
      }
    }
  },
  methods: {
    addChips(chip) {
      this.chips.push(chip);
      this.filterKeeps(chip);
    },

    deleteChip(deletedChip) {
      this.chips = this.chips.filter(c => c !== deletedChip.name);
      this.filteredKeeps = [];
      for (var chip in this.chips) {
        this.filterKeeps(this.chips[chip]);
      }
    },

    resetChips() {
      this.chips = [];
      this.filteredKeeps = [];
    },

    filterKeeps(name) {
      var filtered = this.userKeeps.filter(
        k =>
          k.name.toLowerCase().includes(name) ||
          k.description.toLowerCase().includes(name)
      );
      this.filteredKeeps = filtered;
    },

    scrollKeeps() {
      for (var i = this.scrollCount; i < this.keepCount; i++) {
        this.gottenKeeps.push(this.$store.state.keeps[i]);
      }
      window.onscroll = () => {
        let bottomOfWindow =
          document.documentElement.scrollTop + window.innerHeight ===
          document.documentElement.offsetHeight;

        if (bottomOfWindow) {
          var difference = this.$store.state.keeps.length - this.keepCount;
          if (difference < 18) {
            console.log(difference);
            this.keepCount += difference;
            this.scrollCount += difference;
            this.scrollKeeps();
          }
          this.keepCount += 18;
          this.scrollCount += 18;
          this.scrollKeeps();
          console.log("scrolled!");
        }
      };
    },

    goHome() {
      this.$router.push("/");
    }
  },
  components: {
    Keeps,
    Vaults,
    Navbar,
    Chips,
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