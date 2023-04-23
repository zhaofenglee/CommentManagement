using JS.Abp.CommentManagement.Web.Pages.CommentManagement.Comments;
using Volo.Abp.AutoMapper;
using JS.Abp.CommentManagement.Comments;
using AutoMapper;

namespace JS.Abp.CommentManagement.Web;

public class CommentManagementWebAutoMapperProfile : Profile
{
    public CommentManagementWebAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CommentDto, CommentUpdateViewModel>();
        CreateMap<CommentUpdateViewModel, CommentUpdateDto>();
        CreateMap<CommentCreateViewModel, CommentCreateDto>();
    }
}