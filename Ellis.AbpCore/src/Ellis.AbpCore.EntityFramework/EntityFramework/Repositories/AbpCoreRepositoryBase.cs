using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Ellis.AbpCore.EntityFramework.Repositories
{
    public abstract class AbpCoreRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AbpCoreDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AbpCoreRepositoryBase(IDbContextProvider<AbpCoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class AbpCoreRepositoryBase<TEntity> : AbpCoreRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AbpCoreRepositoryBase(IDbContextProvider<AbpCoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
