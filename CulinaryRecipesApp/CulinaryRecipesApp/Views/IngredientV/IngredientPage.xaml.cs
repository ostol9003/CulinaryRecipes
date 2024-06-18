using CulinaryRecipesApp.ViewModels.IngredientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.IngredientV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientPage : ContentPage
    {
        private IngredientViewModel _viewModel;
        public IngredientPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new IngredientViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}