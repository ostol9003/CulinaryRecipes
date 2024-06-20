using System.Linq;
using System.Threading.Tasks;
using CulinaryRecipesApp.Helpers;
using RecipeAppService;

namespace CulinaryRecipesApp.Services;

public class RecipeDataStore : ListDataStore<RecipeDto>
{
    public RecipeDataStore()
    {
        items = recipeService.RecipeAllAsync().GetAwaiter().GetResult().ToList();
    }

    public override RecipeDto Find(RecipeDto item)
    {
        return items.Where(arg => arg.Id == item.Id).FirstOrDefault();
    }

    public override RecipeDto Find(int id)
    {
        return items.FirstOrDefault(s => s.Id == id);
    }

    public override async Task Refresh()
    {
        items = (await recipeService.RecipeAllAsync()).ToList();
    }

    public override async Task<bool> DeleteItemFromService(RecipeDto item)
    {
        return await recipeService.RecipeDELETEAsync(item.Id).HandleRequest();
    }

    public override async Task<bool> UpdateItemInService(RecipeDto item)
    {
        return await recipeService.RecipePUTAsync(item.Id, item).HandleRequest();
    }

    public override async Task<bool> AddItemToService(RecipeDto item)
    {
        return await recipeService.RecipePOSTAsync(item).HandleRequest();
    }
}