using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace JS.Abp.CommentManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class CommentManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CommentManagement";
}
