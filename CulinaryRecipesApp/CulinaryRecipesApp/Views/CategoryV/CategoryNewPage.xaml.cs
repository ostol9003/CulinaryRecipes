using CulinaryRecipesApp.ViewModels.CategoryVM;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.Views.CategoryV;

public partial class CategoryNewPage : ContentPage
{
    public CategoryNewPage()
    {
        InitializeComponent();
        BindingContext = new NewCategoryViewModel();
    }

    public CategoryDto Item { get; set; }
}