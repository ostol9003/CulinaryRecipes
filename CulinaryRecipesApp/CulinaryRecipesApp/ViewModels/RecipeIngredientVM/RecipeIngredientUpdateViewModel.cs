using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CulinaryRecipesApp.Services;
using CulinaryRecipesApp.ViewModels.Abstract;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.RecipeIngredientVM;

public class RecipeIngredientUpdateViewModel : AItemUpdateViewModel<RecipeIngredientDto>
{
    public RecipeIngredientUpdateViewModel()
        : base("Update Recipe Ingredient")
    {
        Recipes = DependencyService.Get<RecipeDataStore>().items;
        Ingredients = DependencyService.Get<IngredientDataStore>().items;
    }

    public override async Task LoadItem(int id)
    {
        try
        {
            var item = await DataStore.GetItemAsync(id);
            if (item == null)
                return;

            Id = item.Id;
            SelectedRecipe = Recipes.FirstOrDefault(r => r.Id == item.RecipeId);
            SelectedIngredient = Ingredients.FirstOrDefault(i => i.Id == item.IngredientId);
            Quantity = item.Quantity;
            Unit = item.Unit;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to Load Item: {ex.Message}");
        }
    }

    public override RecipeIngredientDto SetItem()
    {
        return new RecipeIngredientDto
        {
            Id = Id,
            RecipeId = SelectedRecipe.Id,
            IngredientId = SelectedIngredient.Id,
            Quantity = Quantity,
            Unit = Unit,
            RecipeName = SelectedRecipe.Title,
            IngredientName = SelectedIngredient.Name,
            IsActive = true
        };
    }

    public override bool ValidateSave()
    {
        return SelectedRecipe != null && SelectedIngredient != null && Quantity > 0 && !string.IsNullOrWhiteSpace(Unit);
    }

    #region Fields

    private int id;
    private RecipeDto selectedRecipe;
    private IngredientDto selectedIngredient;
    private double quantity;
    private string unit;

    #endregion

    #region Properties

    public List<RecipeDto> Recipes { get; }
    public List<IngredientDto> Ingredients { get; }

    public int Id
    {
        get => id;
        set => SetProperty(ref id, value);
    }

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