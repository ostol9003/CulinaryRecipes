using CulinaryRecipesApp.ViewModels.RecipeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.RecipeV;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class RecipeNewPage : ContentPage
{
    private NewRecipeViewModel _viewModel;

    public RecipeNewPage()
    {
        InitializeComponent();
        BindingContext = _viewModel = new NewRecipeViewModel();
    }
}