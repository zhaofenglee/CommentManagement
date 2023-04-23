using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace JS.Abp.CommentManagement;

[Dependency(ReplaceServices = true)]
public class CommentManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CommentManagement";
}
