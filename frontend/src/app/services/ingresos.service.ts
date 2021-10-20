import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IngresosService {

  url="https://localhost:44303/api/IngresoDine";
  constructor(private http:HttpClient) { }


  ObtenerCvu(id:string | null)
  {
    return this.http.get<any>(this.url+"/"+id);
  }


}
