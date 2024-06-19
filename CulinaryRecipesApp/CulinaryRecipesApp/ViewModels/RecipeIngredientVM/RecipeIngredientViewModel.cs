using System.Threading.Tasks;
using CulinaryRecipesApp.ViewModels.Abstract;
using CulinaryRecipesApp.Views.RecipeIngredientV;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.RecipeIngredientVM
{
    public class RecipeIngredientViewModel : AItemsViewModel<RecipeIngredientDto>
    {
        public RecipeIngredientViewModel() :
            base("RecipeIngredient")
        {
        }

        public override async Task GoToAddPage() => await Shell.Current.GoToAsync(nameof(NewRecipeIngredientPage));

        public override async Task GoToDetailsPage(RecipeIngredientDto RecipeIngredient)
        => await Shell.Current.GoToAsync($"{nameof(RecipeIngredientDetailPage)}?{nameof(RecipeIngredientDetailsViewModel.ItemId)}={RecipeIngredient.Id}");
    }
}
