import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CustomPagesModule } from 'app/custommodules/custompages.module';  
import { PatientService } from 'app/services/general/principals/patient.service';
import { PatientComponent } from './patient.component';
import { PatientRoutes } from './patient.routing';
import { AddEditPatientComponent } from './add-edit-patient/add-edit-patient.component'; 
import { GenderService } from 'app/services/general/simple/gender.service';
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
        PatientService, GenderService
    ],
})

export class PatientModule { }
