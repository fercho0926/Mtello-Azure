import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users/users.component';
import { RolesComponent } from './roles/roles.component';
import { PermissionsComponent } from './permissions/permissions.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { ViewUserComponent } from './users/view-user/view-user.component';
import { MaterialModule } from 'app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddUserComponent } from './users/add-user/add-user.component';



@NgModule({
  declarations: [
    AddUserComponent,
    PermissionsComponent,
    RolesComponent,
    UserManagementComponent,
    UsersComponent,
    ViewUserComponent,
  ],
  imports: [
     FormsModule,
     MaterialModule,
     ReactiveFormsModule,
     CommonModule,


  ]
})
export class UserManagementModule { }
