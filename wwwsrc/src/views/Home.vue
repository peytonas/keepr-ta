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
        <button class="btn btn-success mt-1" data-toggle="modal" data-target="#create-keep-modal">
          <i class="fa fa-plus"></i>
        </button>
      </div>
    </div>
    <Chips />
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
import Chips from "../Components/Chips";
import CreateKeepModal from "../Components/CreateKeepModal";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
    this.scrollKeeps();
  },
  methods: {
    scrollKeeps() {
      window.onscroll = () => {
        let bottomOfWindow =
          document.documentElement.scrollTop + window.innerHeight ===
          document.documentElement.offsetHeight;

        if (bottomOfWindow) {
          console.log("scrolled!");
        }
      };
    }
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
    },

    keepCount() {
      return 18;
    },

    initialKeeps() {
      let scrollKeeps = [];
      for (var i = 0; i <= this.keepCount; i++) {
        scrollKeeps.push(this.keeps[i]);
      }
      return scrollKeeps;
    }
  },
  components: {
    Keeps,
    CreateKeepModal,
    Navbar,
    Chips
  }
};
</script>