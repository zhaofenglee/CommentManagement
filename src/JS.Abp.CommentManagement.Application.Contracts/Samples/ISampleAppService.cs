using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace JS.Abp.CommentManagement.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
