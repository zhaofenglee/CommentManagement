using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.CommentManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(CommentManagementBlazorModule),
    typeof(CommentManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
)]
public class CommentManagementBlazorWebAssemblyModule : AbpModule
{

}
