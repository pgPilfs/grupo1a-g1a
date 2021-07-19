import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  nombre = new FormControl('pancho');

  constructor() { }
 

  ngOnInit(): void {
  }

  guardar(){
    console.log(this.nombre.value);
  }

  
}


