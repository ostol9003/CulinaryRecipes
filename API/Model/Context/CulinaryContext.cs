using Microsoft.EntityFrameworkCore;

namespace API.Model.Context
{
    public class CulinaryContext : DbContext
    {
        public CulinaryContext()
        {
        }

        public CulinaryContext(DbContextOptions<CulinaryContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<RecipeCategory> RecipeCategory { get; set; } = null!;
        public virtual DbSet<RecipeIngredient> RecipeIngredient { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity => entity.Property(e => e.Id).ValueGeneratedOnAdd());
            modelBuilder.Entity<Ingredient>(entity => entity.Property(e => e.Id).ValueGeneratedOnAdd());
            modelBuilder.Entity<Recipe>(entity => entity.Property(e => e.Id).ValueGeneratedOnAdd());
            modelBuilder.Entity<RecipeCategory>(entity => entity.Property(e => e.Id).ValueGeneratedOnAdd());
            modelBuilder.Entity<RecipeIngredient>(entity => entity.Property(e => e.Id).ValueGeneratedOnAdd());
            modelBuilder.Entity<User>(entity => entity.Property(e => e.Id).ValueGeneratedOnAdd());


        }
    }
}
