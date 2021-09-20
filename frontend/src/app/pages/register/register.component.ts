
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { Usuario, UsuarioService } from 'src/app/services/usuarios.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  formulario:FormGroup;
  usuario: Usuario = new Usuario();



 /* formularioll = new FormGroup({
    nombre : new FormControl('', [Validators.required]),
    apellido : new FormControl('', [Validators.required]),
    nacimiento : new FormControl('', [Validators.required]),
    usuario : new FormControl('', [Validators.required]),
    mail : new FormControl('', [Validators.required, Validators.email]),
    contrasena : new FormControl('', [Validators.required]),
    telefono : new FormControl('', [Validators.required]),
    pais : new FormControl('', [Validators.required]),
    provincia : new FormControl('', [Validators.required]),
    ciudad : new FormControl('', [Validators.required])
  });*/




  constructor(private formBuilder: FormBuilder, private usuarioService: UsuarioService, private router: Router) {
    this.formulario= this.formBuilder.group(
      {
        nombre : new FormControl('', [Validators.required]),
        apellido : new FormControl('', [Validators.required]),
        fecha_nacimiento : new FormControl('', [Validators.required]),
        username : new FormControl('', [Validators.required]),
        email : new FormControl('', [Validators.required, Validators.email]),
        contrasena : new FormControl('', [Validators.required]),
        telefono : new FormControl('', [Validators.required]),
        pais : new FormControl('', [Validators.required]),
        provincia : new FormControl('', [Validators.required]),
        ciudad : new FormControl('', [Validators.required])
      }
    )
   }

  ngOnInit(): void {
  }

  get nombre(){
    return this.formulario.get('nombre');
  }

 /* registra(newName: HTMLInputElement, newApellido: any, newFecha: any, newUsuario: any, newMail:any, newPass:any){
    this.data.addUser({
      nombre: newName.value,
      apellido: newApellido,
      nacimiento: newFecha,
      usuario: newUsuario,
      email: newMail,
      contrasena: newPass
    });
    return false;
  }*/




  onEnviar(event: Event, usuario:Usuario): void {
    event.preventDefault;

    if (this.formulario.valid)
    {
      console.log(usuario);
      this.usuarioService.onCrearRegistro(usuario).subscribe(
        data => {
          console.log(data);
          if (data['id_usuario']>0)
          {
            alert("El registro ha sido creado satisfactoriamente. A continuación, por favor Inicie Sesión.");
            this.router.navigate(['/login'])
          }
      })
  }
  else
  {
    this.formulario.markAllAsTouched();
  }
};

get Contrasena()
{
  return this.formulario.get("contrasena");
}
/*get pass()
{
  return this.form.get("password2");
}*/

get Username()
{
  return this.formulario.get("username");
}

get Mail()
{
 return this.formulario.get("email");
}

get Nombre()
{
  return this.formulario.get("nombre");
}

get Apellido()
{
 return this.formulario.get("apellido");
}

get FechaNacimiento()
{
 return this.formulario.get("fecha_nacimiento");
}

/*get Dni()
{
 return this.form.get("dni");
}*/

get MailValid()
{
  return this.Mail?.touched && !this.Mail?.valid;
}

get NombreValid()
{
  return this.Nombre?.touched && !this.Nombre?.valid;
}

get ApellidoValid()
{
  return this.Apellido?.touched && !this.Apellido?.valid;
}
get ContrasenaValid()
{
  return this.Contrasena?.touched && !this.Contrasena?.valid;
}

/*get Password2Valid()
{
  return this.Password2?.touched && !this.Password2?.valid;
}*/

get FechaNacimientoValid()
{
  return this.FechaNacimiento?.touched && !this.FechaNacimiento?.valid;
}

get UsernameValid(){
  return this.Username?.touched && !this.Username?.valid;
}

/*get DniValid()
{
  return this.Dni?.touched && !this.Dni?.valid;
}
*/
}

//(submit)="registra(newName, newApellido, newFecha, newUsuario, newMail, newPass)"


