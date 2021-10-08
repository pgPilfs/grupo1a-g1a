import { Component, OnInit } from '@angular/core';
import { CuentaService } from 'src/app/services/cuenta.service';


@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {
  mostrar_movimientos=true;
  hoy= new Date();
  movimientos: any;


  constructor(private cuentaService:CuentaService) {

   }

  ngOnInit(): void {
    this.cuentaService.ObtenerUltimosMovimientos(2).subscribe(
      data=> {
        console.log(data);
        this.movimientos=data['movimientos'];
      }
    );

  }

}
