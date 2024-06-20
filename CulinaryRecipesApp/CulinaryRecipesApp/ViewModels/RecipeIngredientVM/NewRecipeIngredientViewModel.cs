using System.Collections.Generic;
using CulinaryRecipesApp.Services;
using CulinaryRecipesApp.ViewModels.Abstract;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.RecipeIngredientVM;

public class NewRecipeIngredientViewModel : ANewItemViewModel<RecipeIngredientDto>
{
    public NewRecipeIngredientViewModel()
        : base("Add new RecipeIngredient")
    {
        Recipes = DependencyService.Get<RecipeDataStore>().items;
        Ingredients = DependencyService.Get<IngredientDataStore>().items;
    }

    public override bool ValidateSave()
    {
        // Validate required fields here
        return SelectedRecipe != null && SelectedIngredient != null && quantity > 0 && !string.IsNullOrWhiteSpace(Unit);
    }

    public override RecipeIngredientDto SetItem()
    {
        return new RecipeIngredientDto
        {
            RecipeId = SelectedRecipe.Id,
            IngredientId = SelectedIngredient.Id,
            Quantity = Quantity,
            Unit = Unit,
            RecipeName = SelectedRecipe.Title,
            IngredientName = SelectedIngredient.Name
        };
    }

    #region Fields

    private RecipeDto selectedRecipe;
    private IngredientDto selectedIngredient;
    private double quantity;
    private string unit;

    #endregion

    #region Properties

    public List<RecipeDto> Recipes { get; }
    public List<IngredientDto> Ingredients { get; }

    public RecipeDto SelectedRecipe
    {
        get => selectedRecipe;
        set => SetProperty(ref selectedRecipe, value);
    }

    public IngredientDto SelectedIngredient
    {
        get => selectedIngredient;
        set => SetProperty(ref selectedIngredient, value);
    }

    public double Quantity
    {
        get => quantity;
        set => SetProperty(ref quantity, value);
    }

    public string Unit
    {
        get => unit;
        set => SetProperty(ref unit, value);
    }

    #endregion
}