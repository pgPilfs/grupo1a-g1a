import { UsuarioService } from './services/usuarios.service';
import { CuentaService } from './services/cuenta.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AuthService } from './services/auth/auth.service'
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './services/auth/interceptor.service';
import { LayoutModule } from "./layout/layout.module";
import { PagesModule } from './pages/pages.module';

import { ErrorInterceptor } from './services/auth/error.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    LayoutModule,
    PagesModule,
    HttpClientModule
  ],
  providers: [AuthService, CuentaService, UsuarioService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },],
  bootstrap: [AppComponent]
})
export class AppModule { }
