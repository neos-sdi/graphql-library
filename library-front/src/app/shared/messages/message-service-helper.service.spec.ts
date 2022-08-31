import { TestBed } from '@angular/core/testing';

import { MessageServiceHelperService } from './message-service-helper.service';

describe('MessageServiceHelperService', () => {
  let service: MessageServiceHelperService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MessageServiceHelperService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
