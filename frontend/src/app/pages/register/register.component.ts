import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  formulario = new FormGroup({
    nombre : new FormControl('', [Validators.required]),
    apellido : new FormControl('', [Validators.required]),
    nacimiento : new FormControl('', [Validators.required]),
    usuario : new FormControl('', [Validators.required]),
    mail : new FormControl('', [Validators.required]),
    contrasena : new FormControl('', [Validators.required]),
  });
  

  constructor() { }
 

  ngOnInit(): void {
  }

  guardar(){
    
  }

  
}


