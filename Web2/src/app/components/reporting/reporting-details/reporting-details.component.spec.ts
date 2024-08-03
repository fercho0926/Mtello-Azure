import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportingDetailsComponent } from './reporting-details.component';

describe('ReportingDetailsComponent', () => {
  let component: ReportingDetailsComponent;
  let fixture: ComponentFixture<ReportingDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportingDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
