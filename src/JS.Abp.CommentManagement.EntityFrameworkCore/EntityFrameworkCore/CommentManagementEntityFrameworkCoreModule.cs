using JS.Abp.CommentManagement.Comments;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JS.Abp.CommentManagement.EntityFrameworkCore;

[DependsOn(
    typeof(CommentManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class CommentManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CommentManagementDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<Comment, Comments.EfCoreCommentRepository>();

        });
    }
}