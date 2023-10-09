namespace FoodieApp.Shared.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Datetime { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public int MealId { get; set; }
        public MealViewModel Meal { get; set; }
    }
}
