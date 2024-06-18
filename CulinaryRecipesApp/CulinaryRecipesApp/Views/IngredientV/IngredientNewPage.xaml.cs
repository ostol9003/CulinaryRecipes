using CulinaryRecipesApp.ViewModels.IngredientVM;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.Views.IngredientV
{
    public partial class IngredientNewPage : ContentPage
    {
        public CategoryDto Item { get; set; }
        public IngredientNewPage()
        {
            InitializeComponent();
            BindingContext = new NewIngredientViewModel();
        }
    }
}