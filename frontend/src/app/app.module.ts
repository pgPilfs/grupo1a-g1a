import { CuentaService } from './services/cuenta.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { LayoutModule } from "./layout/layout.module";
import { PagesModule } from './pages/pages.module';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './services/auth.service';

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
  providers: [AuthService, CuentaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
