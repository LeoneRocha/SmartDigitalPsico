import { Routes } from '@angular/router';    
import { RoleGroupComponent } from './rolegroup.component';
import { AddEditRolegGroupComponent } from './add-edit-rolegroup/add-edit-rolegroup.component';

export const RoleGroupRoutes: Routes = [{
    path: '',
    children: [{
        //path: 'pages/rolegroup',
        path: '',
        component: RoleGroupComponent
    } , {
        path: 'rolegroupaction',
        component: AddEditRolegGroupComponent
    }]
}];
