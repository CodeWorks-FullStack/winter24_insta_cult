import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CultsService {
  async getCults() {
    const response = await api.get('api/cults')
    logger.log('GOT CULTS', response.data)
  }

}

export const cultsService = new CultsService()