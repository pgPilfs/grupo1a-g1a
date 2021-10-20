import { RetiroService } from './../../services/retiro.service';
import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Movimiento1 } from 'src/app/services/retiro.service';

@Component({
  selector: 'app-retiros',
  templateUrl: './retiros.component.html',
  styleUrls: ['./retiros.component.css']
})
export class RetirosComponent implements OnInit {

  form: FormGroup;
  cvu: any;
  cvuD: any;
  retiro: Movimiento1 = new Movimiento1();
  error: string="";

  constructor(private formBuilder: FormBuilder,private retiroService: RetiroService,
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

  onEnviar(event: Event, retiro: Movimiento1)
  {
    event.preventDefault;

    if (this.form.valid)
    {
      retiro.cvuOrigen=this.cvu;
      retiro.cvuDestino = this.cvu;
      console.log(retiro);
      this.retiroService.onRetiro(retiro).subscribe(
        data => {
          console.log(data);
          if (data['id_movimiento']>0)
          {
            alert("Se realizado el retiro exitosamente");
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
