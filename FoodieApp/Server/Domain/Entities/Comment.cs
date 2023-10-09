namespace FoodieApp.Server.Domain.Entities
{
    public class Comment : Entity
    {
        public string Text { get; set; }
        public DateTime Datetime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
