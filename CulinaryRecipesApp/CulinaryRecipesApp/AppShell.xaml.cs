using System;
using CulinaryRecipesApp.Views.CategoryV;
using CulinaryRecipesApp.Views.CategoryV;
using CulinaryRecipesApp.Views.IngredientV;
using CulinaryRecipesApp.Views.RecipeV;
using Xamarin.Forms;

namespace CulinaryRecipesApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Category
            Routing.RegisterRoute(nameof(CategoryDetailPage), typeof(CategoryDetailPage));
            Routing.RegisterRoute(nameof(CategoryNewPage), typeof(CategoryNewPage));
            Routing.RegisterRoute(nameof(CategoryUpdatePage), typeof(CategoryUpdatePage));
            //Ingredient
            Routing.RegisterRoute(nameof(IngredientDetailPage), typeof(IngredientDetailPage));
            Routing.RegisterRoute(nameof(IngredientNewPage), typeof(IngredientNewPage));
            Routing.RegisterRoute(nameof(IngredientUpdatePage), typeof(IngredientUpdatePage));
            //Recipe
             Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
             Routing.RegisterRoute(nameof(RecipeUpdatePage), typeof(RecipeUpdatePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
