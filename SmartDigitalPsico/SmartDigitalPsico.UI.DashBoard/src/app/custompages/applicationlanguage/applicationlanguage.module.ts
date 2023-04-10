import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';  
import { CustomPagesModule } from 'app/custommodules/custompages.module';   
import { ApplicationLanguageRoutes } from './applicationlanguage.routing';
import { ApplicationLanguageComponent } from './applicationlanguage.component';
import { AddEditApplicationLanguageComponent } from './add-edit-applicationlanguage/add-edit-applicationlanguage.component';
import { ApplicationLanguageService } from 'app/services/general/simple/applicationlanguage.service';
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(ApplicationLanguageRoutes),
    ],
    declarations: [
        ApplicationLanguageComponent ,
        AddEditApplicationLanguageComponent
    ]
    ,
    providers: [
        ApplicationLanguageService
    ],
})

export class ApplicationLanguageModule { }