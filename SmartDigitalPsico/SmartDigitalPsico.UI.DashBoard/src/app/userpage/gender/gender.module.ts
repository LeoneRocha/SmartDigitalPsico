import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GenderService } from 'app/services/general/gender.service';
import { GenderComponent } from './gender.component';
import { GenderRoutes } from './gender.routing';
import { AddEditGenderComponent } from './add-edit-gender/add-edit-gender.component';
@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(GenderRoutes),
        FormsModule,
        ReactiveFormsModule
    ],
    declarations: [GenderComponent, AddEditGenderComponent],
    providers: [
        GenderService
    ],
})

export class GenderModule { }
