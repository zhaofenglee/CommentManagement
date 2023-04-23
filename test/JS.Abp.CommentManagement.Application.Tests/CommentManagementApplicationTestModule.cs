using Volo.Abp.Modularity;

namespace JS.Abp.CommentManagement;

[DependsOn(
    typeof(CommentManagementApplicationModule),
    typeof(CommentManagementDomainTestModule)
    )]
public class CommentManagementApplicationTestModule : AbpModule
{

}
