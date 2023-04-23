using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using JS.Abp.CommentManagement.EntityFrameworkCore;

namespace JS.Abp.CommentManagement.Comments
{
    public class EfCoreCommentRepository : EfCoreRepository<CommentManagementDbContext, Comment, Guid>, ICommentRepository
    {
        public EfCoreCommentRepository(IDbContextProvider<CommentManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Comment>> GetListAsync(
            string filterText = null,
            string entityType = null,
            string entityId = null,
            string text = null,
            Guid? repliedCommentId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, entityType, entityId, text, repliedCommentId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CommentConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string entityType = null,
            string entityId = null,
            string text = null,
            Guid? repliedCommentId = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, entityType, entityId, text, repliedCommentId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Comment> ApplyFilter(
            IQueryable<Comment> query,
            string filterText,
            string entityType = null,
            string entityId = null,
            string text = null,
            Guid? repliedCommentId = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.EntityType.Contains(filterText) || e.EntityId.Contains(filterText) || e.Text.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(entityType), e => e.EntityType.Contains(entityType))
                    .WhereIf(!string.IsNullOrWhiteSpace(entityId), e => e.EntityId.Contains(entityId))
                    .WhereIf(!string.IsNullOrWhiteSpace(text), e => e.Text.Contains(text))
                    .WhereIf(repliedCommentId.HasValue, e => e.RepliedCommentId == repliedCommentId);
        }
    }
}