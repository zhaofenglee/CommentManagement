using Volo.Abp.AutoMapper;
using JS.Abp.CommentManagement.Comments;
using AutoMapper;

namespace JS.Abp.CommentManagement.Blazor;

public class CommentManagementBlazorAutoMapperProfile : Profile
{
    public CommentManagementBlazorAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CommentDto, CommentUpdateDto>();
    }
}