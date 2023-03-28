import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';  
import { JwBootstrapSwitchNg2Module } from 'jw-bootstrap-switch-ng2'; 
import { OfficeComponent } from './office.component';
import { OfficeService } from 'app/services/general/simple/office.service';
import { OfficeRoutes } from './office.routing';
import { AddEditOfficeComponent } from './add-edit-office/add-edit-office.component';
@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(OfficeRoutes),
        FormsModule,
        ReactiveFormsModule,
        JwBootstrapSwitchNg2Module,
    ],
    declarations: [
        OfficeComponent ,
        AddEditOfficeComponent,  
    ]
    ,
    providers: [
        OfficeService
    ],
})

export class OfficeModule { }
