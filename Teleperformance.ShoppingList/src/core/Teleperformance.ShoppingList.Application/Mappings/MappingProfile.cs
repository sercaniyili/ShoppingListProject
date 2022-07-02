using AutoMapper;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Features.Commands.User.UserCreate;
using Teleperformance.Bootcamp.Application.Features.Commands.User.UserLogin;
using Teleperformance.Bootcamp.Domain.Entities;
using Teleperformance.Bootcamp.Domain.Entities.Identity;

namespace Teleperformance.Bootcamp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region User
            CreateMap<AppUser, UserCreateCommandRequest>().ReverseMap();
            CreateMap<AppUser, UserLoginCommandRequest>().ReverseMap();
            #endregion

            #region ShoppingList
            CreateMap<ShoppingList, GelAllShoppingListDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AppUser.Email))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<ShoppingList, CreateShoppingListDto>();
            //.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));
            //.ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUser.Id));
            #endregion
        }
    }
}
