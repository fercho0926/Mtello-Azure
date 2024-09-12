import { Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

export const routes: Routes = [
{

  path: '',
  component: LayoutComponent,
  children: [
    { path: 'home', component: SidebarComponent },
    // { path: 'about', component: AboutComponent },
    // { path: 'contact', component: ContactComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' }
  ]
}

];
