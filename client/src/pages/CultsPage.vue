<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">
        <h1 class="m-4 text-light">Cults Near You</h1>
      </div>
    </section>
  </div>
</template>


<script>
import { onMounted } from 'vue';
import { cultsService } from '../services/CultsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    async function getCults() {
      try {
        await cultsService.getCults()
      } catch (error) {
        Pop.error(error)
      }
    }

    onMounted(getCults)

    return {}
  }
}
</script>


<style lang="scss" scoped>
.container-fluid {
  background-color: #1A1919;
}

h1 {
  max-width: fit-content;
  border-top: 1px solid whitesmoke;
  padding-top: 1rem;
}
</style>