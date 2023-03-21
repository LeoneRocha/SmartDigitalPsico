export interface UserLoginModel{    
    login: string; 
    password: string;     
  }   
  export interface UserAutenticateView {
    id: number 
    name: string 
    roleGroups: RoleGroup[]
  }

  export interface UserAutenticateModel {
    id: number 
    name: string
    tokenAuth: TokenAuth
    roleGroups: RoleGroup[]
  }
  
  export interface TokenAuth {
    authenticated: boolean
    created: string
    expiration: string
    accessToken: string
    refreshToken: string
  } 
  export interface RoleGroup {
    id: number 
    description: string
    rolePolicyClaimCode: string 
  } 