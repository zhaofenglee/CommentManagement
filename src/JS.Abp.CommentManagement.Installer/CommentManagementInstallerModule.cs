using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace JS.Abp.CommentManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class CommentManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CommentManagementInstallerModule>();
        });
    }
}
