using CulinaryRecipesApp.ViewModels.RecipeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.RecipeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeUpdatePage : ContentPage
    {
        public RecipeUpdatePage()
        {
            InitializeComponent();
            BindingContext = new RecipeUpdateViewModel();
        }

    }
}