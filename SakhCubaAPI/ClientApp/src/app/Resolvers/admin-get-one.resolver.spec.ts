import { TestBed } from '@angular/core/testing';

import { AdminGetOneResolver } from './admin-get-one.resolver';

describe('AdminGetOneResolver', () => {
  let resolver: AdminGetOneResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(AdminGetOneResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
