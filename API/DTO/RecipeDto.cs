using API.Model;
using API.Helpers;

namespace API.DTO

{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string Instructions { get; set; }
        public int PrepTime { get; set; } 
        public int CookTime { get; set; } 
        public List<IngredientDto> Ingredients { get; set; } = new();
        public List<RecipeIngredientDto> RecipeIngredient { get; set; } = new();
        public List<CategoryDto> Categories { get; set; } = new();
        public string Url { get; set; }

        public static implicit operator Recipe(RecipeDto dto)
            => new Recipe().CopyProperties(dto);
        public static implicit operator RecipeDto(Recipe ctg)
                    => new RecipeDto().CopyProperties(ctg);

    }
}
