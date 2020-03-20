<template>
  <div class="row">
    <div class="col-2 text-left ml-2">
      <form @submit.prevent="createChip">
        <div class="input-group mb-3">
          <input
            type="text"
            class="form-control"
            placeholder="sort keeps by..."
            v-model="newChip.name"
          />
          <div class="input-group-append">
            <button class="btn btn-primary" type="button">add</button>
          </div>
        </div>
      </form>
    </div>
    <div
      class="border rounded-pill bg-dark text-danger mb-4 ml-1 pl-1 pr-1"
      color="primary"
      v-for="chip in chips"
      :key="chip.name"
    >
      {{chip.name}}
      <span class="pointer" @click="deleteChip">&times;</span>
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
export default {
  name: "Chips",
  data() {
    return {
      newChip: {},
      chips: []
    };
  },
  methods: {
    createChip() {
      let money = document.getElementById("kaching");
      const toast = swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 2000
      });
      this.chips.push(this.newChip);
      money.play();
      toast.fire("", "", "success");
      this.newChip = {};
    },
    deleteChip() {
      console.log("deleted");
    }
  }
};
</script>
<style>
.pointer {
  cursor: pointer;
}
</style>