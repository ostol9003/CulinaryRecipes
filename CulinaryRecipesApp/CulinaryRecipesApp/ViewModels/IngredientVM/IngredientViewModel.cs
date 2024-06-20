using System.Threading.Tasks;
using CulinaryRecipesApp.ViewModels.Abstract;
using CulinaryRecipesApp.Views.IngredientV;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.IngredientVM;

public class IngredientViewModel : AItemsViewModel<IngredientDto>
{
    public IngredientViewModel() :
        base("Ingredient")
    {
    }

    public override async Task GoToAddPage()
    {
        await Shell.Current.GoToAsync(nameof(IngredientNewPage));
    }

    public override async Task GoToDetailsPage(IngredientDto Ingredient)
    {
        await Shell.Current.GoToAsync(
            $"{nameof(IngredientDetailPage)}?{nameof(IngredientDetailsViewModel.ItemId)}={Ingredient.Id}");
    }
}