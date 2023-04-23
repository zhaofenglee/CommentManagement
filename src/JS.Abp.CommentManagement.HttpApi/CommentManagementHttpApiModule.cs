using Localization.Resources.AbpUi;
using JS.Abp.CommentManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace JS.Abp.CommentManagement;

[DependsOn(
    typeof(CommentManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CommentManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CommentManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CommentManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
