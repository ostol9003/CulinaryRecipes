using CulinaryRecipesApp.ViewModels.RecipeIngredientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.RecipeIngredientV;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class RecipeIngredientPage : ContentPage
{
    private readonly RecipeIngredientViewModel _viewModel;

    public RecipeIngredientPage()
    {
        InitializeComponent();
        BindingContext = _viewModel = new RecipeIngredientViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}