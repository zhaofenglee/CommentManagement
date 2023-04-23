using JS.Abp.CommentManagement.Comments;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace JS.Abp.CommentManagement.MongoDB;

[ConnectionStringName(CommentManagementDbProperties.ConnectionStringName)]
public interface ICommentManagementMongoDbContext : IAbpMongoDbContext
{
    IMongoCollection<Comment> Comments { get; }
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}