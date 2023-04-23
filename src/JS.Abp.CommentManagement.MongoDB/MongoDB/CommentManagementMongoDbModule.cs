using JS.Abp.CommentManagement.Comments;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace JS.Abp.CommentManagement.MongoDB;

[DependsOn(
    typeof(CommentManagementDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class CommentManagementMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<CommentManagementMongoDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, MongoQuestionRepository>();
             */
            options.AddRepository<Comment, Comments.MongoCommentRepository>();

        });
    }
}