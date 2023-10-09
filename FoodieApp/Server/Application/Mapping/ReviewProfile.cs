using AutoMapper;
using FoodieApp.Server.Domain.Entities;
using FoodieApp.Shared.Models;

namespace FoodieApp.Server.Application.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewViewModel>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
        }
    }
}
