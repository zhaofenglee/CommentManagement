using Volo.Abp.Application.Dtos;
using System;

namespace JS.Abp.CommentManagement.Comments
{
    public class CommentExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public string? EntityType { get; set; }
        public string? EntityId { get; set; }
        public string? Text { get; set; }
        public Guid? RepliedCommentId { get; set; }

        public CommentExcelDownloadDto()
        {

        }
    }
}