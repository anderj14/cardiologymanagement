import { TestBed } from '@angular/core/testing';

import { DiseaseHistoryService } from './disease-history.service';

describe('DiseaseHistoryService', () => {
  let service: DiseaseHistoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DiseaseHistoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
