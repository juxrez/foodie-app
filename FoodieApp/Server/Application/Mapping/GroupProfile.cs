using AutoMapper;
using FoodieApp.Server.Domain.Entities;
using FoodieApp.Shared.Models;

namespace FoodieApp.Server.Application.Mapping
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupViewModel>().ReverseMap();
        }
    }
}
