namespace FoodieApp.Server.Domain.Entities
{
    public class Review : Entity
    {
        public double Stars { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }

        /// <summary>
        /// Owner of the Review
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
