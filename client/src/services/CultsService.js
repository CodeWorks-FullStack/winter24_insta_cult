import { AppState } from "../AppState.js"
import { Cult } from "../models/Cult.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CultsService {
  async getCultById(cultId) {
    const response = await api.get(`api/cults/${cultId}`)
    logger.log('GOT CULT BY ID', response.data)
    AppState.activeCult = new Cult(response.data)
  }
  async getCults() {
    const response = await api.get('api/cults')
    logger.log('GOT CULTS', response.data)
    AppState.cults = response.data.map(pojo => new Cult(pojo))
  }

}

export const cultsService = new CultsService()