import { TestBed } from '@angular/core/testing';

import { PickedUpOrdersService } from './picked-up-orders.service';

describe('PickedUpOrdersService', () => {
  let service: PickedUpOrdersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PickedUpOrdersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
