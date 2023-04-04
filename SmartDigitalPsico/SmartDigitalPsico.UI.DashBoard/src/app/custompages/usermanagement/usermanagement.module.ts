import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';  
import { CustomPagesModule } from 'app/custommodules/custompages.module';  
import { UserManagementComponent } from './usermanagement.component';
import { UserManagementRoutes } from './usermanagement.routing';
import { UserService } from 'app/services/general/principals/user.service'; 
import { AddEditUserManagementComponent } from './add-edit-usermanagement/add-edit-usermanagement.component';
import { MedicalService } from 'app/services/general/principals/medical.service';
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(UserManagementRoutes),
    ],
    declarations: [
        UserManagementComponent,  
        AddEditUserManagementComponent
    ]
    ,
    providers: [
        UserService
        ,MedicalService        
    ],
})

export class UserManagementModule { }
