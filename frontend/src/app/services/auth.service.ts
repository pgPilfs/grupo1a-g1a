import { Injectable } from '@angular/core';
import { User } from '../models/users';
import {HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  users: User[];
  constructor() {
    this.users = [
      
      
    ]
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
