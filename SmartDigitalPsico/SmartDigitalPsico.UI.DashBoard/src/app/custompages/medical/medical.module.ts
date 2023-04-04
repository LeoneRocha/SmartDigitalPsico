import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CustomPagesModule } from 'app/custommodules/custompages.module';  
import { MedicalService } from 'app/services/general/principals/medical.service';
import { MedicalComponent } from './medical.component';
import { MedicalRoutes } from './medical.routing';
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(MedicalRoutes),
    ],
    declarations: [
        MedicalComponent, 
    ]
    ,
    providers: [
        MedicalService
    ],
})

export class MedicalModule { }
