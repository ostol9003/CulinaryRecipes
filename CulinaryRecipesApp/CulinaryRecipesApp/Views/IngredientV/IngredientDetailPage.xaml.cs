using CulinaryRecipesApp.ViewModels.IngredientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.IngredientV;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class IngredientDetailPage : ContentPage
{
    public IngredientDetailPage()
    {
        InitializeComponent();
        BindingContext = new IngredientDetailsViewModel();
    }
}