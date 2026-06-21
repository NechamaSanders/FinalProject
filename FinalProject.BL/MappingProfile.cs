using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.DAL.Entities;

namespace FinalProject.BL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecipeCreateDto, Recipe>()
                .ForMember(dest => dest.RecipeIngredients, opt => opt.Ignore()); 

            CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Name : "Unknown"))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src =>
                    src.RecipeIngredients != null
                        ? src.RecipeIngredients.Select(ri => ri.Ingredient != null ? $"{ri.Ingredient.Name} ({ri.Amount})" : "Unknown").ToList()
                        : new List<string>()));
            
            CreateMap<User, UserDto>();

            CreateMap<UserCreateDto, User>();

            CreateMap<Ingredient, IngredientDto>();

            CreateMap<IngredientCreateDto, Ingredient>();
        }
    }
}