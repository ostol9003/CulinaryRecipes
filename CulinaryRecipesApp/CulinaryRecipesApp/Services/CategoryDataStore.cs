using System.Linq;
using System.Threading.Tasks;
using CulinaryRecipesApp.Helpers;
using RecipeAppService;

namespace CulinaryRecipesApp.Services
{
    public class CategoryDataStore : ListDataStore<CategoryDto>
    {
        public CategoryDataStore()
            : base()
            => items = recipeService.CategoryAllAsync().GetAwaiter().GetResult().ToList();
        public override CategoryDto Find(CategoryDto item)
            => items.Where((CategoryDto arg) => arg.Id == item.Id).FirstOrDefault();
        public override CategoryDto Find(int id)
            => items.FirstOrDefault(s => s.Id == id);
        public override async Task Refresh()
            => items = (await recipeService.CategoryAllAsync()).ToList();
        public override async Task<bool> DeleteItemFromService(CategoryDto item)
            => await recipeService.CategoryDELETEAsync(item.Id).HandleRequest();
        public override async Task<bool> UpdateItemInService(CategoryDto item)
            => await recipeService.CategoryPUTAsync(item.Id, item).HandleRequest();
        public override async Task<bool> AddItemToService(CategoryDto item)
            => await recipeService.CategoryPOSTAsync(item).HandleRequest();
    }
}
