using JS.Abp.CommentManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JS.Abp.CommentManagement;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(CommentManagementEntityFrameworkCoreTestModule)
    )]
public class CommentManagementDomainTestModule : AbpModule
{

}
