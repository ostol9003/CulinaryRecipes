using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CulinaryRecipesApp.ViewModels.Abstract;
using CulinaryRecipesApp.Views.RecipeV;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.RecipeVM
{
    public class RecipeViewModel : AItemsViewModel<RecipeDto>
    {
        public RecipeViewModel() :
            base("Recipe")
        {
            
        }

        public override async Task GoToAddPage() => await Shell.Current.GoToAsync(nameof(RecipeNewPage));

        public override async Task GoToDetailsPage(RecipeDto recipe)
        => await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?{nameof(RecipeDetailViewModel.ItemId)}={recipe.Id}");
    }
}
