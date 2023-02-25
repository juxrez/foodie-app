namespace FoodieApp.Server.Domain.Interfaces.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task Add(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
    }
}
