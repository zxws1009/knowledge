using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using Ellis.AbpCore.Authorization.Roles;
using Ellis.AbpCore.Configuration;
using Ellis.AbpCore.MultiTenancy;
using Ellis.AbpCore.Users;
using Ellis.AbpCore.Web;

namespace Ellis.AbpCore.EntityFramework
{
    [DbConfigurationType(typeof(AbpCoreDbConfiguration))]
    public class AbpCoreDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        /* Default constructor is needed for EF command line tool. */
        public AbpCoreDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                AbpCoreConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of AbpCoreDbContext since ABP automatically handles it.
         */
        public AbpCoreDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public AbpCoreDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        public AbpCoreDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }
    }

    public class AbpCoreDbConfiguration : DbConfiguration
    {
        public AbpCoreDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
