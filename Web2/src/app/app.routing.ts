import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { LoginComponent } from './auth/login/login.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes =[

  // {
  //   path: '',
  //   redirectTo: 'dashboard',
  //   pathMatch: 'full',
  // }, {
  //   path: '',
  //   component: AdminLayoutComponent,
  //   children: [{
  //     path: '',
  //     loadChildren: () => import('./layouts/admin-layout/admin-layout.module').then(m => m.AdminLayoutModule)
  //   }]
  // }

  {
    path: '',
    component: LoginComponent,
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
    pathMatch: 'full',
  },


  {
    path: 'dashboard',
   component:AdminLayoutComponent,
   canActivate: [AuthGuard], // Apply AuthGuard here
  //  canActivateChild: [AuthGuard], // Apply AuthGuard to all child routes


    pathMatch: 'full',
    children: [{
          path: '',
          loadChildren: () => import('./layouts/admin-layout/admin-layout.module').then(m => m.AdminLayoutModule)
        }]
  }, 

  
  {
    path: '',
    component: AdminLayoutComponent,
    canActivate: [AuthGuard], // Apply AuthGuard here
    // canActivateChild: [AuthGuard], // Apply AuthGuard to all child routes
    children: [{
      path: '',
      loadChildren: () => import('./layouts/admin-layout/admin-layout.module').then(m => m.AdminLayoutModule)
    }]
  },

  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes,{
       useHash: true
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
