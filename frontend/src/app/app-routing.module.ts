import { ExitoComponent } from './pages/exito/exito.component';
import { RetirosComponent } from './pages/retiros/retiros.component';
import { TransferenciaComponent } from './pages/transferencia/transferencia.component';
import { UserlogedComponent } from './pages/userloged/userloged.component';
import { SaldoDisponibleComponent } from './pages/saldo-disponible/saldo-disponible.component';
import { MovimientosComponent } from './pages/movimientos/movimientos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForgetPassComponent } from './pages/forget-pass/forget-pass.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent} from './pages/register/register.component';
import { IngresodineroComponent } from './pages/ingresodinero/ingresodinero.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { LogoutComponent } from './pages/logout/logout.component';
import {AuthGuard} from 'src/app/services/auth/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', redirectTo: '', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'forget-pass', component: ForgetPassComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'ingdinero', component: IngresodineroComponent, canActivate: [AuthGuard] },
  { path: 'userloged', component: UserlogedComponent, canActivate:  [AuthGuard]},
  { path: 'logout', component: LogoutComponent },
  { path: 'movimiento', component: MovimientosComponent, canActivate:  [AuthGuard ] },
  { path: 'usuario', component: UserlogedComponent },
  { path: 'saldo', component: SaldoDisponibleComponent, canActivate:  [AuthGuard] },
  { path: 'transferir', component: TransferenciaComponent, canActivate: [AuthGuard]},
  { path: 'retirar', component: RetirosComponent, canActivate: [AuthGuard]},
  { path: 'exito', component: ExitoComponent, canActivate: [AuthGuard]},
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
