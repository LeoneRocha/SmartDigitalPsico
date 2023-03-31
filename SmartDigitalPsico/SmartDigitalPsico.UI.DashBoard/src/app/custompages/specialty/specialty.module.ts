import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CustomPagesModule } from 'app/custommodules/custompages.module';
import { SpecialtyComponent } from './specialty.component';
import { SpecialtyService } from 'app/services/general/simple/specialty.service';
import { SpecialtyRoutes } from './specialty.routing';
import { AddEditSpecialtyComponent } from './add-edit-specialty/add-edit-specialty.component';
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(SpecialtyRoutes),
    ],
    declarations: [
        SpecialtyComponent,
        AddEditSpecialtyComponent
    ],
    providers: [
        SpecialtyService
    ],
})

export class SpecialtyModule { }