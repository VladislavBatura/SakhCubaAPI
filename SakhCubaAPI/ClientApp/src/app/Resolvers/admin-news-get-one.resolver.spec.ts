import { TestBed } from '@angular/core/testing';

import { AdminNewsGetOneResolver } from './admin-news-get-one.resolver';

describe('AdminNewsGetOneResolver', () => {
  let resolver: AdminNewsGetOneResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(AdminNewsGetOneResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
