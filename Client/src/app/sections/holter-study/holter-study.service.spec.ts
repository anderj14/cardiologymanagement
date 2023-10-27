import { TestBed } from '@angular/core/testing';

import { HolterStudyService } from './holter-study.service';

describe('HolterStudyService', () => {
  let service: HolterStudyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HolterStudyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
