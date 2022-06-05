import { TestBed } from '@angular/core/testing';

import { AdminNewsGetAllResolver } from './admin-news-get-all.resolver';

describe('AdminNewsGetAllResolver', () => {
  let resolver: AdminNewsGetAllResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(AdminNewsGetAllResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
