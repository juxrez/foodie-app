using FoodieApp.Shared.Models;

namespace FoodieApp.Server.Domain.Interfaces.Services
{
    public interface IMealService : IGenericService<MealViewModel>
    {
        Task<IEnumerable<CarouselMeals>> GetCarouselMeals(bool fromCurrentWeek = false);
        Task<MealViewModel> AddReviewToMeal(int mealId, ReviewViewModel review);
    }
}
