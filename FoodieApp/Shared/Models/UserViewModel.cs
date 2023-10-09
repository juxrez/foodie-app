using System.ComponentModel.DataAnnotations;

namespace FoodieApp.Shared.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(25, ErrorMessage = "Max 25 characters. Pls.")]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress(ErrorMessage = "Use a correct email. Pls.")]
        public string Email { get; set; } = string.Empty;

        public string? Image { get; set; }

        public string? Icon { get; set; }
    }
}
