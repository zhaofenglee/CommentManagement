using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using JS.Abp.CommentManagement.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace JS.Abp.CommentManagement.Comments
{
    public class MongoCommentRepository : MongoDbRepository<CommentManagementMongoDbContext, Comment, Guid>, ICommentRepository
    {
        public MongoCommentRepository(IMongoDbContextProvider<CommentManagementMongoDbContext> dbContextProvider)
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
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, entityType, entityId, text, repliedCommentId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CommentConsts.GetDefaultSorting(false) : sorting);
            return await query.As<IMongoQueryable<Comment>>()
                .PageBy<Comment, IMongoQueryable<Comment>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
           string filterText = null,
           string entityType = null,
           string entityId = null,
           string text = null,
           Guid? repliedCommentId = null,
           CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, entityType, entityId, text, repliedCommentId);
            return await query.As<IMongoQueryable<Comment>>().LongCountAsync(GetCancellationToken(cancellationToken));
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