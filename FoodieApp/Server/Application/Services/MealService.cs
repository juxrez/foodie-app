using FoodieApp.Server.Domain.Entities;
using FoodieApp.Server.Domain.Interfaces.Services;

namespace FoodieApp.Server.Application.Services
{
    public class MealService : IMealService
    {
        public Task AddMeal(Meal meal)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMeal(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Meal> GetMeal(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Meal>> GetMeals()
        {
            throw new NotImplementedException();
        }

        public Task<Meal> UpdateMeal(Meal meal)
        {
            throw new NotImplementedException();
        }
    }
}
