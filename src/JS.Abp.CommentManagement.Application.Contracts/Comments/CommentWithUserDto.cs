using System;

namespace JS.Abp.CommentManagement.Comments;

public class CommentWithUserDto
{
    public Guid Id { get; set; }
    public string? EntityType { get; set; }
    public string? EntityId { get; set; }
    public string? Text { get; set; }
    public Guid? RepliedCommentId { get; set; }

    public Guid CreatorId { get; set; }

    public DateTime CreationTime { get; set; }

    public CommentUserDto Author { get; set; }
}