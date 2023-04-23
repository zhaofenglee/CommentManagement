using JS.Abp.CommentManagement.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using JS.Abp.CommentManagement.Comments;

namespace JS.Abp.CommentManagement.Web.Pages.CommentManagement.Comments
{
    public class EditModalModel : CommentManagementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CommentUpdateViewModel Comment { get; set; }

        private readonly ICommentsAppService _commentsAppService;

        public EditModalModel(ICommentsAppService commentsAppService)
        {
            _commentsAppService = commentsAppService;

            Comment = new();
        }

        public async Task OnGetAsync()
        {
            var comment = await _commentsAppService.GetAsync(Id);
            Comment = ObjectMapper.Map<CommentDto, CommentUpdateViewModel>(comment);

        }

        public async Task<NoContentResult> OnPostAsync()
        {

            await _commentsAppService.UpdateAsync(Id, ObjectMapper.Map<CommentUpdateViewModel, CommentUpdateDto>(Comment));
            return NoContent();
        }
    }

    public class CommentUpdateViewModel : CommentUpdateDto
    {
    }
}