using FoodieApp.Server.Domain.Entities;
using FoodieApp.Server.Domain.Interfaces.Repository;
using FoodieApp.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Immutable;

namespace FoodieApp.Server.Infrastructure.Repositories
{
    public class MealRepository :  GenericRepository<Meal>, IMealRepository
    {
        private readonly IDbContextFactory<FoodieAppDbContext> _dbContextFactory;

        public MealRepository(IDbContextFactory<FoodieAppDbContext> dbContextFactory) : base(dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Meal?> GetMeal(int id, CancellationToken cancellationToken = default)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            return dbContext.Meal.AsNoTracking().FirstOrDefault(m => m.Id == id);
        }

        public async Task<IEnumerable<Meal>> GetAndIncludeAll(CancellationToken cancellationToken = default)
        {
            await using var dbcontext = await _dbContextFactory.CreateDbContextAsync();
            return dbcontext.Meal
                .AsNoTracking()
                .Include(m => m.User)
                .Include(m => m.Group)
                .Include(m => m.Reviews)!
                    .ThenInclude(r => r.User)
                .ToImmutableList();
        }
    }
}
