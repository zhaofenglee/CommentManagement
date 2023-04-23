import { TestBed } from '@angular/core/testing';
import { CommentManagementService } from './services/comment-management.service';
import { RestService } from '@abp/ng.core';

describe('CommentManagementService', () => {
  let service: CommentManagementService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(CommentManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
