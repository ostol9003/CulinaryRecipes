using System.Linq;
using System.Threading.Tasks;
using CulinaryRecipesApp.Helpers;
using RecipeAppService;

namespace CulinaryRecipesApp.Services
{
    public class RecipeDataStore : ListDataStore<RecipeDto>
    {
        public RecipeDataStore()
            : base()
            => items = recipeService.RecipeAllAsync().GetAwaiter().GetResult().ToList();
        public override RecipeDto Find(RecipeDto item)
            => items.Where((RecipeDto arg) => arg.Id == item.Id).FirstOrDefault();
        public override RecipeDto Find(int id)
            => items.FirstOrDefault(s => s.Id == id);
        public override async Task Refresh()
            => items = (await recipeService.RecipeAllAsync()).ToList();
        public override async Task<bool> DeleteItemFromService(RecipeDto item)
            => await recipeService.RecipeDELETEAsync(item.Id).HandleRequest();
        public override async Task<bool> UpdateItemInService(RecipeDto item)
            => await recipeService.RecipePUTAsync(item.Id, item).HandleRequest();
        public override async Task<bool> AddItemToService(RecipeDto item)
            => await recipeService.RecipePOSTAsync(item).HandleRequest();
    }
}
