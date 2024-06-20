using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CulinaryRecipesApp.ViewModels.Abstract;
using CulinaryRecipesApp.Views.RecipeV;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.RecipeVM;

internal class RecipeDetailViewModel : AItemDetailsViewModel<RecipeDto>
{
    public RecipeDetailViewModel()
        : base("Recipe details")
    {
    }

    public override async Task LoadItem(int id)
    {
        try
        {
            var item = await DataStore.GetItemAsync(id);
            if (item == null)
                return;
            Id = id;
            Title = item.Title;
            Url = item.Url;
            Description = item.Description;
            Instructions = item.Instructions;
            PrepTime = item.PrepTime;
            CookTime = item.CookTime;
            Ingredients = (List<IngredientDto>)item.Ingredients;
            Categories = (List<CategoryDto>)item.Categories;
            RecipeIngredient = (List<RecipeIngredientDto>)item.RecipeIngredient;
        }
        catch (Exception)
        {
            Debug.WriteLine("Failed to Load Item");
        }
    }


    protected override async Task GoToUpdatePage()
    {
        await Shell.Current.GoToAsync($"{nameof(RecipeUpdatePage)}?{nameof(RecipeUpdateViewModel.ItemId)}={ItemId}");
    }

    #region fields

    private int id;
    private string title;
    private string description;
    private string instructions;
    private int prepTime;
    private int cookTime;
    private List<IngredientDto> ingredients;
    private List<CategoryDto> categories;
    private List<RecipeIngredientDto> recipeIngredient;
    private string url;

    #endregion

    #region properties

    public int Id
    {
        get => id;
        set => SetProperty(ref id, value);
    }

    public string Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    public string Description
    {
        get => description;
        set => SetProperty(ref description, value);
    }

    public string Instructions
    {
        get => instructions;
        set => SetProperty(ref instructions, value);
    }

    public int PrepTime
    {
        get => prepTime;
        set => SetProperty(ref prepTime, value);
    }

    public int CookTime
    {
        get => cookTime;
        set => SetProperty(ref cookTime, value);
    }

    public string Url
    {
        get => url;
        set => SetProperty(ref url, value);
    }

    public List<IngredientDto> Ingredients
    {
        get => ingredients;
        set
        {
            SetProperty(ref ingredients, value);
            OnPropertyChanged(nameof(IngredientsFormatted));
        }
    }

    public List<CategoryDto> Categories
    {
        get => categories;
        set
        {
            SetProperty(ref categories, value);
            OnPropertyChanged(nameof(CategoriesFormatted));
        }
    }

    public List<RecipeIngredientDto> RecipeIngredient
    {
        get => recipeIngredient;
        set
        {
            SetProperty(ref recipeIngredient, value);
            OnPropertyChanged(nameof(IngredientsFormatted));
        }
    }


    public string IngredientsFormatted => Ingredients != null && RecipeIngredient != null
        ? string.Join(", ",
            from ingredient in Ingredients
            join recipeIngredient in RecipeIngredient on ingredient.Id equals recipeIngredient.IngredientId
            select $"{ingredient.Name} {recipeIngredient.Quantity} {recipeIngredient.Unit}")
        : string.Empty;


    public string CategoriesFormatted => Categories != null
        ? string.Join(", ", Categories.Select(c => c.Name))
        : string.Empty;

    #endregion
}