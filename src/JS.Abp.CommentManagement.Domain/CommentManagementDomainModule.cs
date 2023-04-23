using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace JS.Abp.CommentManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(CommentManagementDomainSharedModule)
)]
public class CommentManagementDomainModule : AbpModule
{

}
