using FoodieApp.Server.Domain.Entities;
using FoodieApp.Server.Domain.Interfaces.Repository;
using FoodieApp.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace FoodieApp.Server.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContextFactory<FoodieAppDbContext> _dbContextFactory;

        public GenericRepository(IDbContextFactory<FoodieAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            await dbContext.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int entityId, CancellationToken cancellationToken = default)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            //Table object is needed since we will use its Remove() method
            var table = dbContext.Set<T>();
            //needed because is the parameter to table.Remove()
            var entityToDelete = await table.FindAsync(entityId, cancellationToken) ?? throw new KeyNotFoundException("The entity was not found");
            
            table.Remove(entityToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int entityId, CancellationToken cancellationToken = default)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var entity = await dbContext!.Set<T>().FindAsync(entityId, cancellationToken) ?? throw new KeyNotFoundException("The entity was not found");
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            return dbContext.Set<T>().ToImmutableList();
        }

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            dbContext.Set<T>().Update(entity);

            await dbContext.SaveChangesAsync();
        }

        #region Private Methods
        #endregion
    }
}
