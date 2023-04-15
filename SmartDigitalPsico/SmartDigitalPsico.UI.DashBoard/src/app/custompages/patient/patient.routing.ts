import { Routes } from '@angular/router';
import { PatientComponent } from './patient.component';
import { AddEditPatientComponent } from './add-edit-patient/add-edit-patient.component';
import { PatientAdditionalInformationComponent } from './additionalinformation/patient_additionalinformation.component';
import { AddEditPatientAdditionalInformationComponent } from './additionalinformation/add-edit-patient_additionalinformation.component';

export const PatientRoutes: Routes = [{
    path: '',
    children: [{
        //path: 'pages/Patient',
        path: '',
        component: PatientComponent
    }, {
        path: 'patientaction',
        //title: 'navbar.patient',
        component: AddEditPatientComponent
    }, {
        path: 'additionalinformation',
        //title: 'navbar.patient',
        component: PatientAdditionalInformationComponent
    }, {
        path: 'additionalinformationaction',
        //title: 'navbar.patient',
        component: AddEditPatientAdditionalInformationComponent
    }
    ]
}];
