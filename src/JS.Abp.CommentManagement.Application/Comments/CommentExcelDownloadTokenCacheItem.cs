using System;

namespace JS.Abp.CommentManagement.Comments;

[Serializable]
public class CommentExcelDownloadTokenCacheItem
{
    public string Token { get; set; }
}