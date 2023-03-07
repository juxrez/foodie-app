
namespace FoodieApp.Server.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity,CancellationToken cancellationToken = default);
        Task<TEntity> Get(int entityId, string[]? includeProperties = default, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAll(string[]? includeProperties = default, CancellationToken cancellationToken = default);
        Task Delete(int entityId, CancellationToken cancellationToken = default);
        Task Update(TEntity entity, CancellationToken cancellationToken = default); 
    }
}
