import { MedicalModel } from "../principalsmodel/MedicalModel";

export interface BaseEntityPatientChildModel {
    patientId: number;
    patient: MedicalModel;
}