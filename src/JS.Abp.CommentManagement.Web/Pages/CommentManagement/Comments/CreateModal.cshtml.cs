using JS.Abp.CommentManagement.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JS.Abp.CommentManagement.Comments;

namespace JS.Abp.CommentManagement.Web.Pages.CommentManagement.Comments
{
    public class CreateModalModel : CommentManagementPageModel
    {
        [BindProperty]
        public CommentCreateViewModel Comment { get; set; }

        private readonly ICommentsAppService _commentsAppService;

        public CreateModalModel(ICommentsAppService commentsAppService)
        {
            _commentsAppService = commentsAppService;

            Comment = new();
        }

        public async Task OnGetAsync()
        {
            Comment = new CommentCreateViewModel();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await _commentsAppService.CreateAsync(ObjectMapper.Map<CommentCreateViewModel, CommentCreateDto>(Comment));
            return NoContent();
        }
    }

    public class CommentCreateViewModel : CommentCreateDto
    {
    }
}