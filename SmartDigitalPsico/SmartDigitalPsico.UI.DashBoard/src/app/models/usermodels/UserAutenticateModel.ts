import { TokenAuth } from "../general/TokenAuth"
import { RoleGroupModel } from "../simplemodel/RoleGroupModel"

export interface UserAutenticateModel {
    id: number 
    name: string
    tokenAuth: TokenAuth
    roleGroups: RoleGroupModel[]
  }
  