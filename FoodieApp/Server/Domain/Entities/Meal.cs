namespace FoodieApp.Server.Domain.Entities
{
    public class Meal : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public DateTime Datetime { get; set; }


        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
