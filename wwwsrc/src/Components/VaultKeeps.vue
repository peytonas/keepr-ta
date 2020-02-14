<template>
  <div class="keeps col-2 mt-2 mb-2">
    <!-- <p>{{this.keeps()}}</p> -->
    <img class="keep bg-dark" :src="keepProp.img" @click.prevent="viewKeep" />
    <p>{{keepProp.description}}</p>
    <p>VIEWS: {{keepProp.views}} | VAULTED: {{keepProp.keeps}}</p>
    <audio id="oof">
      <source src="../assets/roblox-oof.mp3" type="audio/mpeg" />
    </audio>
    <div class="pos text-dark">
      <p class="count">{{this.keeps()}}</p>
    </div>
    <div class="pos" v-if="this.$route.name != 'login'">
      <button
        class="btn fab btn-danger"
        @click.prevent="deleteKeep"
        v-if="user.id == this.keepProp.userId"
      >
        <i class="fas fa-dumpster-fire"></i>
      </button>
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
.keeps {
  position: relative;
  margin-left: 2px;
  margin-right: 2px;
  padding-left: 5px;
  padding-right: 5px;
}
.count {
  position: relative;
  left: -14rem;
  top: 0rem;
  height: 30px;
  width: 30px;
  font-size: 12px;
  display: flex;
}
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