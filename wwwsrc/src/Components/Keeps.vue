<template>
  <div
    class="col-2 mt-2 mb-2"
    v-if="this.keepProp.isPrivate == false || this.keepProp.userId == this.user.id"
  >
    <img class="keep bg-dark" :src="keepProp.img" @click.prevent="viewKeep" />
    <p class="overflow">
      <span v-if="this.$route.name == 'profile'">{{keepProp.name}}</span>
      <br />
      <span v-if="this.$route.name == 'profile'">{{keepProp.description}}</span>
      <span v-if="this.keepProp.isPrivate == true">
        <i class="fas fa-user-secret"></i>
      </span>
    </p>
    <p class="mt-n3">
      <span
        v-if="this.$route.name != 'login'"
      >VIEWS: {{keepProp.views}} | VAULTED: {{keepProp.keeps}}</span>
    </p>
    <audio id="oof">
      <source src="../assets/roblox-oof.mp3" type="audio/mpeg" />
    </audio>
    <div class="pos mr-n1 mt-1" v-if="this.$route.name != 'login'">
      <button
        class="btn fab btn-danger"
        @click.prevent="deleteKeep"
        v-if="user.id == this.keepProp.userId"
      >
        <i class="fas fa-dumpster-fire"></i>
      </button>
      <div class="dropdown" v-if="this.$route.name !='vaultKeeps'">
        <button
          class="btn fab btn-warning"
          type="button"
          id="dropdownMenuButton"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        >
          <i class="fas fa-dungeon text-white"></i>
        </button>
        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton">
          <li
            class="dropdown-item"
            v-for="vault in vaults"
            v-bind:key="vault.id"
            @click="addToVault(vault.id)"
          >{{vault.name}}</li>
        </div>
      </div>
      <div class="align-content-center">
        <button
          class="btn fab btn-danger"
          @click.prevent="removeKeep"
          v-if="this.$route.name == 'vaultKeeps'"
        >
          <i class="fas fa-minus-circle"></i>
        </button>
      </div>
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
export default {
  name: "Keeps",
  props: ["keepProp"],
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    addToVault(vaultId) {
      const toast = swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 2000
      });
      this.$store.dispatch("storeKeep", {
        keepId: this.keepProp.id,
        vaultId: vaultId
      });
      this.$store.dispatch("addToVault", {
        id: this.keepProp.id,
        isPrivate: this.keepProp.isPrivate,
        keeps: this.keepProp.keeps + 1,
        views: this.keepProp.views,
        vaulted: (this.keepProp.vaulted = true)
      });
      toast.fire("added " + this.keepProp.name + " to vault!", "", "success");
    },

    viewKeep() {
      swal.fire({
        title: this.keepProp.name,
        imageUrl: this.keepProp.img,
        imageAlt: "...",
        background: "#b5b6e4",
        backdrop: "rgba(33,26,33,0.6)",
        showConfirmButton: false
      });
      this.$store.dispatch("editKeep", {
        id: this.keepProp.id,
        isPrivate: this.keepProp.isPrivate,
        keeps: this.keepProp.keeps,
        views: this.keepProp.views + 1,
        vaulted: (this.keepProp.vaulted = true)
      });
    },

    deleteKeep() {
      let roblox = document.getElementById("oof");
      const toast = swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 2000
      });
      swal
        .fire({
          title: "Are you sure?",
          type: "warning",
          showCancelButton: true,
          background: "#cec9cc",
          confirmButtonColor: "#4f43ae",
          cancelButtonColor: "#de4337",
          confirmButtonText: "Do it."
        })
        .then(result => {
          if (result.value) {
            //NOTE put the sound below .
            roblox.play();
            setTimeout(() => {
              toast.fire("deleted " + this.keepProp.name + "!", "", "success");
              this.$store.dispatch("deleteKeep", this.keepProp.id);
            }, 500);
          }
        });
    },

    removeKeep() {
      swal
        .fire({
          title: "Are you sure?",
          type: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes!"
        })
        .then(result => {
          if (result.value) {
            this.$store.dispatch("removeKeep", {
              keepId: this.keepProp.id,
              vaultId: parseInt(this.$route.params.vaultId)
            });
          }
        });
    }
  }
};
</script>
<style>
.pos {
  position: absolute;
  right: -1rem;
  top: -1rem;
}

.overflow {
  overflow: hidden;
}
</style>