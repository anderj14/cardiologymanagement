import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HolterStudyComponent } from './holter-study.component';

describe('HolterStudyComponent', () => {
  let component: HolterStudyComponent;
  let fixture: ComponentFixture<HolterStudyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HolterStudyComponent]
    });
    fixture = TestBed.createComponent(HolterStudyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
