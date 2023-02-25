using FoodieApp.Server.Domain.Entities;
using FoodieApp.Server.Domain.Interfaces.Repository;
using FoodieApp.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodieApp.Server.Infrastructure.Repositories
{
    public class MealRepository //: IMealRepository
    {
        private readonly IDbContextFactory<FoodieAppDbContext> _dbContextFactory;

        public MealRepository(IDbContextFactory<FoodieAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        ///FirstOrDefaultAsync(
        //u => u.NormalizedUserName == normalizedUserName,
        //GetCancellationToken(cancellationToken)

        public async Task Add(Meal meal, CancellationToken cancellationToken = default)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            await dbContext.AddAsync(meal, cancellationToken).ConfigureAwait(false);
        }

        public Task Delete(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Meal> Get(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Meal>> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
