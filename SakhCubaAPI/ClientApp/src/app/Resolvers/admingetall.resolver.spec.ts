import { TestBed } from '@angular/core/testing';

import { AdminGetResolver } from './admingetall.resolver';

describe('Admin.GetResolver', () => {
  let resolver: AdminGetResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(AdminGetResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
