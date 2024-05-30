import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './guards/auth.guard';
// import { ListaComponent } from './lista/lista.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: HomeComponent },
  // { path: 'pets', component: PetsComponent, canActivate: [AuthGuard]},
  // {
  //   path: 'lista',
  //   component: ListaComponent,
  // },
  { path: '**', redirectTo: '/login' },
];
