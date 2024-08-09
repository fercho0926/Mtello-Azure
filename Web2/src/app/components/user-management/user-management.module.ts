import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users/users.component';
import { RolesComponent } from './roles/roles.component';
import { PermissionsComponent } from './permissions/permissions.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MaterialModule } from 'app/material/material.module';
import { AddUserComponent } from './users/add-user/add-user.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    UsersComponent,
    RolesComponent,
    PermissionsComponent,
    UserManagementComponent,
    AddUserComponent,
    
  ],
  imports: [
    CommonModule,
    MatTooltipModule,
    MaterialModule,
    ReactiveFormsModule

  ]
})
export class UserManagementModule { }
