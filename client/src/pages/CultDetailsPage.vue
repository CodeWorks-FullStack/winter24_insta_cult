<template>
  <div class="container-fluid">
    <section v-if="cult" class="row">
      <div class="col-12">
        <h1>{{ cult.name }}</h1>
      </div>
    </section>

    <section v-else class="row">
      <div class="col-12">
        <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
      </div>
    </section>
  </div>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import { computed, onMounted, watch } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {
    const route = useRoute()

    async function getCultById(cultId) {
      try {
        await cultsService.getCultById(cultId)
      }
      catch (error) {
        Pop.error(error);
      }
    }

    watch(() => route.params.cultId, () => {
      getCultById(route.params.cultId)
    }, { immediate: true })

    return {
      cult: computed(() => AppState.activeCult)
    }
  }
}
</script>


<style lang="scss" scoped></style>