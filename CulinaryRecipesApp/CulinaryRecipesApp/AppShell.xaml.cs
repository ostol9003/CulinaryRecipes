using System;
using CulinaryRecipesApp.Views.CategoryV;
using Xamarin.Forms;

namespace CulinaryRecipesApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CategoryDetailPage), typeof(CategoryDetailPage));
            Routing.RegisterRoute(nameof(CategoryNewPage), typeof(CategoryNewPage));
         
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
