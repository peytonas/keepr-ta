<template>
  <!-- <audio id="oof">
      <source src="../assets/roblox-oof.mp3" type="audio/mpeg" />
  </audio>-->
  <li class="dropdown-item" @click="goVault">{{vaultProp.name}}</li>
  <!-- <button class="btn btn-danger mb-1 delete" @click.prevent="deleteVault">
      <i class="fas fa-dumpster-fire ml-n1"></i>
  </button>-->
</template>
<script>
import swal from "sweetalert2";
export default {
  name: "vaults",
  props: ["vaultProp"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    goVault() {
      this.$router.push({
        name: "vaultKeeps",
        params: { vaultId: this.vaultProp.id }
      });
      this.$store.dispatch("getVault", this.vaultProp.id);
    },
    deleteVault() {
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
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Do it."
        })
        .then(result => {
          if (result.value) {
            //put the sound below
            roblox.play();
            setTimeout(() => {
              toast.fire("it's gone jim!", "", "success");
              this.$store.dispatch("deleteVault", this.vaultProp.id);
            }, 500);
          }
        });
    }
  },
  components: {}
};
</script>
<style>
</style>