export interface UserLoginModel{    
    login: string; 
    password: string;     
  }   
  export interface UserAutenticateModel {
    id: number
    enable: boolean
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
    enable: boolean
    description: string
    rolepolicyclaimcode: string
    language: string 
  } 