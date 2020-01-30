<template>
  <div id="create-vault-modal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">NEW VAULT</h5>
          <button
            type="button"
            class="close btn btn-danger"
            data-dismiss="modal"
            aria-label="Close"
          >
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <audio id="oof">
            <source src="../assets/roblox-oof.mp3" type="audio/mpeg" />
          </audio>
          <form @submit.prevent="createVault">
            <div class="form-group">
              <label for="name">NAME</label>
              <input
                type="text"
                class="form-control"
                id="vaultName"
                placeholder="Enter name"
                v-model="newVault.name"
                required
              />
            </div>
            <div class="form-group">
              <label for="description">DESCRIPTION</label>
              <input
                type="text"
                class="form-control"
                id="vaultDescription"
                placeholder="Enter description"
                v-model="newVault.description"
                required
              />
            </div>
            <audio id="kaching">
              <source src="../assets/ka-ching.mp3" type="audio/mpeg" />
            </audio>
            <button type="submit" class="btn btn-primary">CREATE VAULT</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
export default {
  name: "create-vault-modal",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    createVault() {
      let money = document.getElementById("kaching");
      const toast = swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 2000
      });
      //put the sound below
      money.play();
      setTimeout(() => {
        toast.fire("it's alive!", "", "success");
        this.$store.dispatch("createVault", this.newVault);
        this.newVault = {};
        this.modalClose();
      }, 500);
    },
    modalClose() {
      setTimeout(function() {
        $("#create-vault-modal").modal("hide");
      }, 500);
    }
  },
  components: {}
};
</script>