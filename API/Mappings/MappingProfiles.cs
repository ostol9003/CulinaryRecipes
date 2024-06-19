using API.DTO;
using API.Model;
using AutoMapper;

namespace API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.Ingredients,
                    opt => opt.MapFrom(src => src.RecipeIngredients.Select(ri => ri.Ingredient).ToList()))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
                .ForMember(dst => dst.RecipeIngredient, opt => opt.MapFrom(src => src.RecipeIngredients));


            CreateMap<RecipeDto, Recipe>()
                .ForMember(dest => dest.Ingredients, opt => opt.Ignore()) 
                .ForMember(dest => dest.Categories, opt => opt.Ignore()); 


        }
    }

}
