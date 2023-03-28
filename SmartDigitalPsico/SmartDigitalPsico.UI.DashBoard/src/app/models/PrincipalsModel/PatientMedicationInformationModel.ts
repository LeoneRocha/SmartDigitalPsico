import { SimpleModel } from "../contracts/SimpleModel";

export interface PatientMedicationInformationModel extends SimpleModel {
    startDate: Date;
    endDate: Date;
    dosage: string;
    posology: string;
    mainDrug: string;
}