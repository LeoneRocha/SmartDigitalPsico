import { Routes } from '@angular/router';      
import { MedicalComponent } from './medical.component';

export const MedicalRoutes: Routes = [{
    path: '',
    children: [{
        //path: 'pages/medical',
        path: '',
        component: MedicalComponent
    }  ]
}];
