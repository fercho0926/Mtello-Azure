import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users/users.component';
import { RolesComponent } from './roles/roles.component';
import { PermissionsComponent } from './permissions/permissions.component';
import { UserManagementComponent } from './user-management/user-management.component';
// import { MatLegacyTooltipModule as MatTooltipModule } from '@angular/material/legacy-tooltip';
// import { MaterialModule } from 'app/material/material.module';
// import { AddUserComponent } from './users/add-user/add-user.component';
// import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ViewUserComponent } from './users/view-user/view-user.component';



@NgModule({
  declarations: [
    UsersComponent,
    RolesComponent,
    PermissionsComponent,
    UserManagementComponent,
    // AddUserComponent,
    ViewUserComponent,
    
  ],
  imports: [
    CommonModule,
    // MaterialModule,
    // ReactiveFormsModule,
    // FormsModule,


  ]
})
export class UserManagementModule { }
