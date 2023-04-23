using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.CommentManagement.EntityFrameworkCore;

public class CommentManagementHttpApiHostMigrationsDbContext : AbpDbContext<CommentManagementHttpApiHostMigrationsDbContext>
{
    public CommentManagementHttpApiHostMigrationsDbContext(DbContextOptions<CommentManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCommentManagement();
    }
}
