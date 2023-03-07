namespace FoodieApp.Server.Domain.Entities
{
    public class Meal : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public DateTime Datetime { get; set; }
        public int CookingTime { get; set; } = 1;

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public  ICollection<Review>? Reviews { get; set; } = new List<Review>();
        public  ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
