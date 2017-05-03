import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from '../public/login/login.component';
import { DashboardComponent } from '../features/dashboard/dashboard.component';
import { AuthCheckActivator } from '../services/authcheck.service';

const mainRoutes: Routes = [
    {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'dashboard',
        component: DashboardComponent
        //canActivate: [AuthCheckActivator]
    },
    { path: '**', component: LoginComponent }
];

const appRoutes: Routes = [
    ...mainRoutes
];

export const routing = RouterModule.forRoot(appRoutes);