import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  url="https://localhost:44303/api/Usuario";

  constructor(private http:HttpClient) { }

  onCrearRegistro(usuario:Usuario):Observable<Usuario>{
    return this.http.post<Usuario>(this.url, usuario);
  }

  ObtenerUsuario(mail:string |null )
  {
    return this.http.get<any>(this.url+"?mail="+mail);
  }

}

export class Usuario
{
  username: string="";
  nombre:string="";
  apellido:string="";
  email:string="";
  contrasena:string="";
  telefono:string="";
  fecha_nacimiento:string="";


  id_usuario:number=0;

}

export class  LoginRequest {
  //id_usuario: any = "";
  //user:string = "";
  //nombre:string="";
  //apellido:string="";
  //telefono:string=""
  UserName:string="";
  Password:string="";
  Token?: any = "";
}


