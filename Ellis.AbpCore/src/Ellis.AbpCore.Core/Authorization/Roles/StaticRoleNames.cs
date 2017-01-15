namespace Ellis.AbpCore.Authorization.Roles
{
    public static class StaticRoleNames
    {
        public static class Host
        {
            public const string Admin = "HostAdmin";
            public const string DisplayName = "HostAdministrator";
        }

        public static class Tenants
        {
            public const string Admin = "TenantAdmin";
            public const string DisplayName = "TenantAdministrator";
        }
    }
}