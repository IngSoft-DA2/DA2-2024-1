import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ListaComponent } from './lista/lista.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  {
    path: 'lista',
    component: ListaComponent,
  },
  { path: '**', redirectTo: '/login' },
];
