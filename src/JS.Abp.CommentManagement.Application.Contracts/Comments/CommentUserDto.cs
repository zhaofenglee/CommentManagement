using System;

namespace JS.Abp.CommentManagement.Comments;

public class CommentUserDto
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }
}