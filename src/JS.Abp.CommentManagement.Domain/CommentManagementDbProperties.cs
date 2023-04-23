using Volo.Abp.Data;

namespace JS.Abp.CommentManagement;

public static class CommentManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

    public static string? DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

    public const string ConnectionStringName = "CommentManagement";
}
