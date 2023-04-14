import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CustomPagesModule } from 'app/custommodules/custompages.module';
import { PatientService } from 'app/services/general/principals/patient.service';
import { PatientComponent } from './patient.component';
import { PatientRoutes } from './patient.routing';
import { AddEditPatientComponent } from './add-edit-patient/add-edit-patient.component';
import { GenderService } from 'app/services/general/simple/gender.service';
import { DatePipe } from '@angular/common';
import { LanguageService } from 'app/services/general/language.service';
import { NgxTranslateModule } from 'app/translate/translate.module';
import { PatientAdditionalInformationComponent } from './additionalinformation/patient_additionalinformation.component';
import { PatientAdditionalInformationService } from 'app/services/general/principals/patientadditionalinformation.service';
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(PatientRoutes),
        NgxTranslateModule,
    ],
    declarations: [
        PatientComponent,
        AddEditPatientComponent,
        PatientAdditionalInformationComponent
    ]
    ,
    providers: [
        PatientService
        , GenderService
        , DatePipe
        , LanguageService
        , PatientAdditionalInformationService
    ],
})

export class PatientModule { }
