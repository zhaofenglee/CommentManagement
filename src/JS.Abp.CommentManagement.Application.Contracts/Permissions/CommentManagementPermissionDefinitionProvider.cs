using JS.Abp.CommentManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JS.Abp.CommentManagement.Permissions;

public class CommentManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CommentManagementPermissions.GroupName, L("Permission:CommentManagement"));

        var commentPermission = myGroup.AddPermission(CommentManagementPermissions.Comments.Default, L("Permission:Comments"));
        commentPermission.AddChild(CommentManagementPermissions.Comments.Create, L("Permission:Create"));
        commentPermission.AddChild(CommentManagementPermissions.Comments.Edit, L("Permission:Edit"));
        commentPermission.AddChild(CommentManagementPermissions.Comments.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CommentManagementResource>(name);
    }
}