<template>
  <div class="row">
    <div class="col-3 text-left ml-2">
      <form @submit.prevent="checkCharacters(newChip.name)">
        <div class="input-group mb-3">
          <input
            type="text"
            class="form-control"
            placeholder="filter by name or description..."
            v-model="newChip.name"
          />
          <div class="input-group-append">
            <button class="btn btn-primary" type="submit">add</button>
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
      <span class="pointer" @click.prevent="deleteChip(chip)">&times;</span>
    </div>
    <div class="pointer text-warning ml-1 mt-1" @click.prevent="resetChips()">
      <p>clear filters</p>
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
      const toast = swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 2000
      });
      this.$emit("newChip", this.newChip.name);
      this.chips.push(this.newChip);
      toast.fire("", "", "success");
      this.newChip = {};
    },

    deleteChip(chip) {
      this.$emit("deleteChip", chip);
      this.chips = this.chips.filter(c => c.name !== chip.name);
    },

    resetChips() {
      this.$emit("resetChips");
      this.chips = [];
    },

    checkCharacters(chipName) {
      const toast = swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 2000
      });
      var letterNumber = /^[0-9a-zA-Z]+$/;
      if (chipName.match(letterNumber)) {
        this.createChip();
      } else {
        this.newChip = {};
        toast.fire("invalid character", "", "error");
        return false;
      }
    }
  }
};
</script>
<style>
.pointer {
  cursor: pointer;
}
p {
  font-size: 0.75rem;
}
</style>