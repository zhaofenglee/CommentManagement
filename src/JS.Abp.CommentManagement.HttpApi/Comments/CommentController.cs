using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using JS.Abp.CommentManagement.Comments;
using Volo.Abp.Content;
using JS.Abp.CommentManagement.Shared;

namespace JS.Abp.CommentManagement.Comments
{
    [RemoteService(Name = "CommentManagement")]
    [Area("commentManagement")]
    [ControllerName("Comment")]
    [Route("api/comment-management/comments")]
    public class CommentController : AbpController, ICommentsAppService
    {
        private readonly ICommentsAppService _commentsAppService;

        public CommentController(ICommentsAppService commentsAppService)
        {
            _commentsAppService = commentsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CommentWithUserDto>> GetListAsync(GetCommentsInput input)
        {
            return _commentsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CommentDto> GetAsync(Guid id)
        {
            return _commentsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CommentDto> CreateAsync(CommentCreateDto input)
        {
            return _commentsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CommentDto> UpdateAsync(Guid id, CommentUpdateDto input)
        {
            return _commentsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _commentsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CommentExcelDownloadDto input)
        {
            return _commentsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _commentsAppService.GetDownloadTokenAsync();
        }
    }
}