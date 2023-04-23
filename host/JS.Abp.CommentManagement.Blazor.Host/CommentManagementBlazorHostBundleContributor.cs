using Volo.Abp.Bundling;

namespace JS.Abp.CommentManagement.Blazor.Host;

public class CommentManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
