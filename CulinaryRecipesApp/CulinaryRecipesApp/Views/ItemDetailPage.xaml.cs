using CulinaryRecipesApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CulinaryRecipesApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}