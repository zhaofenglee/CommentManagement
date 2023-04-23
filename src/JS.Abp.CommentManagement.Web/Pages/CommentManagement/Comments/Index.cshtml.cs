using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using JS.Abp.CommentManagement.Comments;
using JS.Abp.CommentManagement.Shared;

namespace JS.Abp.CommentManagement.Web.Pages.CommentManagement.Comments
{
    public class IndexModel : AbpPageModel
    {
        public string? EntityTypeFilter { get; set; }
        public string? EntityIdFilter { get; set; }
        public string? TextFilter { get; set; }
        public string? RepliedCommentIdFilter { get; set; }

        private readonly ICommentsAppService _commentsAppService;

        public IndexModel(ICommentsAppService commentsAppService)
        {
            _commentsAppService = commentsAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}