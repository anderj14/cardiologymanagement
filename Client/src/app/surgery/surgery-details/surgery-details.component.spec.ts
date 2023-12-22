import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SurgeryDetailsComponent } from './surgery-details.component';

describe('SurgeryDetailsComponent', () => {
  let component: SurgeryDetailsComponent;
  let fixture: ComponentFixture<SurgeryDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SurgeryDetailsComponent]
    });
    fixture = TestBed.createComponent(SurgeryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
