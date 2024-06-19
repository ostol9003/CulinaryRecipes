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

        public override async Task GoToAddPage() => await Shell.Current.GoToAsync(nameof(RecipePage));

        public override async Task GoToDetailsPage(RecipeDto Recipe)
        => await Shell.Current.GoToAsync($"{nameof(RecipePage)}?{nameof(RecipeViewModel)}={Recipe.Id}");
    }
}
