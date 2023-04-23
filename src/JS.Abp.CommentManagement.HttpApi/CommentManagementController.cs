using JS.Abp.CommentManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace JS.Abp.CommentManagement;

public abstract class CommentManagementController : AbpControllerBase
{
    protected CommentManagementController()
    {
        LocalizationResource = typeof(CommentManagementResource);
    }
}
