import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CustomPagesModule } from 'app/custommodules/custompages.module';  
import { MedicalService } from 'app/services/general/principals/medical.service';
import { MedicalComponent } from './medical.component';
import { MedicalRoutes } from './medical.routing';
import { AddEditMedicalComponent } from './add-edit-medical/add-edit-medical.component';
import { OfficeService } from 'app/services/general/simple/office.service';
import { SpecialtyService } from 'app/services/general/simple/specialty.service';  
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(MedicalRoutes)
       
    ],
    declarations: [
        MedicalComponent, 
        AddEditMedicalComponent,  
    ]
    ,
    providers: [
        MedicalService,
        OfficeService, SpecialtyService, 
    ],
})

export class MedicalModule { }
