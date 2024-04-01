<template>
  <div class="cult-card-bg text-light">
    <div class="d-flex align-items-center p-3">
      <img :src="cult.leader.picture" :alt="cult.leader.name" class="leader-picture">
      <p class="fs-3 ms-5 mb-0">{{ cult.leader.name }}</p>
    </div>
    <img :src="cult.coverImg" :alt="cult.name + `'s cover image`" class="cover-img my-3">
    <div class="p-3">
      <h2 class="fs-4">{{ cult.name }}</h2>
      <!-- <p>{{ cult.description.split(' ').slice(0, 6).join(' ') }}...</p> -->
      <p>{{ cult.description.substring(0, 30) }}...</p>
      <div class="text-end">
        <button class="btn btn-danger">
          See More
        </button>
      </div>
    </div>
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
.cult-card-bg {
  background-color: #2F2C2C;
  border: 2px solid red;
  border-radius: 16px;
  box-shadow: 3px 3px 10px rgba(255, 0, 0, 0.31);
}

.leader-picture {
  height: 15vh;
  aspect-ratio: 1/1;
  border-radius: 50%;
  object-fit: cover;
}

.cover-img {
  width: 100%;
  object-fit: cover;
  height: 40vh;
}

img {
  filter: grayscale(1);
}
</style>