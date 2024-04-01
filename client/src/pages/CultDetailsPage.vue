<template>
  <h1>CULT DETAILS</h1>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import { onMounted, watch } from 'vue';

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

    return {}
  }
}
</script>


<style lang="scss" scoped></style>