import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserlogedComponent } from './userloged.component';

describe('UserlogedComponent', () => {
  let component: UserlogedComponent;
  let fixture: ComponentFixture<UserlogedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserlogedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserlogedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
