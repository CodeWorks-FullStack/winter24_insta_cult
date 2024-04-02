<template>
  <form @submit.prevent="destroyCultMember()">
    <label for="cultMemberId">Select a cult member to excommunicate</label>
    <select id="cultMemberId" v-model="editableCultMemberId" class="form-select" aria-label="Default select example"
      required>
      <option selected value="0" disabled>Open this select menu</option>
      <option v-for="cultist in cultists" :key="cultist.id" :value="cultist.cultMemberId">
        {{ cultist.name }}
      </option>
    </select>
    <div>
      <button class="btn btn-danger" type="submit" :disabled="editableCultMemberId == 0">Excommunicate</button>
    </div>
  </form>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState.js'
import Pop from '../utils/Pop.js'
import { cultMembersService } from '../services/CultMembersService.js'

export default {
  setup() {
    const editableCultMemberId = ref(0)
    return {
      editableCultMemberId,
      cultists: computed(() => AppState.cultists),

      async destroyCultMember() {
        try {
          const yes = await Pop.confirm()

          if (!yes) return

          await cultMembersService.destroyCultMember(editableCultMemberId.value)
          editableCultMemberId.value = 0
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