using CulinaryRecipesApp.ViewModels.RecipeIngredientVM;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.Views.RecipeIngredientV;

public partial class NewRecipeIngredientPage : ContentPage
{
    public NewRecipeIngredientPage()
    {
        InitializeComponent();
        BindingContext = new NewRecipeIngredientViewModel();
    }

    public RecipeIngredientDto Item { get; set; }
}