<template>
  <div class="col-2 mt-2 mb-2">
    <!-- <p>{{this.keeps()}}</p> -->
    <img class="keep bg-dark" :src="keepProp.img" @click.prevent="viewKeep" />
    <p class="overflow">
      {{keepProp.description}}
      <span v-if="this.keepProp.isPrivate == true">
        <i class="fas fa-user-secret"></i>
      </span>
    </p>
    <p class="mt-n3">
      <span>VIEWS: {{keepProp.views}} | VAULTED: {{keepProp.keeps}}</span>
    </p>
    <audio id="oof">
      <source src="../assets/roblox-oof.mp3" type="audio/mpeg" />
    </audio>
    <div class="pos text-dark">
      <p class="count">{{this.keeps()}}.</p>
    </div>
    <div class="pos mr-n1 mt-1">
      <div class="align-content-center">
        <button
          class="btn fab btn-danger"
          @click.prevent="removeKeep"
          v-if="this.$route.name == 'vaults'"
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
  name: "VaultKeeps",
  props: ["keepProp"],
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  mounted() {},
  methods: {
    addToVault(vaultId) {
      this.$store.dispatch("storeKeep", {
        keepId: this.keepProp.id,
        vaultId: vaultId
      });
      this.$store.dispatch("addToVault", {
        id: this.keepProp.id,
        keeps: this.keepProp.keeps + 1,
        views: this.keepProp.views,
        vaulted: true
      });
    },
    viewKeep() {
      swal.fire({
        text: this.keepProp.name,
        imageUrl: this.keepProp.img,
        imageAlt: "...",
        background: "#b5b6e4",
        backdrop: "rgba(33,26,33,0.6)",
        showConfirmButton: false
      });
      this.$store.dispatch("editKeep", {
        id: this.keepProp.id,
        keeps: this.keepProp.keeps,
        views: this.keepProp.views + 1,
        vaulted: this.keepProp.vaulted
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
          text: "You won't be able to get it back...",
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
              toast.fire("it's gone jim!", "", "success");
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
          background: "#cec9cc",
          confirmButtonColor: "#4f43ae",
          cancelButtonColor: "#de4337",
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
    },
    keeps() {
      let num = this.$store.state.keeps.indexOf(this.keepProp);
      num += 1;
      return num;
    }
  }
};
</script>
<style>
span {
  font-size: 0.75rem;
}
.count {
  position: relative;
  left: -10.5rem;
  top: 0rem;
  height: 30px;
  width: 30px;
  font-size: 12px;
  display: flex;
}
.pos {
  position: absolute;
  right: -1rem;
  top: -1rem;
}
.overflow {
  overflow: hidden;
}
</style>