import { TestBed } from '@angular/core/testing';

import { JobAdderService } from './job-adder.service';

describe('JobService', () => {
  let service: JobAdderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JobAdderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
