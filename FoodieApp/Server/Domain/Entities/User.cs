namespace FoodieApp.Server.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
