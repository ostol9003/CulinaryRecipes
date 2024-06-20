using CulinaryRecipesApp.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.CategoryV;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class CategoryPage : ContentPage
{
    private readonly CategoryViewModel _viewModel;

    public CategoryPage()
    {
        InitializeComponent();
        BindingContext = _viewModel = new CategoryViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}