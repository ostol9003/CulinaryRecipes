using CulinaryRecipesApp.ViewModels.IngredientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.IngredientV;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class IngredientUpdatePage : ContentPage
{
    public IngredientUpdatePage()
    {
        InitializeComponent();
        BindingContext = new IngredientUpdateViewModel();
    }
}