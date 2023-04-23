import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class CommentManagementService {
  apiName = 'CommentManagement';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/CommentManagement/sample' },
      { apiName: this.apiName }
    );
  }
}
