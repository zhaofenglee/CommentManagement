using JS.Abp.CommentManagement.Comments;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.CommentManagement.EntityFrameworkCore;

[ConnectionStringName(CommentManagementDbProperties.ConnectionStringName)]
public interface ICommentManagementDbContext : IEfCoreDbContext
{
    DbSet<Comment> Comments { get; set; }
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}