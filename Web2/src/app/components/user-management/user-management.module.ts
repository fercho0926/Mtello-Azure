import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users/users.component';
import { RolesComponent } from './roles/roles.component';
import { PermissionsComponent } from './permissions/permissions.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { MatTooltipModule } from '@angular/material/tooltip';



@NgModule({
  declarations: [
    UsersComponent,
    RolesComponent,
    PermissionsComponent,
    UserManagementComponent
    
  ],
  imports: [
    CommonModule,
    MatTooltipModule,
  ]
})
export class UserManagementModule { }
