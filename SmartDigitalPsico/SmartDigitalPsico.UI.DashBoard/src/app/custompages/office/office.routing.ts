import { Routes } from '@angular/router';  
import { OfficeComponent } from './office.component';

export const OfficeRoutes: Routes = [{
    path: '',
    children: [{
        //path: 'pages/office',
        path: '',
        component: OfficeComponent
    }]
}];
