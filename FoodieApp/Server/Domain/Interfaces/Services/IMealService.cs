using FoodieApp.Server.Domain.Entities;

namespace FoodieApp.Server.Domain.Interfaces.Services
{
    public interface IMealService
    {
        Task<Meal> GetMeal(int id);
        Task<List<Meal>> GetMeals();
        Task DeleteMeal(int id);
        Task AddMeal(Meal meal);
        Task<Meal> UpdateMeal(Meal meal);
    }
}
