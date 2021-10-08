import { Injectable } from '@angular/core';
import { User } from '../models/users';
import {HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginRequest } from './usuarios.service';
const TOKEN_KEY = 'auth-token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  users: User[];
  url="https://localhost:44303/api/login/authenticate";
  currentUserSubject: BehaviorSubject<LoginRequest>;
  currentUser: Observable<LoginRequest>;
  loggedIn= new BehaviorSubject<boolean>(false);

  constructor(private http:HttpClient) {
    this.users = []
    console.log("AUTH SERVICE WORKING");
    this.currentUserSubject = new  BehaviorSubject<LoginRequest>(JSON.parse(localStorage.getItem(TOKEN_KEY) || '{}'));
    this.currentUser = this.currentUserSubject.asObservable();
   }

   login(usuario: LoginRequest): Observable<any> {
    return this.http.post<LoginRequest>(this.url, usuario).pipe(map(data => {
      localStorage.setItem(TOKEN_KEY, data.Token);
                        
      this.currentUserSubject.next(data);
      this.loggedIn.next(true);
      return data;
    }));
  }
  get usuarioAutenticado(): LoginRequest {
    return this.currentUserSubject.value;
  }

  get estaAutenticado(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }

   logOut(): void {
    window.sessionStorage.clear();
    localStorage.removeItem(TOKEN_KEY);
    this.loggedIn.next(false);
  }

   getUser(){
     return this.users;
   }

   addUser(user:User){
     this.users.push(user);
     return false;
   }
 

  

  setToken(){}

  getToken(){
    return "token";
  }
}
