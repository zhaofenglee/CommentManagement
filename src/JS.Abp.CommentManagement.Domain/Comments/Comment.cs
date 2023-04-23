using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace JS.Abp.CommentManagement.Comments
{
    public class Comment : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? EntityType { get; set; }

        [CanBeNull]
        public virtual string? EntityId { get; set; }

        [CanBeNull]
        public virtual string? Text { get; set; }

        public virtual Guid? RepliedCommentId { get; set; }

        public Comment()
        {

        }

        public Comment(Guid id, string entityType, string entityId, string text, Guid? repliedCommentId = null)
        {

            Id = id;
            Check.Length(entityType, nameof(entityType), CommentConsts.EntityTypeMaxLength, 0);
            Check.Length(entityId, nameof(entityId), CommentConsts.EntityIdMaxLength, 0);
            EntityType = entityType;
            EntityId = entityId;
            Text = text;
            RepliedCommentId = repliedCommentId;
        }

    }
}