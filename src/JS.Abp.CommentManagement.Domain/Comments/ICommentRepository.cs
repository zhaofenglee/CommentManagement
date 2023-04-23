using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace JS.Abp.CommentManagement.Comments
{
    public interface ICommentRepository : IRepository<Comment, Guid>
    {
        Task<List<Comment>> GetListAsync(
            string filterText = null,
            string entityType = null,
            string entityId = null,
            string text = null,
            Guid? repliedCommentId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string entityType = null,
            string entityId = null,
            string text = null,
            Guid? repliedCommentId = null,
            CancellationToken cancellationToken = default);
    }
}