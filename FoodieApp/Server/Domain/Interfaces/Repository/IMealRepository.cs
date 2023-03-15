using FoodieApp.Server.Domain.Entities;

namespace FoodieApp.Server.Domain.Interfaces.Repository
{
    public interface IMealRepository : IRepository<Meal>
    {
        Task<IEnumerable<Meal>> GetAndIncludeAll(CancellationToken cancellationToken = default);
        Task<Meal?> GetAndIncludeMeal(int id, CancellationToken cancellationToken = default);
    }
}
