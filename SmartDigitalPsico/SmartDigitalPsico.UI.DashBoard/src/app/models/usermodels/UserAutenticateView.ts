import { RoleGroupModel } from "../simplemodel/RoleGroupModel"

 
export interface UserAutenticateView {
    id: number 
    name: string 
    roleGroups: RoleGroupModel[]
  }

