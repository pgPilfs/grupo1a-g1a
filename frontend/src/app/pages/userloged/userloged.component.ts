import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-userloged',
  templateUrl: './userloged.component.html',
  styleUrls: ['./userloged.component.css']
})
export class UserlogedComponent implements OnInit {
  estaAutenticado:boolean=false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.estaAutenticado.subscribe(res=>( this.estaAutenticado=res));
  }

}
