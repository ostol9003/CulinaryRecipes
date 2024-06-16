using API.Helpers;
using API.Model;

namespace API.DTO
{
    public class RecipeCategoryDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public static implicit operator RecipeCategory(RecipeCategoryDto dto)
            => new RecipeCategory().CopyProperties(dto);
        public static implicit operator RecipeCategoryDto(RecipeCategory rc)
            => new RecipeCategoryDto().CopyProperties(rc);
    }
}