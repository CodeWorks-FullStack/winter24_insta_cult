import { DatabaseItem } from "./DatabaseItem.js";
import { Profile } from "./Profile.js";

export class Cult extends DatabaseItem {
  constructor(data) {
    super(data)
    this.name = data.name
    this.description = data.description
    this.coverImg = data.coverImg
    this.leaderId = data.leaderId
    this.leader = new Profile(data.leader)
  }
}
