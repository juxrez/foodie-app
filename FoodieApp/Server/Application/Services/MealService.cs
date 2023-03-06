using AutoMapper;
using FoodieApp.Server.Domain.Entities;
using FoodieApp.Server.Domain.Interfaces.Repository;
using FoodieApp.Server.Domain.Interfaces.Services;
using FoodieApp.Shared.Models;

namespace FoodieApp.Server.Application.Services
{
    public class MealService : IMealService
    {
        private readonly IMapper _mapper;
        private readonly IMealRepository _mealRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Group> _groupRepository;


        public MealService(IMapper mapper,
            IMealRepository mealRepository,
            IRepository<User> userRepository,
            IRepository<Group> groupRepository)
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }

        public async Task Add(MealViewModel mealViewModel)
        {
            var entity = _mapper.Map<Meal>(mealViewModel);
            //insert user repo
            //assign chef 
            User chef = await _userRepository.Get(mealViewModel.CookerId);
            Group group = await _groupRepository.Get(mealViewModel.groupId);

            entity.Group = group;
            entity.User = chef;

            await _mealRepository.Add(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MealViewModel>> GetAllAsync()
        {
            var meals = await  _mealRepository.GetAndIncludeAll();
            return _mapper.Map<List<MealViewModel>>(meals);
        }

        public async Task<MealViewModel> GetAsync(int id)
        {
            var meal = await _mealRepository.Get(id);
            if (meal is not null)
            {
                var response = _mapper.Map<MealViewModel>(meal);
                return response;
            }

            throw new KeyNotFoundException("Meal not found");
        }

        public Task<MealViewModel> UpdateAsync(MealViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
