using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [StringLength(100)] 
        public string Name { get; set; }

        [Column("email")]
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        [Column("password_hash")]
        [Required]
        [StringLength(200)] 
        public string PasswordHash { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
