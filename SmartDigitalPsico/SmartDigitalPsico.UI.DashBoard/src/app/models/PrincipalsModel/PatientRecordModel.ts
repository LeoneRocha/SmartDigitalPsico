import { BaseEntityPatientChildModel } from "../contracts/BaseEntityPatientChildModel";
import { SimpleModel } from "../contracts/SimpleModel";

export interface PatientRecordModel extends SimpleModel , BaseEntityPatientChildModel{
    annotation: string;
    annotationDate: Date;
}