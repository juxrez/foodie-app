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
                .ForMember(dest => dest.AverageStars, opt => opt.MapFrom(src => (src.Reviews.Count > 0 ? src.Reviews.Sum(r => r.Stars) : 1)))

                .ForMember(dest => dest.groupId, opt => opt.MapFrom(src => src.GroupId));


            //    CreateMap<User, UserViewModel>()
            //.ForMember(dest =>
            //    dest.FName,
            //    opt => opt.MapFrom(src => src.FirstName))
            //.ForMember(dest =>
            //    dest.LName,
            //    opt => opt.MapFrom(src => src.LastName))

            CreateMap<Meal, CarouselMeals>()
                .ForMember(dest => dest.MealName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
        }
    }

}
