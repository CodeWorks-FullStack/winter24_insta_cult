import { Account } from "./Account.js";
import { DatabaseItem } from "./DatabaseItem.js";

export class Cult extends DatabaseItem {
  constructor(data) {
    super(data)
    this.name = data.name
    this.description = data.description
    this.coverImg = data.coverImg
    this.leaderId = data.leaderId
    this.leader = new Account(data.leader)
  }
}
