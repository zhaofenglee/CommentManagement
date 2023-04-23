using JS.Abp.CommentManagement.Comments;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace JS.Abp.CommentManagement.MongoDB;

[ConnectionStringName(CommentManagementDbProperties.ConnectionStringName)]
public class CommentManagementMongoDbContext : AbpMongoDbContext, ICommentManagementMongoDbContext
{
    public IMongoCollection<Comment> Comments => Collection<Comment>();
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureCommentManagement();

        modelBuilder.Entity<Comment>(b => { b.CollectionName = CommentManagementDbProperties.DbTablePrefix + "Comments"; });
    }
}