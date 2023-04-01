import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CustomPagesModule } from 'app/custommodules/custompages.module';
import { SpecialtyComponent } from './specialty.component';
import { SpecialtyService } from 'app/services/general/simple/specialty.service';
import { SpecialtyRoutes } from './specialty.routing';
import { AddEditSpecialtyComponent } from './add-edit-specialty/add-edit-specialty.component';
/*import { StoreModule } from '@ngrx/store';
import { createEntityReducer } from 'app/storeredux/reducers/serviceresponse.reducer';
import { SpecialtyEffect } from 'app/storeredux/effects/specialty.effects';
import { EffectsModule } from '@ngrx/effects';
import { SpecialtyModel } from 'app/models/simplemodel/SpecialtyModel';
*/
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(SpecialtyRoutes),
        //StoreModule.forFeature('myspecialties', createEntityReducer<SpecialtyModel>),
        //EffectsModule.forFeature([SpecialtyEffect])
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