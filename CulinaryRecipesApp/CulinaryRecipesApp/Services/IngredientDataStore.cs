using System.Linq;
using System.Threading.Tasks;
using CulinaryRecipesApp.Helpers;
using RecipeAppService;

namespace CulinaryRecipesApp.Services;

public class IngredientDataStore : ListDataStore<IngredientDto>
{
    public IngredientDataStore()
    {
        items = recipeService.IngredientAllAsync().GetAwaiter().GetResult().ToList();
    }

    public override IngredientDto Find(IngredientDto item)
    {
        return items.Where(arg => arg.Id == item.Id).FirstOrDefault();
    }

    public override IngredientDto Find(int id)
    {
        return items.FirstOrDefault(s => s.Id == id);
    }

    public override async Task Refresh()
    {
        items = (await recipeService.IngredientAllAsync()).ToList();
    }

    public override async Task<bool> DeleteItemFromService(IngredientDto item)
    {
        return await recipeService.IngredientDELETEAsync(item.Id).HandleRequest();
    }

    public override async Task<bool> UpdateItemInService(IngredientDto item)
    {
        return await recipeService.IngredientPUTAsync(item.Id, item).HandleRequest();
    }

    public override async Task<bool> AddItemToService(IngredientDto item)
    {
        return await recipeService.IngredientPOSTAsync(item).HandleRequest();
    }
}