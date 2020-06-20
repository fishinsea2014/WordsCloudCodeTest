/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FetchWordsService } from './fetch-words.service';

describe('Service: FetchWords', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FetchWordsService]
    });
  });

  it('should ...', inject([FetchWordsService], (service: FetchWordsService) => {
    expect(service).toBeTruthy();
  }));
});
