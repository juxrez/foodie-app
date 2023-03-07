using System.ComponentModel.DataAnnotations;

namespace FoodieApp.Shared.Models
{
    public class MealViewModel
    {
        public int Id { get; set; }

        [Required,StringLength(60, ErrorMessage = "Make it shorter")]
        public string Name { get; set; }

        [Required, StringLength(200, ErrorMessage = "Make it shorter")]
        public string Description { get; set; }

        [Required]
        public DateTime CookDate { get; set; } = DateTime.Today;

        public double AverageStars { get; set; }

        public int groupId { get; set; }

        public UserViewModel Cooker { get; set; } = new UserViewModel();
        
        [Required]
        public int CookerId { get; set; }
        public List<ReviewViewModel>? Reviews { get; set; }

        public string Image { get; set; } = string.Empty;
    }

}
