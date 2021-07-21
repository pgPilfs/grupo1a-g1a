import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-ingresodinero',
  templateUrl: './ingresodinero.component.html',
  styleUrls: ['./ingresodinero.component.css']
})
export class IngresodineroComponent implements OnInit {

  mostrar:Boolean = false;
  lugares:Boolean=true;
  monto = new FormControl('', Validators.required);


  constructor() { }

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

}
