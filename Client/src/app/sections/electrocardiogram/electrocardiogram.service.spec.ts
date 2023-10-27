import { TestBed } from '@angular/core/testing';

import { ElectrocardiogramService } from './electrocardiogram.service';

describe('ElectrocardiogramService', () => {
  let service: ElectrocardiogramService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ElectrocardiogramService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
