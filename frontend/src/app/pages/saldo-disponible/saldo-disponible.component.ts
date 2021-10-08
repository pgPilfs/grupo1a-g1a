import { Component, OnInit } from '@angular/core';
import { CuentaService } from 'src/app/services/cuenta.service';

@Component({
  selector: 'app-saldo-disponible',
  templateUrl: './saldo-disponible.component.html',
  styleUrls: ['./saldo-disponible.component.css']
})
export class SaldoDisponibleComponent implements OnInit {

  hoy= new Date();

  saldo: any;

  constructor(private cuentaService:CuentaService) { }

  ngOnInit(): void {
    this.cuentaService.ObtenerSaldo(2).subscribe(
      data=> {
        console.log(data);
        this.saldo=data['saldo'];
      }
    );
  }

}
