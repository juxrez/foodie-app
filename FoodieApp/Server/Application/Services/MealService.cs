using AutoMapper;
using FoodieApp.Server.Domain.Entities;
using FoodieApp.Server.Domain.Interfaces.Repository;
using FoodieApp.Server.Domain.Interfaces.Services;
using FoodieApp.Shared.Models;
using Microsoft.IdentityModel.Tokens;

namespace FoodieApp.Server.Application.Services
{
    public class MealService : IMealService
    {
        private readonly IMapper _mapper;
        private readonly IMealRepository _mealRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<Review> _reviewRepository;


        public MealService(IMapper mapper,
            IMealRepository mealRepository,
            IRepository<User> userRepository,
            IRepository<Group> groupRepository,
            IRepository<Review> reviewRepository)
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task Add(MealViewModel mealViewModel)
        {
            User chef = await _userRepository.Get(mealViewModel.CookerId);
            Group group = await _groupRepository.Get(mealViewModel.groupId);
            
            var entity = _mapper.Map<Meal>(mealViewModel);
            entity.Group = group;
            entity.User = chef;
            
            var savedMeal = await _mealRepository.Add(entity);

            if (!mealViewModel.Reviews.IsNullOrEmpty())
            {
                var reviewVM = mealViewModel.Reviews!.FirstOrDefault();
                var reviewEntity = _mapper.Map<Review>(reviewVM);
                reviewEntity.Meal = savedMeal;
                reviewEntity.User = chef;

                await _reviewRepository.Add(reviewEntity);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MealViewModel>> GetAllAsync()
        {
            var meals = await  _mealRepository.GetAndIncludeAll();
            return _mapper.Map<List<MealViewModel>>(meals.Where(m => !m.IsDeleted));
        }

        public async Task<MealViewModel> GetAsync(int id)
        {
            var meal = await _mealRepository.GetAndIncludeMeal(id);
            if (meal is not null)
            {
                var response = _mapper.Map<MealViewModel>(meal);
                return response;
            }

            throw new KeyNotFoundException("Meal not found");
        }

        public async Task<IEnumerable<CarouselMeals>> GetCarouselMeals(bool fromCurrentWeek = false)
        {
            var meals = await _mealRepository.GetAll();
            var result = _mapper.Map<List<CarouselMeals>>(meals.Where(m => !m.IsDeleted));

            return result;
        }

        public async Task<MealViewModel> AddReviewToMeal(int mealId, ReviewViewModel review)
        {
            if(mealId == 0 || review is null)
            {
                throw new InvalidOperationException("Invalid Request");
            }

            var reviewEntity = _mapper.Map<Review>(review);
            reviewEntity.CreatedDate = DateTime.Now;
            reviewEntity.MealId = mealId;
            reviewEntity.UserId = review.User.Id;
            _reviewRepository.Add(reviewEntity);

            var updatedMeal = await GetAsync(mealId);
            return updatedMeal;
        }

        public Task<MealViewModel> UpdateAsync(MealViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
