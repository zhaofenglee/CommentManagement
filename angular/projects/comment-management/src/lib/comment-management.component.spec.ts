import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { CommentManagementComponent } from './components/comment-management.component';
import { CommentManagementService } from '@j-s.Abp/comment-management';
import { of } from 'rxjs';

describe('CommentManagementComponent', () => {
  let component: CommentManagementComponent;
  let fixture: ComponentFixture<CommentManagementComponent>;
  const mockCommentManagementService = jasmine.createSpyObj('CommentManagementService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [CommentManagementComponent],
      providers: [
        {
          provide: CommentManagementService,
          useValue: mockCommentManagementService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommentManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
