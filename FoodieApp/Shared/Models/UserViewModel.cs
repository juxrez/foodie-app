namespace FoodieApp.Shared.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }
}
