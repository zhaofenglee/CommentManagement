using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace JS.Abp.CommentManagement.Pages;

public class IndexModel : CommentManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
