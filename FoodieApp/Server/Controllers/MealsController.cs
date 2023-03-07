using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using FoodieApp.Server.Domain.Interfaces.Services;
using FoodieApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodieApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private const string BLOB_KEY = "Blob";
        private const string BLOB_CONTAINER_NAME = "alexiscontainer";
        private readonly IConfiguration _config;
        private readonly IMealService _mealService;

        public MealsController(IConfiguration config, IMealService mealService)
        {
           _config= config;
            _mealService = mealService;
        }

        // GET all foods
        [HttpGet("async")]
        public async Task<ActionResult<List<MealViewModel>>> GetAsync()
        {
            try
            {
                var foods = await _mealService.GetAllAsync();
                return foods;

            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<MealViewModel>>> GetAllFoods()
        {
            try
            {
                var foods = await _mealService.GetAllAsync();
                return await GetFoods();

            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpGet("carousel")]
        public async Task<ActionResult<IEnumerable<CarouselMeals>>> GetCarouselMeals()
        {
            try
            {
                var response = await _mealService.GetCarouselMeals();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET food by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<MealViewModel>> Get(int id)
        {
            var food = await _mealService.GetAsync(id);
            if (food is null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        // POST api/<ValuesController>
        //Test why is not hitting this endpoint

        [HttpPost]
        public async Task<ActionResult> AddMeal(MealViewModel newMeal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ValidationState.ToString());
            }

            try
            {
                await _mealService.Add(newMeal);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("image")]
        public async Task<ActionResult<string>> UploadImage()
        {
            try
            {
                var formFile = Request.Form.Files.FirstOrDefault();
                if (formFile == null || formFile.Length == 0)
                {
                    return BadRequest();
                }

                string url = string.Empty;

                var containerClient = new BlobContainerClient(
                    _config[BLOB_KEY], BLOB_CONTAINER_NAME);

                var blobClient = containerClient.GetBlobClient(formFile.Name);

                var response = await blobClient.UploadAsync(formFile.OpenReadStream(),
                    //HTTP headers to treat the blob
                    new BlobHttpHeaders()
                    {
                        ContentType = formFile.ContentType,
                        CacheControl = "public"
                    },
                    //metadata to associate with the blob
                    new Dictionary<string, string>() { { "customName", formFile.Name } }
                    );

                //GET URL
                //BlobSasBuilder builder = new BlobSasBuilder
                //{
                //    BlobContainerName = containerClient.Name,
                //    BlobName = blobClient.Name,
                //    ExpiresOn = DateTime.UtcNow.AddMinutes(2),
                //    Protocol = SasProtocol.Https
                //};
                //builder.SetPermissions(BlobSasPermissions.Read);

                //UriBuilder uBuilder = new UriBuilder(blobClient.Uri);
                //uBuilder.Query = builder.ToSasQueryParameters(
                //    new Azure.Storage.StorageSharedKeyCredential(
                //        containerClient.AccountName,
                //        _config[BLOB_KEY]
                //    )).ToString();

                url = blobClient.Uri.ToString();

                return Ok(url);
            }
            catch (Exception ex)
            {
                return Ok("");
                throw;
            }
            
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
