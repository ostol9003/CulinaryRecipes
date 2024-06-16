using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("Recipe_Category")]
    public class RecipeCategory
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("recipe_id")]
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        [Column("category_id")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Category Category { get; set; }
    }
}
