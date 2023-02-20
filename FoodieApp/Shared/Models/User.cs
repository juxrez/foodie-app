namespace FoodieApp.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
