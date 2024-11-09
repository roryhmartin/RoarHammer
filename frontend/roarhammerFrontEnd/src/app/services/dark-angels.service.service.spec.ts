import { TestBed } from '@angular/core/testing';

import { DarkAngelsServiceService } from './dark-angels.service.service';

describe('DarkAngelsServiceService', () => {
  let service: DarkAngelsServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DarkAngelsServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
