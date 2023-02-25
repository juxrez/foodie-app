namespace FoodieApp.Server.Domain.Entities
{
    public class Meal : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Datetime { get; set; }

        public User Chef { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
