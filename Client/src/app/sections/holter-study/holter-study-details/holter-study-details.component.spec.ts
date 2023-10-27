import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HolterStudyDetailsComponent } from './holter-study-details.component';

describe('HolterStudyDetailsComponent', () => {
  let component: HolterStudyDetailsComponent;
  let fixture: ComponentFixture<HolterStudyDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HolterStudyDetailsComponent]
    });
    fixture = TestBed.createComponent(HolterStudyDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
