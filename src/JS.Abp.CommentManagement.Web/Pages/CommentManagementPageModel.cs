using JS.Abp.CommentManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JS.Abp.CommentManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CommentManagementPageModel : AbpPageModel
{
    protected CommentManagementPageModel()
    {
        LocalizationResourceType = typeof(CommentManagementResource);
        ObjectMapperContext = typeof(CommentManagementWebModule);
    }
}
