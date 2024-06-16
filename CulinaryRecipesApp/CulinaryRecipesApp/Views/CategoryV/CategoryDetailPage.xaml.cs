using CulinaryRecipesApp.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views.CategoryV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailPage : ContentPage
    {
        public CategoryDetailPage()
        {
            InitializeComponent();
            BindingContext = new CategoryDetailsViewModel();
        }
    }
}