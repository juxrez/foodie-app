using AutoMapper;
using FoodieApp.Server.Domain.Entities;
using FoodieApp.Server.Domain.Interfaces.Repository;
using FoodieApp.Server.Domain.Interfaces.Services;
using FoodieApp.Server.Infrastructure.Repositories;
using FoodieApp.Shared.Models;

namespace FoodieApp.Server.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task Add(UserViewModel userVm)
        {
            if(userVm is null) { throw new ArgumentNullException(nameof(userVm)); }

            var user = _mapper.Map<User>(userVm);

            await _userRepository.Add(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if(id is 0) { throw new ArgumentNullException(nameof(id));}

            await _userRepository.Delete(id);

            return true;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var result = await _userRepository.GetAll();
            var mappedResult = _mapper.Map<List<UserViewModel>>(result.Where(u => !u.IsDeleted));

            return mappedResult;
        }

        public async Task<UserViewModel> GetAsync(int id)
        {
            var result = await _userRepository.Get(id);
            var mappedResult = _mapper.Map<UserViewModel>(result);
            return mappedResult;
        }

        public async Task<UserViewModel> UpdateAsync(UserViewModel userVm)
        {
            if (userVm is null) { throw new ArgumentNullException(); }
            var existingUserToUpdate = await _userRepository.Get(userVm.Id);

            _mapper.Map(userVm, existingUserToUpdate);

            await _userRepository.Update(existingUserToUpdate);
            var upToDateUser = await _userRepository.Get(userVm.Id);

            return _mapper.Map<UserViewModel>(upToDateUser);
        }
    }
}
