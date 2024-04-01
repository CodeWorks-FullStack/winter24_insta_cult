<template>
  <div class="bg-slate">
    {{ cult.name }}
  </div>
</template>


<script>
import { Cult } from '../models/Cult.js'


export default {
  props: {
    cult: { type: Cult, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.bg-slate {
  background-color: #2F2C2C;
}
</style>