import { Routes } from '@angular/router';
import { AdminLayoutComponent } from './layouts/admin/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth/auth-layout.component';

export const AppRoutes: Routes = [
    {
        path: '',
        redirectTo: 'adminpages/dashboard',
        pathMatch: 'full',
    },
    {
        path: 'adminpages',
        component: AdminLayoutComponent,
        children: [{
            path: 'dashboard',
            loadChildren: () => import('./dashboard/dashboard.module').then(x => x.DashboardModule)
        }, {
            path: 'gender',
            loadChildren: () => import('./custompages/gender/gender.module').then(x => x.GenderModule)
        }]
    },
    {
        path: 'pages',
        component: AdminLayoutComponent,
        children: [{
            path: 'user',
            loadChildren: () => import('./userpage/user.module').then(x => x.UserModule)
        }]
    }, {
        path: 'authpages',
        component: AuthLayoutComponent,
        children: [{
            path: '',
            loadChildren: () => import('./pages/pages.module').then(x => x.PagesModule)
        }]
    }
];
