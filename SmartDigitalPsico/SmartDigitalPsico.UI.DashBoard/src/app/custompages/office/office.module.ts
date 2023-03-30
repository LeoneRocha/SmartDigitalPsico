import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OfficeComponent } from './office.component';
import { OfficeService } from 'app/services/general/simple/office.service';
import { OfficeRoutes } from './office.routing';
import { AddEditOfficeComponent } from './add-edit-office/add-edit-office.component';
import { CustomPagesModule } from 'app/custommodules/custompages.module';
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(OfficeRoutes),
    ],
    declarations: [
        OfficeComponent,
        AddEditOfficeComponent,
    ]
    ,
    providers: [
        OfficeService
    ],
})

export class OfficeModule { }
