import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';


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
}
