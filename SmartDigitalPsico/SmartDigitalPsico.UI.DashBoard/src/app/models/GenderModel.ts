
export interface ServiceResponse<T>    {
  data: T[];
  success: boolean; 
  message: string; 
}


export interface GenderModel extends SimpleModel {
  
}


export interface SimpleModel {
  id: number;
  description: string; 
  language: string; 
}


export interface ApiEndPoints { 
  GetAll: string;  
}
