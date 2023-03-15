import { Routes } from '@angular/router';
import { GenderComponent } from './gender/gender.component';

import { UserComponent } from './user.component';

export const UserRoutes: Routes = [{
    path: '',
    children: [{
        path: 'pages/user',
        component: UserComponent
    },{
        path: 'pages/gender',
        component: GenderComponent
    }]
}];
