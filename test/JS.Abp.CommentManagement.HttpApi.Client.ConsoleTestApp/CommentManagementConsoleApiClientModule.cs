using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace JS.Abp.CommentManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CommentManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CommentManagementConsoleApiClientModule : AbpModule
{

}
