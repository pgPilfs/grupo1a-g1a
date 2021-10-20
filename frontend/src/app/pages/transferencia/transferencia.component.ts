import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Movimiento, CuentaService } from 'src/app/services/cuenta.service';

@Component({
  selector: 'app-transferencia',
  templateUrl: './transferencia.component.html',
  styleUrls: ['./transferencia.component.css']
})
export class TransferenciaComponent implements OnInit {

  form: FormGroup;
  cvu: any;
  transferencia: Movimiento = new Movimiento();
  error: string="";

  constructor(private formBuilder: FormBuilder,private cuentaService: CuentaService,
    private router: Router) {
      this.form= this.formBuilder.group(
        {
          monto:['',[Validators.min(1)]],

          cvuDestino:['']
        }
      )
      this.cvu = localStorage.getItem('codigo');
    }

  ngOnInit(): void {

  }

/*
  get monto()
  {
    return this.form.get("monto");
  }

  get cvuDestino()
  {
    return this.form.get("cvuDestino");
  }

  get montoInvalid()
  {
    return this.monto?.touched && !this.monto.valid;
  }

  get cvuInvalid()
  {
    return this.cvuDestino?.touched || this.cvuDestino?.dirty
  }

*/

  onEnviar(event: Event, transferencia: Movimiento)
  {
    event.preventDefault;

    if (this.form.valid)
    {
      transferencia.cvuOrigen=this.cvu;
      console.log(transferencia);
      this.cuentaService.onTransferir(transferencia).subscribe(
        data => {
          console.log(data);
          if (data['id_movimiento']>0)
          {
            alert("Se realizado la transferencia exitosamente");
            this.router.navigate(['/exito'])
          }
      })
  }
  else
  {
    this.form.markAllAsTouched();
  }
  }

}
