import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';  
import { CustomPagesModule } from 'app/custommodules/custompages.module';
import { RoleGroupComponent } from './rolegroup.component';
import { RoleGroupRoutes } from './rolegroup.routing';
import { RoleGroupService } from 'app/services/general/simple/rolegroup.service';
import { AddEditRolegGroupComponent } from './add-edit-rolegroup/add-edit-rolegroup.component';
@NgModule({
    imports: [
        CustomPagesModule,
        RouterModule.forChild(RoleGroupRoutes),
    ],
    declarations: [
        RoleGroupComponent, 
        AddEditRolegGroupComponent
    ]
    ,
    providers: [
        RoleGroupService
    ],
})

export class RoleGroupModule { }
