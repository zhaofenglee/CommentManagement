using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using JS.Abp.CommentManagement.Permissions;
using JS.Abp.CommentManagement.Comments;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using JS.Abp.CommentManagement.Shared;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace JS.Abp.CommentManagement.Comments
{

    [Authorize(CommentManagementPermissions.Comments.Default)]
    public class CommentsAppService : ApplicationService, ICommentsAppService
    {
        private readonly IDistributedCache<CommentExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICommentRepository _commentRepository;
        private readonly CommentManager _commentManager;
        protected IdentityUserRepositoryExternalUserLookupServiceProvider UserLookupServiceProvider { get; }
        
        public CommentsAppService(ICommentRepository commentRepository, 
            CommentManager commentManager, 
            IDistributedCache<CommentExcelDownloadTokenCacheItem, string> excelDownloadTokenCache,
            IdentityUserRepositoryExternalUserLookupServiceProvider userLookupServiceProvider)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _commentRepository = commentRepository;
            _commentManager = commentManager;
            UserLookupServiceProvider = userLookupServiceProvider;
        }

        public virtual async Task<PagedResultDto<CommentWithUserDto>> GetListAsync(GetCommentsInput input)
        {
            var totalCount = await _commentRepository.GetCountAsync(input.FilterText, input.EntityType, input.EntityId, input.Text, input.RepliedCommentId);
            var items = await _commentRepository.GetListAsync(input.FilterText, input.EntityType, input.EntityId, input.Text, input.RepliedCommentId, input.Sorting, input.MaxResultCount, input.SkipCount);

            var dtos = items.Select(queryResultItem =>
            {
                var dto = ObjectMapper.Map<Comment, CommentWithUserDto>(queryResultItem);
                dto.Author = ObjectMapper.Map<IUserData, CommentUserDto>((UserLookupServiceProvider.FindByIdAsync((Guid)queryResultItem.CreatorId)).Result);

                return dto;
            }).ToList();
            return new PagedResultDto<CommentWithUserDto>
            {
                TotalCount = totalCount,
                Items = dtos
            };
        }

        public virtual async Task<CommentDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Comment, CommentDto>(await _commentRepository.GetAsync(id));
        }

        [Authorize(CommentManagementPermissions.Comments.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _commentRepository.DeleteAsync(id);
        }

        [Authorize(CommentManagementPermissions.Comments.Create)]
        public virtual async Task<CommentDto> CreateAsync(CommentCreateDto input)
        {

            var comment = await _commentManager.CreateAsync(
            input.EntityType, input.EntityId, input.Text, input.RepliedCommentId
            );

            return ObjectMapper.Map<Comment, CommentDto>(comment);
        }

        [Authorize(CommentManagementPermissions.Comments.Edit)]
        public virtual async Task<CommentDto> UpdateAsync(Guid id, CommentUpdateDto input)
        {

            var comment = await _commentManager.UpdateAsync(
            id,
            input.EntityType, input.EntityId, input.Text, input.RepliedCommentId, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Comment, CommentDto>(comment);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CommentExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _commentRepository.GetListAsync(input.FilterText, input.EntityType, input.EntityId, input.Text, input.RepliedCommentId);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Comment>, List<CommentExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Comments.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CommentExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}