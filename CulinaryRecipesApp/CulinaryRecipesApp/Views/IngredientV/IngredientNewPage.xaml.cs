using CulinaryRecipesApp.ViewModels.IngredientVM;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.Views.IngredientV;

public partial class IngredientNewPage : ContentPage
{
    public IngredientNewPage()
    {
        InitializeComponent();
        BindingContext = new NewIngredientViewModel();
    }

    public CategoryDto Item { get; set; }
}