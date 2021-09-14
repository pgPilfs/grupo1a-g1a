import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ForgetPassComponent } from './forget-pass/forget-pass.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { IngresodineroComponent } from './ingresodinero/ingresodinero.component';
import { LayoutModule } from '../layout/layout.module';
import { LogoutComponent } from './logout/logout.component';




@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    NotFoundComponent,
    ForgetPassComponent,
    RegisterComponent,
    IngresodineroComponent,
    LogoutComponent,
    
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    LayoutModule
  ],
  exports: [
    HomeComponent
  ]
})
export class PagesModule { }
