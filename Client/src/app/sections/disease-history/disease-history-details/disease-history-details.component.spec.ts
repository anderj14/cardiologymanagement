import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiseaseHistoryDetailsComponent } from './disease-history-details.component';

describe('DiseaseHistoryDetailsComponent', () => {
  let component: DiseaseHistoryDetailsComponent;
  let fixture: ComponentFixture<DiseaseHistoryDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiseaseHistoryDetailsComponent]
    });
    fixture = TestBed.createComponent(DiseaseHistoryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
