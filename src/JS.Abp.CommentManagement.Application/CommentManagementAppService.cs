using JS.Abp.CommentManagement.Localization;
using Volo.Abp.Application.Services;

namespace JS.Abp.CommentManagement;

public abstract class CommentManagementAppService : ApplicationService
{
    protected CommentManagementAppService()
    {
        LocalizationResource = typeof(CommentManagementResource);
        ObjectMapperContext = typeof(CommentManagementApplicationModule);
    }
}
