import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngresodineroComponent } from './ingresodinero.component';

describe('IngresodineroComponent', () => {
  let component: IngresodineroComponent;
  let fixture: ComponentFixture<IngresodineroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IngresodineroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IngresodineroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
