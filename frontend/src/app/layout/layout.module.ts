import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SaldoDisponibleComponent } from './content/saldo-disponible/saldo-disponible.component';



@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    SaldoDisponibleComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    SaldoDisponibleComponent,
  ]
})
export class LayoutModule { }
