using JS.Abp.CommentManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace JS.Abp.CommentManagement.Blazor.Server.Host;

public abstract class CommentManagementComponentBase : AbpComponentBase
{
    protected CommentManagementComponentBase()
    {
        LocalizationResource = typeof(CommentManagementResource);
    }
}
