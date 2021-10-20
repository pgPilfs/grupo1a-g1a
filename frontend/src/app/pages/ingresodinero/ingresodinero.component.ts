import { IngresosService } from 'src/app/services/ingresos.service';
import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Movimiento2 } from 'src/app/services/ingresos.service';

@Component({
  selector: 'app-ingresodinero',
  templateUrl: './ingresodinero.component.html',
  styleUrls: ['./ingresodinero.component.css']
})
export class IngresodineroComponent implements OnInit {

  mostrar:Boolean = false;
  lugares:Boolean=true;
  form: FormGroup;
  cvu: any;
  cvuD: any;
  ingreso: Movimiento2 = new Movimiento2();
  error: string="";


  constructor(private formBuilder: FormBuilder,private ingresoService: IngresosService,
    private router: Router) {
      this.form= this.formBuilder.group(
        {
          monto:['',[Validators.min(1)]],
        }
      )
      this.cvu = localStorage.getItem('codigo');
      this.cvuD =localStorage.getItem('codigo');
     }

  ngOnInit(): void {
  }

  mostrarOcultar(){
    if(this.mostrar){
      this.mostrar=false;
    }else{
      this.mostrar=true;
      this.lugares=false;
    }
  }

  onEnviar(event: Event, ingreso: Movimiento2)
  {
    event.preventDefault;

    if (this.form.valid)
    {
      ingreso.cvuOrigen=this.cvu;
      ingreso.cvuDestino = this.cvu;
      console.log(ingreso);
      this.ingresoService.onIngreso(ingreso).subscribe(
        data => {
          console.log(data);
          if (data['id_movimiento']>0)
          {
            alert("Se realizado el ingreso exitosamente");
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
