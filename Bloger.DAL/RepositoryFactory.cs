using Bloger.DAL.Persistence;

namespace Bloger.DAL
{
    public static class RepositoryFactory
    {
        public static BaseRepository<TEntity> CreateRepository<TEntity>(BlogerDbContext dbContext)
            where TEntity : class, new() =>
            new BaseRepository<TEntity>(dbContext);
    }
}
