import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { MovimientosComponent } from '../pages/movimientos/movimientos.component';


@Injectable({
  providedIn: 'root'
})
export class RetiroService {
  url="https://localhost:44303/api/Retiro";
  constructor(private http:HttpClient) { }


  ObtenerUltimosMovimientos(id:string | null)
  {
    return this.http.get<any>(this.url+"/"+id);
  }

  onRetiro(retira:Movimiento1):Observable<Movimiento1>{
    return this.http.post<Movimiento1>(this.url, retira);
  }
}

export class Movimiento1
{
  cvuOrigen: string="";
  cvuDestino:string="";
  monto:number=0;
  id_movimiento:number=0;

}
