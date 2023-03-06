namespace FoodieApp.Server.Domain.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }


        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Meal>? Meals { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }

    }
}
