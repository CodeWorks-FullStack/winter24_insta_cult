<template>
  <div class="container-fluid">
    <section class="row w-100">
      <div class="col-12">
        <div class="d-flex justify-content-center">

          <router-link to="cults">
            <button class="btn btn-danger me-3">Join A Cult?</button>
          </router-link>

          <button v-if="account.id" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#createCultModal">
            Start A Cult?
          </button>
        </div>
      </div>
    </section>
  </div>

  <ModalComponent />
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped lang="scss">
.container-fluid {
  min-height: 90dvh;
  background-image: url(https://images.unsplash.com/photo-1534269222346-5a896154c41d?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  display: flex;
  align-items: center;
  background-size: cover;
}
</style>
