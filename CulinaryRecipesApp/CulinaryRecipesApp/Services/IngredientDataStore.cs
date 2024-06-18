using System.Linq;
using System.Threading.Tasks;
using CulinaryRecipesApp.Helpers;
using RecipeAppService;

namespace CulinaryRecipesApp.Services
{
    public class IngredientDataStore : ListDataStore<IngredientDto>
    {
        public IngredientDataStore()
            : base()
            => items = recipeService.IngredientAllAsync().GetAwaiter().GetResult().ToList();
        public override IngredientDto Find(IngredientDto item)
            => items.Where((IngredientDto arg) => arg.Id == item.Id).FirstOrDefault();
        public override IngredientDto Find(int id)
            => items.FirstOrDefault(s => s.Id == id);
        public override async Task Refresh()
            => items = (await recipeService.IngredientAllAsync()).ToList();
        public override async Task<bool> DeleteItemFromService(IngredientDto item)
            => await recipeService.IngredientDELETEAsync(item.Id).HandleRequest();
        public override async Task<bool> UpdateItemInService(IngredientDto item)
            => await recipeService.IngredientPUTAsync(item.Id, item).HandleRequest();
        public override async Task<bool> AddItemToService(IngredientDto item)
            => await recipeService.IngredientPOSTAsync(item).HandleRequest();
    }
}
