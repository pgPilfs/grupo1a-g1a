import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';



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
    mail : new FormControl('', [Validators.required, Validators.email]),
    contrasena : new FormControl('', [Validators.required]),
  });
  

  constructor(
    public data: AuthService
  ) { }
 

  ngOnInit(): void {
  }

  get nombre(){
    return this.formulario.get('nombre');
  }

  registra(newName: HTMLInputElement, newApellido: any, newFecha: any, newUsuario: any, newMail:any, newPass:any){
    this.data.addUser({
      nombre: newName.value,
      apellido: newApellido,
      nacimiento: newFecha,
      usuario: newUsuario,
      email: newMail,
      contrasena: newPass
    });
    return false;
  }

  
}


