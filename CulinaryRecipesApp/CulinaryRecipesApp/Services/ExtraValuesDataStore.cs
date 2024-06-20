using System;
using System.Threading.Tasks;

namespace CulinaryRecipesApp.Services
{
    public class ExtraValuesDataStore :  ADataStore
    {
        public ExtraValuesDataStore()
        : base()
        {
        }
        public async Task<int> RecipesInCategory(int categoryId) 
            => await recipeService.RecipesInCategoryAsync(categoryId);
        public async Task<int> RecipesWithIngredient(int ingredientId) 
            => await recipeService.RecipesWithIngredientAsync(ingredientId);
        public async Task<double> AveragePrepTime() 
            => await recipeService.AveragePrepTimeAsync();
        public async Task<double> AveragePrepTimeInCategory(int categoryId)
            => await recipeService.AveragePrepTimeInCategoryAsync(categoryId);
    }
}