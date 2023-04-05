import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CustomPagesModule } from 'app/custommodules/custompages.module';  
import { PatientService } from 'app/services/general/principals/patient.service';
import { PatientComponent } from './patient.component';
import { PatientRoutes } from './patient.routing';
import { AddEditPatientComponent } from './add-edit-patient/add-edit-patient.component'; 
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(PatientRoutes)
       
    ],
    declarations: [
        PatientComponent, 
        AddEditPatientComponent,  
    ]
    ,
    providers: [
        PatientService, 
    ],
})

export class PatientModule { }
