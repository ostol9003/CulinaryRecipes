using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("Recipe_Ingredient")]
    public class RecipeIngredient
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("recipe_id")]
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        [Column("ingredient_id")]
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }

        [Column("quantity")]
        [Required]
        public double Quantity { get; set; }

        [Column("unit")]
        [Required]
        [StringLength(50)] 
        public string Unit { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
