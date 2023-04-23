using System;

namespace JS.Abp.CommentManagement.Comments
{
    public class CommentExcelDto
    {
        public string? EntityType { get; set; }
        public string? EntityId { get; set; }
        public string? Text { get; set; }
        public Guid? RepliedCommentId { get; set; }
    }
}