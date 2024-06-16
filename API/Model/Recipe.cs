using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("Recipes")]
    public class Recipe
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        [StringLength(200)] 
        public string Title { get; set; }

        [Column("description")]
        [StringLength(1000)] 
        public string Description { get; set; }

        [Column("instructions")]
        [StringLength(1000)]
        public string Instructions { get; set; }

        [Column("prep_time")]
        [Range(0, int.MaxValue)]
        public int PrepTime { get; set; } // In minutes

        [Column("cook_time")]
        [Range(0, int.MaxValue)]
        public int CookTime { get; set; } // In minutes

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public ICollection<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();
        public List<Category> Categories { get; set; } = new();
     
    }
}
