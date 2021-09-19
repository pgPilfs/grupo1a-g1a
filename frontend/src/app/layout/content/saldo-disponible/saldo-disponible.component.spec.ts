import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaldoDisponibleComponent } from './saldo-disponible.component';

describe('SaldoDisponibleComponent', () => {
  let component: SaldoDisponibleComponent;
  let fixture: ComponentFixture<SaldoDisponibleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SaldoDisponibleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SaldoDisponibleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
