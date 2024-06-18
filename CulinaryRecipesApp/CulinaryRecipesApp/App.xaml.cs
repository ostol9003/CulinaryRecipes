using CulinaryRecipesApp.Services;
using CulinaryRecipesApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CulinaryRecipesApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<CategoryDataStore>();
            DependencyService.Register<IngredientDataStore>();
            DependencyService.Register<RecipeDataStore>();

            MainPage = new AppShell();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
