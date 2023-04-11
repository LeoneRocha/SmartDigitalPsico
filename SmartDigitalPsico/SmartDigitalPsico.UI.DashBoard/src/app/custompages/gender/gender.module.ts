import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router'; 
import { GenderService } from 'app/services/general/simple/gender.service';
import { GenderComponent } from './gender.component';
import { GenderRoutes } from './gender.routing';
import { AddEditGenderComponent } from './add-edit-gender/add-edit-gender.component'; 
import { GenericDataTableGrid } from 'app/components/genericdatatablegrid/genericdatatablegrid.component';
import { CustomPagesModule } from 'app/custommodules/custompages.module';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient } from '@angular/common/http';
import { NgxTranslateModule } from 'app/translate/translate.module';

 
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(GenderRoutes), 
        NgxTranslateModule,    
    ],
    declarations: [
        GenderComponent,
        AddEditGenderComponent,  
        GenericDataTableGrid
    ]
    ,
    providers: [
        GenderService
    ],
})

export class GenderModule { }
