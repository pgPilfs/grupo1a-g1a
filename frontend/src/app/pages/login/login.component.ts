import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import {AuthService} from 'src/app/services/auth/auth.service'
import {LoginRequest} from 'src/app/services/usuarios.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 form: FormGroup;
 contactForm: FormGroup;
  usuario: LoginRequest = new LoginRequest();
  error: string="";

  constructor(private formBuilder: FormBuilder,private authService: AuthService,
    private router: Router) {
    this.form= this.formBuilder.group(
      {
        password:['',[Validators.required, Validators.minLength(8)]],
        mail:['', [Validators.required, Validators.email]]
      }
    )
    this.contactForm = this.createFormGroup();

  }

  createFormGroup(){
    return new FormGroup({
      password: new FormControl('',[Validators.required, Validators.minLength(8)]),
        mail: new FormControl('', [Validators.required, Validators.email])
    })
  }

  ngOnInit(): void {
  }


  get mail()
  {
    return this.form.get("mail");
  }

  get pass()
  {
    return this.form.get("password");
  }

  get passInvalid()
  {
    return this.pass?.touched && !this.pass.valid;
  }

  get mailInvalid()
  {
    return this.mail?.touched || this.mail?.dirty
  }

  get mailNoValido()
  {
    return this.mail?.invalid;
  }

  


  onEnviar(event: Event, usuario: LoginRequest)
  {
    event.preventDefault(); //Cancela la funcionalidad por default.
    if (this.form.valid)
    {
      console.log(this.form.value); //se puede enviar al servidor...
      this.authService.login(this.usuario)
      .subscribe(
        data => {
        console.log("DATA"+ JSON.stringify( data));
        //localStorage.setItem('auth-token', JSON.stringify(data ));

        this.router.navigate(['userloged']);

        },
        error => {
         this.error = error;
        }
      );
    }
    else
    {
      this.form.markAllAsTouched(); //Activa todas las validaciones
    }
  }

}
