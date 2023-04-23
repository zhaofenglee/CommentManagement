using System;
using JS.Abp.CommentManagement.Shared;
using Volo.Abp.AutoMapper;
using JS.Abp.CommentManagement.Comments;
using AutoMapper;
using Volo.Abp.Users;

namespace JS.Abp.CommentManagement;

public class CommentManagementApplicationAutoMapperProfile : Profile
{
    public CommentManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Comment, CommentDto>();
        CreateMap<Comment, CommentExcelDto>();
        CreateMap<Comment, CommentWithUserDto>()
            .ForMember(dest => dest.Author, opt => opt.Ignore());
        CreateMap<IUserData, CommentUserDto>();
    }
}