import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsByEmployeeComponent } from './details-by-employee.component';

describe('DetailsByEmployeeComponent', () => {
  let component: DetailsByEmployeeComponent;
  let fixture: ComponentFixture<DetailsByEmployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsByEmployeeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailsByEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
