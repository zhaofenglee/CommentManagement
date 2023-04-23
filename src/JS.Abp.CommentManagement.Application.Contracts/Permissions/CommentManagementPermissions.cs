using Volo.Abp.Reflection;

namespace JS.Abp.CommentManagement.Permissions;

public class CommentManagementPermissions
{
    public const string GroupName = "CommentManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CommentManagementPermissions));
    }

    public static class Comments
    {
        public const string Default = GroupName + ".Comments";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}