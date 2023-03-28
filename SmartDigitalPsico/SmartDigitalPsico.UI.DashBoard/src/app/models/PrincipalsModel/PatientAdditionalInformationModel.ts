import { BaseEntityPatientChildModel } from "../contracts/BaseEntityPatientChildModel";
import { SimpleModel } from "../contracts/SimpleModel";

export interface PatientAdditionalInformationModel extends SimpleModel, BaseEntityPatientChildModel {    
    startDate: Date;
    endDate: Date;
    cid: string;
    observation: string;
}