using System.Threading.Tasks;

namespace CulinaryRecipesApp.Services;

public class ExtraValuesDataStore : ADataStore
{
    public async Task<int> RecipesInCategory(int categoryId)
    {
        return await recipeService.RecipesInCategoryAsync(categoryId);
    }

    public async Task<int> RecipesWithIngredient(int ingredientId)
    {
        return await recipeService.RecipesWithIngredientAsync(ingredientId);
    }

    public async Task<double> AveragePrepTime()
    {
        return await recipeService.AveragePrepTimeAsync();
    }

    public async Task<double> AveragePrepTimeInCategory(int categoryId)
    {
        return await recipeService.AveragePrepTimeInCategoryAsync(categoryId);
    }
}