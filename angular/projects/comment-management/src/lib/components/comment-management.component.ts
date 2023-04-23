import { Component, OnInit } from '@angular/core';
import { CommentManagementService } from '../services/comment-management.service';

@Component({
  selector: 'lib-comment-management',
  template: ` <p>comment-management works!</p> `,
  styles: [],
})
export class CommentManagementComponent implements OnInit {
  constructor(private service: CommentManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
