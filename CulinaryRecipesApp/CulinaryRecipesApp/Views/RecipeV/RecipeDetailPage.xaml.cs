using CulinaryRecipesApp.ViewModels.RecipeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.RecipeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetailPage : ContentPage
    {
        private RecipeDetailViewModel _viewModel;
        public RecipeDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RecipeDetailViewModel();
        }
       
    }
}