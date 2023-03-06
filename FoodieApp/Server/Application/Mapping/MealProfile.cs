using AutoMapper;
using FoodieApp.Server.Domain.Entities;
using FoodieApp.Shared.Models;

namespace FoodieApp.Server.Application.Mapping
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<MealViewModel, Meal>();

            CreateMap<Meal, MealViewModel>()
                .ForMember(dest => dest.CookDate, opt => opt.MapFrom(src => src.Datetime))
                .ForMember(dest => dest.Cooker, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.CookerId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.groupId, opt => opt.MapFrom(src => src.GroupId));


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
