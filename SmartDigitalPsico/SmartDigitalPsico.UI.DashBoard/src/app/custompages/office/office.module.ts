import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
import { JwBootstrapSwitchNg2Module } from 'jw-bootstrap-switch-ng2';
import { CountDownTimerComponent } from 'app/common/countdowntimer/countdowntimer.component';
import { CustomTextActivePipe } from 'app/common/custompipe/customtextactive.pipe'; 
import { OfficeRoutes } from './office.routing';
import { OfficeComponent } from './office.component';
import { OfficeService } from 'app/services/general/simple/office.service';
@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(OfficeRoutes),
        FormsModule,
        ReactiveFormsModule,
        JwBootstrapSwitchNg2Module,
    ],
    declarations: [
        OfficeComponent 
    ]
    ,
    providers: [
        OfficeService
    ],
})

export class OfficeModule { }
