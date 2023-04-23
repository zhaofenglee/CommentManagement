using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.CommentManagement.Blazor.Server;

[DependsOn(
    typeof(CommentManagementBlazorModule),
    typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
public class CommentManagementBlazorServerModule : AbpModule
{

}
