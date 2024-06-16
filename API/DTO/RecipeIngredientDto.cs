using System;
using API.Helpers;
using API.Model;

namespace API.DTO
{
    public class RecipeIngredientDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public bool IsActive { get; set; }

        public static implicit operator RecipeIngredient(RecipeIngredientDto dto)
            => new RecipeIngredient().CopyProperties(dto);
        public static implicit operator RecipeIngredientDto(RecipeIngredient ri)
            => new RecipeIngredientDto().CopyProperties(ri);
    }
}