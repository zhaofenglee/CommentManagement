using Volo.Abp;
using Volo.Abp.MongoDB;

namespace JS.Abp.CommentManagement.MongoDB;

public static class CommentManagementMongoDbContextExtensions
{
    public static void ConfigureCommentManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
