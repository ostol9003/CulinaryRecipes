using CulinaryRecipesApp.ViewModels.CategoryVM;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.Views.CategoryV
{
    public partial class CategoryNewPage : ContentPage
    {
        public CategoryDto Item { get; set; }
        public CategoryNewPage()
        {
            InitializeComponent();
            BindingContext = new NewCategoryViewModel();
        }
    }
}