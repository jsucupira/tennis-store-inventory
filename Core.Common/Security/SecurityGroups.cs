using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Security
{
    [ExcludeFromCodeCoverage]
    public static class SecurityGroups
    {
        public const string ADMINISTRATOR = "Administrators";
        public const string SYS_ADMIN = "System Admin";
        public const string MASTER_DATA_ADMIN = "Master Data Admin";
        public const string MASTER_DATA_EDITOR = "Master Data Editor";
        public const string MASTER_DATA_VIEW = "Master Data Read-Only";
    }
}