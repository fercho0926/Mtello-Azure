import { Routes } from '@angular/router';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { TableListComponent } from '../../table-list/table-list.component';
import { TypographyComponent } from '../../typography/typography.component';
import { IconsComponent } from '../../icons/icons.component';
import { MapsComponent } from '../../maps/maps.component';
import { NotificationsComponent } from '../../notifications/notifications.component';
import { UserManagementComponent } from 'app/components/user-management/user-management/user-management.component';
import { ChecksComponent } from 'app/components/checks/checks.component';
import { ReportingComponent } from 'app/components/reporting/reporting.component';
import { ReportingDetailsComponent } from 'app/components/reporting/reporting-details/reporting-details.component';
import { LoginComponent } from '../../auth/login/login.component';
import { DetailsByEmployeeComponent } from 'app/components/reporting/details-by-employee/details-by-employee.component';
import { CreateComponent } from 'app/components/checks/create/create.component';

export const AdminLayoutRoutes: Routes = [

    { path: 'dashboard',      component: DashboardComponent },
    { path: 'checks',      component: ChecksComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'table-list',     component: TableListComponent },
    { path: 'typography',     component: TypographyComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'notifications',  component: NotificationsComponent },
    {path: 'user-management', component: UserManagementComponent},
    {path: 'reporting', component: ReportingComponent},
    {path: 'reporting-details/:reportingId', component: ReportingDetailsComponent},
    {path: 'reporting-details-by-employee/:employeeId', component: DetailsByEmployeeComponent},
    {path: 'login', component: LoginComponent},
    {path: 'create', component: CreateComponent}



];
    
