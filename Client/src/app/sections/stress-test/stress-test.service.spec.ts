import { TestBed } from '@angular/core/testing';

import { StressTestService } from './stress-test.service';

describe('StressTestService', () => {
  let service: StressTestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StressTestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
