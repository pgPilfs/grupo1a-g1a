import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CuentaService {
  url="https://localhost:44303/api/Cuenta";
  constructor(private http:HttpClient) { }


  ObtenerUltimosMovimientos(id:string | null)
  {
    return this.http.get<any>(this.url+"/"+id);
  }

  ObtenerSaldo(id:string | null)
  {
    return this.http.get<any>(this.url+"/"+id);
  }

  onTransferir(transfiere:Movimiento):Observable<Movimiento>{
    return this.http.post<Movimiento>(this.url, transfiere);
  }
}

export class Movimiento
{
  cvuOrigen: string="";
  cvuDestino:string="";
  monto:number=0;
  id_movimiento:number=0;

}
