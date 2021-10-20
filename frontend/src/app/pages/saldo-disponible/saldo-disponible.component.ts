import { Usuario } from './../../services/usuarios.service';
import { UsuarioService } from 'src/app/services/usuarios.service';
import { Component, OnInit } from '@angular/core';
import { CuentaService } from 'src/app/services/cuenta.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { IngresosService } from 'src/app/services/ingresos.service';
const users = 'users';
const codigo = "codigo";

@Component({
  selector: 'app-saldo-disponible',
  templateUrl: './saldo-disponible.component.html',
  styleUrls: ['./saldo-disponible.component.css']
})
export class SaldoDisponibleComponent implements OnInit {

  hoy= new Date();

  saldo: any;
  user: any;
  count: any;
  estaAutenticado:boolean=false;

  constructor(private cvuService:IngresosService, private cuentaService:CuentaService, private usuarioservice:UsuarioService, private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.estaAutenticado.subscribe(res=>( this.estaAutenticado=res));


if (this.authService.estaAutenticado.subscribe(res=>( this.estaAutenticado=res))){


    this.user =this.usuarioservice.ObtenerUsuario(localStorage.getItem('emails')).subscribe(
      data=> {
        console.log(data);
        localStorage.setItem(users, data);


        this.cuentaService.ObtenerSaldo(localStorage.getItem('users')).subscribe(
          data=> {
            console.log(data);
            this.saldo=data['saldo'];
          }
        );

        this.cvuService.ObtenerCvu(localStorage.getItem('users')).subscribe(
          data=> {
            console.log(data);
            localStorage.setItem(codigo, data);
          }
        );
      }
    );


  }
  }
}
