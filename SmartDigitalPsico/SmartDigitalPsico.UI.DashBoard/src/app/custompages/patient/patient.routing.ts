import { Routes } from '@angular/router';      
import { PatientComponent } from './patient.component';
import { AddEditPatientComponent } from './add-edit-patient/add-edit-patient.component';

export const PatientRoutes: Routes = [{
    path: '',
    children: [{
        //path: 'pages/Patient',
        path: '',
        component: PatientComponent
    } , {
        path: 'patientaction',
        //title: 'navbar.patient',
        component: AddEditPatientComponent
    } ]
}];
