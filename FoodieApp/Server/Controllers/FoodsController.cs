using FoodieApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodieApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        public FoodsController()
        {
                
        }

        // GET all foods
        [HttpGet("async")]
        public async Task<ActionResult<List<MealViewModel>>> GetAsync()
        {
            var foods = await GetFoods();
            return Ok(foods);
        }

        [HttpGet]
        public async Task<List<MealViewModel>> GetAllFoods()
        {
            return await GetFoods();
        }

        // GET food by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<MealViewModel>> Get(int id)
        {
            var foods = await GetFoods();
            var food = foods.FirstOrDefault(f => f.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private Task<List<MealViewModel>> GetFoods()
        {
            var foods = new List<MealViewModel>()
            {
                new()
                {
                    Id = 1,
                    Name = "Arroz Chaufa",
                    CookDate = DateTime.Today.AddDays(-2),
                    Description = "Arrocito con soya, pollo y verduras",
                    Cooker = new UserViewModel() { Id = 1, Name = "Alexis"},
                    Image = "https://www.tqma.com.ec/images/com_yoorecipe/banner_superior/16330_1.jpg",
                    Reviews = new List<ReviewViewModel>()
                    {
                        new ReviewViewModel()
                        {
                            Id = 1,
                            Comments = "Weeeno",
                            CreatedDate = DateTime.Today.AddDays(-1),
                            Stars = 5,
                            User = new UserViewModel() { Id = 1, Name = "Alexis"},
                        },
                        new ReviewViewModel()
                        {
                            Id = 2,
                            Comments = "Estuvo bien",
                            CreatedDate = DateTime.Today.AddDays(-1),
                            Stars = 5,
                            User = new UserViewModel() { Id = 2, Name = "Camila"},
                        }
                    }
                },
                new()
                {
                    Id = 2,
                    Name = "Salchipulpos con papas",
                    CookDate = DateTime.Today.AddDays(-3),
                    Description = "Salchipulpos en air fryer con camarones",
                    Cooker = new UserViewModel() { Id = 1, Name = "Alexis"},
                    Image = "https://www.cardamomo.news/__export/1654123030420/sites/debate/img/2022/06/01/pulpitos_de_salchicha.png_976912859.png",
                    Reviews = new List<ReviewViewModel>()
                    {
                        new ReviewViewModel()
                        {
                            Id = 3,
                            Comments = "Estuvo salao",
                            CreatedDate = DateTime.Today.AddDays(-3),
                            Stars = 2,
                            User = new UserViewModel() { Id = 1, Name = "Alexis"},
                        },
                        new ReviewViewModel()
                        {
                            Id = 4,
                            Comments = "Mas o menos, no estuv tan mal",
                            CreatedDate = DateTime.Today.AddDays(-3),
                            Stars = 3,
                            User = new UserViewModel() { Id = 2, Name = "Camila"},
                        }
                    }
                },
                new()
                {
                    Id = 3,
                    Name = "Pollo con pure",
                    CookDate = DateTime.Today.AddDays(-2),
                    Description = "Pollo en air fryer con pure de papas",
                    Cooker = new UserViewModel() { Id = 2, Name = "Camila"},
                    Image = "https://img-global.cpcdn.com/recipes/c8e905129f12fcbb/680x482cq70/jamoncitos-de-pollo-especiados-en-la-freidora-de-aire-airfryer-foto-principal.jpg",
                    Reviews = new List<ReviewViewModel>()
                    {
                        new ReviewViewModel()
                        {
                            Id = 5,
                            Comments = "Bien, mucha leche en el pure",
                            CreatedDate = DateTime.Today.AddDays(-1),
                            Stars = 4,
                            User = new UserViewModel() { Id = 1, Name = "Alexis"},
                        }
                    }
                }
            };

            //TODO: resolve this when getting entities 
            foreach (var food in foods)
            {
                food.AverageStars = food.Reviews.Select(r => r.Stars).Average();
            }

            return Task.FromResult(foods);
        }
    }
}
