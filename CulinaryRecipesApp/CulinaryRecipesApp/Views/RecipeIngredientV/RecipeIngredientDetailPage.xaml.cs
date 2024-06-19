using CulinaryRecipesApp.ViewModels.RecipeIngredientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.RecipeIngredientV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeIngredientDetailPage : ContentPage
    {
        public RecipeIngredientDetailPage()
        {
            InitializeComponent();
            BindingContext = new RecipeIngredientDetailsViewModel();
        }
    }
}