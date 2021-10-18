import { Component, OnInit, HostListener } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  estaAutenticado:boolean=false;

  constructor(private authService: AuthService,private router: Router) { }

  ngOnInit(): void {
    this.authService.estaAutenticado.subscribe(res=>( this.estaAutenticado=res));
  }

  onCerrarSesion(){
    this.authService.logOut();
    this.estaAutenticado=false;
    this.router.navigate(['/login']);
  }


  header_variable = false;
  @HostListener("document:scroll")
  scrollfunction(){
    if(document.body.scrollTop > 0 || document.documentElement.scrollTop > 0){
      this.header_variable = true;
    }
    else{
      this.header_variable = false;
    }
  }
}
