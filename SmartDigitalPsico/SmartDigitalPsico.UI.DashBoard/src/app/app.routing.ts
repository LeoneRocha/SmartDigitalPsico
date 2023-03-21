import { Routes } from '@angular/router';
import { AdminLayoutComponent } from './layouts/admin/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth/auth-layout.component';
import { AuthGuard } from './services/auth/auth-guard.service';

export const AppRoutes: Routes = [
    {
        path: '',
        redirectTo: 'authpages/login',
        pathMatch: 'full',
    },
    {
        path: 'adminpages',
        component: AdminLayoutComponent,
        children: [{
            path: 'dashboard',
            canActivate: [AuthGuard],
            loadChildren: () => import('./dashboard/dashboard.module').then(x => x.DashboardModule)
        }, {
            path: 'gender',
            canActivate: [AuthGuard],
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
