using JS.Abp.CommentManagement.Comments;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.CommentManagement.EntityFrameworkCore;

[ConnectionStringName(CommentManagementDbProperties.ConnectionStringName)]
public class CommentManagementDbContext : AbpDbContext<CommentManagementDbContext>, ICommentManagementDbContext
{
    public DbSet<Comment> Comments { get; set; }
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public CommentManagementDbContext(DbContextOptions<CommentManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCommentManagement();
    }
}