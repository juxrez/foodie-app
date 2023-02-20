using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieApp.Shared.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CookDate { get; set; }
        public double AverageStars { get; set; }

        public User Cooker { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
