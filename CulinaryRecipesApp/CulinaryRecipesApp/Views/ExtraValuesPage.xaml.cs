using CulinaryRecipesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ExtraValuesPage : ContentPage
{
    public ExtraValuesPage()
    {
        InitializeComponent();
        BindingContext = new ExtraValuesVieModel();
    }
}