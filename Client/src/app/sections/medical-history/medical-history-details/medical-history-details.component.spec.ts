import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalHistoryDetailsComponent } from './medical-history-details.component';

describe('MedicalHistoryDetailsComponent', () => {
  let component: MedicalHistoryDetailsComponent;
  let fixture: ComponentFixture<MedicalHistoryDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MedicalHistoryDetailsComponent]
    });
    fixture = TestBed.createComponent(MedicalHistoryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
