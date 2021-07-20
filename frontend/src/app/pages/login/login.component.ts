import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  @Input() email!: string;
  @Input() password!: string;

  constructor() { 
  }

  ngOnInit(): void {
  }

  login() {
    alert()
    console.log(this.email)
    console.log(this.password)
   }

}
