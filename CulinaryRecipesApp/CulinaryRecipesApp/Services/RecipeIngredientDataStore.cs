using System.Linq;
using System.Threading.Tasks;
using CulinaryRecipesApp.Helpers;
using RecipeAppService;

namespace CulinaryRecipesApp.Services
{
    public class RecipeIngredientDataStore : ListDataStore<RecipeIngredientDto>
    {
        public RecipeIngredientDataStore()
            : base()
            => items = recipeService.RecipeIngredientAllAsync().GetAwaiter().GetResult().ToList();
        public override RecipeIngredientDto Find(RecipeIngredientDto item)
            => items.Where((RecipeIngredientDto arg) => arg.Id == item.Id).FirstOrDefault();
        public override RecipeIngredientDto Find(int id)
            => items.FirstOrDefault(s => s.Id == id);
        public override async Task Refresh()
            => items = (await recipeService.RecipeIngredientAllAsync()).ToList();
        public override async Task<bool> DeleteItemFromService(RecipeIngredientDto item)
            => await recipeService.RecipeIngredientDELETEAsync(item.Id).HandleRequest();
        public override async Task<bool> UpdateItemInService(RecipeIngredientDto item)
            => await recipeService.RecipeIngredientPUTAsync(item.Id, item).HandleRequest();
        public override async Task<bool> AddItemToService(RecipeIngredientDto item)
            => await recipeService.RecipeIngredientPOSTAsync(item).HandleRequest();
    }
}
