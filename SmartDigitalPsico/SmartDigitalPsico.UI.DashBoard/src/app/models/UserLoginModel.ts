export interface UserLoginModel{    
    login: string; 
    password: string;     
  }  


  export interface UserAutenticateModel{    
    TokenAuth: string; 
    Email: string;   
    RoleGroups : []      
  }  