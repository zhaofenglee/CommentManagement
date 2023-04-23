import { ModuleWithProviders, NgModule } from '@angular/core';
import { COMMENT_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CommentManagementConfigModule {
  static forRoot(): ModuleWithProviders<CommentManagementConfigModule> {
    return {
      ngModule: CommentManagementConfigModule,
      providers: [COMMENT_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
