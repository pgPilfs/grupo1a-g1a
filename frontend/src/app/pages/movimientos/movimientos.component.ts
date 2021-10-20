import { RetiroService } from './../../services/retiro.service';
import { UsuarioService } from './../../services/usuarios.service';
import { Component, OnInit } from '@angular/core';
import { CuentaService } from 'src/app/services/cuenta.service';
import { AuthService } from 'src/app/services/auth/auth.service';
const movs = 'movs';

@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {
  estaAutenticado:boolean=false;
  mostrar_movimientos=true;
  hoy= new Date();
  movimientos: any;
  user: any;
  count: any;


  constructor(private retiroService:RetiroService, private usuarioservice:UsuarioService, private authService: AuthService) {}

  ngOnInit(): void {


    if (this.authService.estaAutenticado.subscribe(res=>( this.estaAutenticado=res))){
      this.retiroService.ObtenerUltimosMovimientos(localStorage.getItem('codigo')).subscribe(
        data=> {
          console.log(data);
          this.movimientos=data['movimientos'];
        }
      );
    }


  }



}
