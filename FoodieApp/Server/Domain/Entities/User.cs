namespace FoodieApp.Server.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string? Image { get; set; }

        public  ICollection<Review>? Reviews { get; set; }
        public  ICollection<Comment>? Comments { get; set; }
        public  ICollection<Meal>? Meals { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }
    }
}
