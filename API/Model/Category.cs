using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [StringLength(100)] 
        public string Name { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("url")]
        [StringLength(200)] 
        public string Url { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public Category()
        {
            Recipes = new HashSet<Recipe>();
        }

    }
}
