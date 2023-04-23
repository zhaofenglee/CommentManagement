namespace JS.Abp.CommentManagement.Comments
{
    public static class CommentConsts
    {
        private const string DefaultSorting = "{0}EntityType asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Comment." : string.Empty);
        }

        public const int EntityTypeMaxLength = 64;
        public const int EntityIdMaxLength = 64;
    }
}