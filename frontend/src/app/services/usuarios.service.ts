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


  id_usuario:number=2;
  
}


