<template>
  <form @submit.prevent="createCult()">
    <div class="mb-3">
      <label for="name" class="form-label">Cult Name</label>
      <input v-model="editableCultData.name" type="text" class="form-control" id="name" placeholder="Cult Name..."
        required maxlength="255">
    </div>

    <div class="mb-3">
      <label for="coverImg" class="form-label">Cult Cover Image</label>
      <input v-model="editableCultData.coverImg" type="text" class="form-control" id="coverImg"
        placeholder="Cult Cover Image..." required maxlength="1000">
    </div>

    <div class="mb-3">
      <label for="description" class="form-label">Cult Description</label>
      <textarea v-model="editableCultData.description" class="form-control" id="description" rows="3"
        maxlength="2000"></textarea>
    </div>

    <div class="text-end">
      <button class="btn btn-danger" type="submit">Submit</button>
    </div>

  </form>
</template>


<script>
import { ref } from 'vue'
import Pop from '../utils/Pop.js'
import { cultsService } from '../services/CultsService.js'
import { Modal } from 'bootstrap'
export default {
  setup() {
    const editableCultData = ref({ name: '', description: '', coverImg: '' })
    return {
      editableCultData,
      async createCult() {
        try {
          const cult = await cultsService.createCult(editableCultData.value)
          editableCultData.value = { name: '', description: '', coverImg: '' }
          Modal.getOrCreateInstance('#createCultModal').hide()
          Pop.success(`${cult.name} has been started, go recruit some members!`)
        }
        catch (error) {
          Pop.error(error);
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>