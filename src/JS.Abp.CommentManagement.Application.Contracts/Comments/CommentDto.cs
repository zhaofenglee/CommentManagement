using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace JS.Abp.CommentManagement.Comments
{
    public class CommentDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? EntityType { get; set; }
        public string? EntityId { get; set; }
        public string? Text { get; set; }
        public Guid? RepliedCommentId { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}