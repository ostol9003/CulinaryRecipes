using CulinaryRecipesApp.ViewModels.RecipeIngredientVM;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.Views.RecipeIngredientV
{
    public partial class NewRecipeIngredientPage : ContentPage
    {
        public RecipeIngredientDto Item { get; set; }
        public NewRecipeIngredientPage()
        {
            InitializeComponent();
            BindingContext = new NewRecipeIngredientViewModel();
        }
    }
}