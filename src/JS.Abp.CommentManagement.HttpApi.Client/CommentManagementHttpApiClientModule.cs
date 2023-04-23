using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace JS.Abp.CommentManagement;

[DependsOn(
    typeof(CommentManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CommentManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CommentManagementApplicationContractsModule).Assembly,
            CommentManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CommentManagementHttpApiClientModule>();
        });
    }
}
