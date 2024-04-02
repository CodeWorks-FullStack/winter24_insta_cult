import { AppState } from "../AppState.js"
import { Cultist } from "../models/Cultist.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CultMembersService {
  async createCultMember(cultId) {
    const response = await api.post('api/cultMembers', { cultId })
    logger.log('CREATED CULT MEMBER', response.data)
    const newCultist = new Cultist(response.data)
    AppState.cultists.push(newCultist)
    // AppState.cultists.push(new Cultist(response.data))
  }

  async getCultistsbyCultId(cultId) {
    const response = await api.get(`api/cults/${cultId}/cultMembers`)
    logger.log('GOT CULTISTS', response.data)
    AppState.cultists = response.data.map(pojo => new Cultist(pojo))
  }

  async destroyCultMember(cultMemberId) {
    const response = await api.delete(`api/cultMembers/${cultMemberId}`)
    logger.log('DESTROYED CULT MEMBER', response.data)
    const index = AppState.cultists.findIndex(cultist => cultist.cultMemberId == cultMemberId)
    if (index == -1) throw new Error("Find index did not work, dawg")
    AppState.cultists.splice(index, 1)
  }
}

export const cultMembersService = new CultMembersService()