<template>
  <div v-if="cult" class="container-fluid">
    <section class="row cult-bg align-items-center">
      <div class="col-12">
        <h1>{{ cult.name }}</h1>
        <div>
          <button @click="createCultMember(cult.id)" v-if="account.id" class="btn btn-danger">Join Cult</button>
        </div>
      </div>
    </section>
    <section class="row">
      <div class="col-md-6 p-4">
        <p>{{ cult.description }}</p>
      </div>
      <div class="col-md-6 p-4">
        <div class="mb-4">
          <h2>{{ cult.leader.name }}</h2>
          <img :src="cult.leader.picture" :alt="cult.leader.name" class="leader round-picture">
        </div>

        <div>
          <h3>Members</h3>
          <div>
            <img v-for="cultist in cultists" :key="cultist.id" :src="cultist.picture" :alt="cultist.name"
              class="round-picture cultist" :title="cultist.name">
          </div>
        </div>
      </div>
    </section>

  </div>

  <div v-else class="container-fluid">
    <section class="row">
      <div class="col-12">
        <h1>Loading...
          <i class="mdi mdi-loading mdi-spin"></i>
        </h1>
      </div>
    </section>
  </div>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import { cultMembersService } from '../services/CultMembersService.js';
import { computed, watch } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';

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

    async function getCultistsbyCultId(cultId) {
      try {
        await cultMembersService.getCultistsbyCultId(cultId)
      }
      catch (error) {
        Pop.error(error);
      }
    }

    watch(() => route.params.cultId, () => {
      getCultById(route.params.cultId)
      getCultistsbyCultId(route.params.cultId)
    }, { immediate: true })

    return {
      cult: computed(() => AppState.activeCult),
      cultBg: computed(() => `url(${AppState.activeCult?.coverImg})`),
      account: computed(() => AppState.account),
      cultists: computed(() => AppState.cultists),

      async createCultMember(cultId) {
        try {
          await cultMembersService.createCultMember(cultId)
        }
        catch (error) {
          Pop.error(error);
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.cult-bg {
  min-height: 55vh;
  background-size: cover;
  background-position: center;
  background-image:
    linear-gradient(black, black),
    v-bind(cultBg);
  background-blend-mode: saturation;
  border-bottom: .5em solid black;
}

h1 {
  color: red;
  text-shadow: 0 0 10px whitesmoke;
}

.round-picture {
  aspect-ratio: 1/1;
  border-radius: 50%;
}

.leader {
  height: 18vh;
}

.cultist {
  height: 12vh;
}
</style>