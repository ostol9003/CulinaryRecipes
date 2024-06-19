using CulinaryRecipesApp.ViewModels.RecipeIngredientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.RecipeIngredientV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeIngredientUpdatePage : ContentPage
    {
        public RecipeIngredientUpdatePage()
        {
            InitializeComponent();
            BindingContext = new RecipeIngredientUpdateViewModel();
        }

    }
}