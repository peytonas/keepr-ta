<template>
  <div id="create-keep-modal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">NEW KEEP</h5>
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
          <form @submit.prevent="createKeep">
            <div class="form-group">
              <label for="name">NAME</label>
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Enter name"
                v-model="newKeep.name"
                required
              />
            </div>
            <div class="form-group">
              <label for="imgurl">IMAGE URL</label>
              <input
                type="text"
                class="form-control"
                id="imgurl"
                placeholder="Enter imgurl"
                v-model="newKeep.img"
                required
              />
            </div>
            <div class="form-group">
              <label for="description">DESCRIPTION</label>
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Enter description"
                v-model="newKeep.description"
                required
              />
            </div>
            <audio id="kaching">
              <source src="../assets/ka-ching.mp3" type="audio/mpeg" />
            </audio>
            <button type="submit" class="btn btn-primary">CREATE KEEP</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
export default {
  name: "CreateKeepModal",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {},
  methods: {
    createKeep() {
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
        this.$store.dispatch("createKeep", this.newKeep);
        this.newKeep = {};
        this.modalClose();
      }, 500);
    },
    modalClose() {
      setTimeout(function() {
        $("#create-keep-modal").modal("hide");
      }, 500);
    }
  },
  components: {}
};
</script>