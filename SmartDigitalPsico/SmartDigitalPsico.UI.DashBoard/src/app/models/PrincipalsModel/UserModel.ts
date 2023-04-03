import { BaseEntityMedicalChildModel } from "../contracts/BaseEntityMedicalChildModel";
import { BaseEntityModel } from "../contracts/BaseEntityModel"; 

export interface UserModel extends BaseEntityModel, BaseEntityMedicalChildModel {
    language: string; 
    timeZone: string; 
    login: string;      
    password: string; 
}