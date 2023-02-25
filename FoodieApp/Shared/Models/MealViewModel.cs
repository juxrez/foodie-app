namespace FoodieApp.Shared.Models
{
    public class MealViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CookDate { get; set; }
        public double AverageStars { get; set; }

        public UserViewModel Cooker { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }
}
