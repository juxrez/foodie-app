
namespace FoodieApp.Shared.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public double Stars { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Comments { get; set; }
        public MealViewModel Food { get; set; }
        public UserViewModel User { get; set; }

    }
}
