import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StressTestDetailsComponent } from './stress-test-details.component';

describe('StressTestDetailsComponent', () => {
  let component: StressTestDetailsComponent;
  let fixture: ComponentFixture<StressTestDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StressTestDetailsComponent]
    });
    fixture = TestBed.createComponent(StressTestDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
