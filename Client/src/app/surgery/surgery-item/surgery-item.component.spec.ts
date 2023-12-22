import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SurgeryItemComponent } from './surgery-item.component';

describe('SurgeryItemComponent', () => {
  let component: SurgeryItemComponent;
  let fixture: ComponentFixture<SurgeryItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SurgeryItemComponent]
    });
    fixture = TestBed.createComponent(SurgeryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
