import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElectrocardiogramComponent } from './electrocardiogram.component';

describe('ElectrocardiogramComponent', () => {
  let component: ElectrocardiogramComponent;
  let fixture: ComponentFixture<ElectrocardiogramComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ElectrocardiogramComponent]
    });
    fixture = TestBed.createComponent(ElectrocardiogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
