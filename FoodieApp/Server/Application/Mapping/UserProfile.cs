using AutoMapper;
using FoodieApp.Server.Domain.Entities;
using FoodieApp.Shared.Models;

namespace FoodieApp.Server.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();

        //    CreateMap<User, UserViewModel>()
        //.ForMember(dest =>
        //    dest.FName,
        //    opt => opt.MapFrom(src => src.FirstName))
        //.ForMember(dest =>
        //    dest.LName,
        //    opt => opt.MapFrom(src => src.LastName))
        }
    }
}
