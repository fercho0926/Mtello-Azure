import { Routes } from '@angular/router';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserManagementComponent } from 'app/components/user-management/user-management/user-management.component';
import { ChecksComponent } from 'app/components/checks/checks.component';
import { ReportingComponent } from 'app/components/reporting/reporting.component';
import { ReportingDetailsComponent } from 'app/components/reporting/reporting-details/reporting-details.component';
import { LoginComponent } from '../../auth/login/login.component';
import { DetailsByEmployeeComponent } from 'app/components/reporting/details-by-employee/details-by-employee.component';
import { CreateComponent } from 'app/components/checks/create/create.component';
import { CompanyGridComponent } from 'app/components/company/company-grid/company-grid.component';
import { ViewUserComponent } from 'app/components/user-management/users/view-user/view-user.component';

export const AdminLayoutRoutes: Routes = [

    { path: 'dashboard',      component: DashboardComponent },
    { path: 'checks',      component: ChecksComponent },
    {path: 'user-management', component: UserManagementComponent},
    {path: 'reporting', component: ReportingComponent},
    {path: 'reporting-details/:reportingId', component: ReportingDetailsComponent},
    {path: 'reporting-details-by-employee/:employeeId', component: DetailsByEmployeeComponent},
    {path: 'login', component: LoginComponent},
    {path: 'create', component: CreateComponent},
    {path: 'company', component: CompanyGridComponent},
    {path: 'user-details', component: ViewUserComponent}




];
    
