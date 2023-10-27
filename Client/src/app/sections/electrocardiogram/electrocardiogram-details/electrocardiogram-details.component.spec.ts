import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElectrocardiogramDetailsComponent } from './electrocardiogram-details.component';

describe('ElectrocardiogramDetailsComponent', () => {
  let component: ElectrocardiogramDetailsComponent;
  let fixture: ComponentFixture<ElectrocardiogramDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ElectrocardiogramDetailsComponent]
    });
    fixture = TestBed.createComponent(ElectrocardiogramDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
