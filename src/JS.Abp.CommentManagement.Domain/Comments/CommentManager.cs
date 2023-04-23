using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace JS.Abp.CommentManagement.Comments
{
    public class CommentManager : DomainService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> CreateAsync(
        string entityType, string entityId, string text, Guid? repliedCommentId = null)
        {
            Check.Length(entityType, nameof(entityType), CommentConsts.EntityTypeMaxLength);
            Check.Length(entityId, nameof(entityId), CommentConsts.EntityIdMaxLength);

            var comment = new Comment(
             GuidGenerator.Create(),
             entityType, entityId, text, repliedCommentId
             );

            return await _commentRepository.InsertAsync(comment);
        }

        public async Task<Comment> UpdateAsync(
            Guid id,
            string entityType, string entityId, string text, Guid? repliedCommentId = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.Length(entityType, nameof(entityType), CommentConsts.EntityTypeMaxLength);
            Check.Length(entityId, nameof(entityId), CommentConsts.EntityIdMaxLength);

            var comment = await _commentRepository.GetAsync(id);

            comment.EntityType = entityType;
            comment.EntityId = entityId;
            comment.Text = text;
            comment.RepliedCommentId = repliedCommentId;

            comment.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _commentRepository.UpdateAsync(comment);
        }

    }
}