using Volo.Abp.EntityFrameworkCore.Modeling;
using JS.Abp.CommentManagement.Comments;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace JS.Abp.CommentManagement.EntityFrameworkCore;

public static class CommentManagementDbContextModelCreatingExtensions
{
    public static void ConfigureCommentManagement(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(CommentManagementDbProperties.DbTablePrefix + "Questions", CommentManagementDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        if (builder.IsHostDatabase())
        {
            builder.Entity<Comment>(b =>
{
    b.ToTable(CommentManagementDbProperties.DbTablePrefix + "Comments", CommentManagementDbProperties.DbSchema);
    b.ConfigureByConvention();
    b.Property(x => x.EntityType).HasColumnName(nameof(Comment.EntityType)).HasMaxLength(CommentConsts.EntityTypeMaxLength);
    b.Property(x => x.EntityId).HasColumnName(nameof(Comment.EntityId)).HasMaxLength(CommentConsts.EntityIdMaxLength);
    b.Property(x => x.Text).HasColumnName(nameof(Comment.Text));
    b.Property(x => x.RepliedCommentId).HasColumnName(nameof(Comment.RepliedCommentId));
});

        }
    }
}