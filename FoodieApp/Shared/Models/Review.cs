using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieApp.Shared.Models
{
    public class Review
    {
        public int Id { get; set; }
        public double Stars { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Comments { get; set; }
        public Food Food { get; set; }
        public User User { get; set; }

    }
}
