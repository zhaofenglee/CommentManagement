using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JS.Abp.CommentManagement.Comments
{
    public class CommentCreateDto
    {
        [StringLength(CommentConsts.EntityTypeMaxLength)]
        public string? EntityType { get; set; }
        [StringLength(CommentConsts.EntityIdMaxLength)]
        public string? EntityId { get; set; }
        public string? Text { get; set; }
        public Guid? RepliedCommentId { get; set; }
    }
}