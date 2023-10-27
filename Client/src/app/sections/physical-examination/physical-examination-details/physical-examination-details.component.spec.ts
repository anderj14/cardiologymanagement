import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhysicalExaminationDetailsComponent } from './physical-examination-details.component';

describe('PhysicalExaminationDetailsComponent', () => {
  let component: PhysicalExaminationDetailsComponent;
  let fixture: ComponentFixture<PhysicalExaminationDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PhysicalExaminationDetailsComponent]
    });
    fixture = TestBed.createComponent(PhysicalExaminationDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
