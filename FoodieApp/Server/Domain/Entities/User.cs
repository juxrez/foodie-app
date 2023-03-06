namespace FoodieApp.Server.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Meal>? Meals { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }
    }
}
