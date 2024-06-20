using CulinaryRecipesApp.Services;
using Xamarin.Forms;

namespace CulinaryRecipesApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        DependencyService.Register<CategoryDataStore>();
        DependencyService.Register<IngredientDataStore>();
        DependencyService.Register<RecipeDataStore>();
        DependencyService.Register<RecipeIngredientDataStore>();
        DependencyService.Register<ExtraValuesDataStore>();

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