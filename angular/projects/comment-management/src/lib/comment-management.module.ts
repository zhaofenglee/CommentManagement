import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CommentManagementComponent } from './components/comment-management.component';
import { CommentManagementRoutingModule } from './comment-management-routing.module';

@NgModule({
  declarations: [CommentManagementComponent],
  imports: [CoreModule, ThemeSharedModule, CommentManagementRoutingModule],
  exports: [CommentManagementComponent],
})
export class CommentManagementModule {
  static forChild(): ModuleWithProviders<CommentManagementModule> {
    return {
      ngModule: CommentManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CommentManagementModule> {
    return new LazyModuleFactory(CommentManagementModule.forChild());
  }
}
