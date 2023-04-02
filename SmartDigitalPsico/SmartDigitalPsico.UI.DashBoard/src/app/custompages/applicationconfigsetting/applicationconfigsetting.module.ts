import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';  
import { CustomPagesModule } from 'app/custommodules/custompages.module';  
import { ApplicationConfigSettingRoutes } from './applicationconfigsetting.routing';
import { ApplicationConfigSettingComponent } from './applicationconfigsetting.component'; 
import { ApplicationConfigSettingService } from 'app/services/general/simple/applicationconfigsetting.service';
import { AddEditApplicationConfigSettingComponent } from './add-edit-applicationconfigsetting/add-edit-applicationconfigsetting.component';
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(ApplicationConfigSettingRoutes),
    ],
    declarations: [
        ApplicationConfigSettingComponent ,
        AddEditApplicationConfigSettingComponent
    ]
    ,
    providers: [
        ApplicationConfigSettingService
    ],
})

export class ApplicationConfigSettingModule { }