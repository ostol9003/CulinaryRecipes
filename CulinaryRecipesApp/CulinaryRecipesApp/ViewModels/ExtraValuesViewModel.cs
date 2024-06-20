using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryRecipesApp.Services;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels;

public class ExtraValuesVieModel : BaseViewModel
{
    public ExtraValuesVieModel()
    {
        selectedCategory = new CategoryDto();
        selectedIngredient = new IngredientDto();
        extraValuesDataStore = DependencyService.Get<ExtraValuesDataStore>();
        categories = DependencyService.Get<CategoryDataStore>().items;
        ingredients = DependencyService.Get<IngredientDataStore>().items;
        RecipesWithIngredientCommand = new Command(async () => await RecipesWithIngredientAsync());
        AveragePrepTimeInCategoryCommand = new Command(async () => await AveragePrepTimeInCategoryAsync());
    }

    #region Fields

    public CategoryDto selectedCategory;
    private List<CategoryDto> categories;
    public IngredientDto selectedIngredient;
    private List<IngredientDto> ingredients;
    private ExtraValuesDataStore extraValuesDataStore;
    private int recipesInCategory;
    private int recipesWithIngredient;
    private double averagePrepTime;
    private double averagePrepTimeInCategory;

    #endregion

    #region Properties

    public CategoryDto SelectedCategory
    {
        get => selectedCategory;
        set => SetProperty(ref selectedCategory, value);
    }

    public List<CategoryDto> Categories
    {
        get => categories;
        set => SetProperty(ref categories, value);
    }

    public IngredientDto SelectedIngredient
    {
        get => selectedIngredient;
        set => SetProperty(ref selectedIngredient, value);
    }

    public List<IngredientDto> Ingredients
    {
        get => ingredients;
        set => SetProperty(ref ingredients, value);
    }

    public ExtraValuesDataStore ExtraValuesDataStore
    {
        get => extraValuesDataStore;
        set => SetProperty(ref extraValuesDataStore, value);
    }

    public int RecipesInCategory
    {
        get => recipesInCategory;
        set => SetProperty(ref recipesInCategory, value);
    }

    public int RecipesWithIngredient
    {
        get => recipesWithIngredient;
        set => SetProperty(ref recipesWithIngredient, value);
    }

    public double AveragePrepTime
    {
        get => averagePrepTime;
        set => SetProperty(ref averagePrepTime, value);
    }

    public double AveragePrepTimeInCategory
    {
        get => averagePrepTimeInCategory;
        set => SetProperty(ref averagePrepTimeInCategory, value);
    }

    #endregion

    #region Commands

    public Command RecipesWithIngredientCommand { get; }
    public Command AveragePrepTimeInCategoryCommand { get; }

    public async Task RecipesWithIngredientAsync()
    {
        RecipesWithIngredient = await extraValuesDataStore.RecipesWithIngredient(SelectedIngredient.Id);
    }

    public async Task AveragePrepTimeInCategoryAsync()
    {
        AveragePrepTime = await extraValuesDataStore.AveragePrepTime();
        AveragePrepTimeInCategory = await extraValuesDataStore.AveragePrepTimeInCategory(SelectedCategory.Id);
        RecipesInCategory = await extraValuesDataStore.RecipesInCategory(SelectedCategory.Id);
    }

    #endregion
}