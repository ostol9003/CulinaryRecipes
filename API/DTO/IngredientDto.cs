using API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Helpers;

namespace API.DTO
{
    public class IngredientDto
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public static implicit operator Ingredient(IngredientDto dto)
            => new Ingredient().CopyProperties(dto);
        public static implicit operator IngredientDto(Ingredient ing)
            => new IngredientDto().CopyProperties(ing);
    }
}