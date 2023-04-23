using JS.Abp.CommentManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JS.Abp.CommentManagement.Pages;

public abstract class CommentManagementPageModel : AbpPageModel
{
    protected CommentManagementPageModel()
    {
        LocalizationResourceType = typeof(CommentManagementResource);
    }
}
