using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CulinaryRecipesApp.ViewModels.Abstract;
using RecipeAppService;

namespace CulinaryRecipesApp.ViewModels.RecipeVM;

public class RecipeUpdateViewModel : AItemUpdateViewModel<RecipeDto>
{
    public RecipeUpdateViewModel()
        : base("Update Recipe")
    {
    }

    public override async Task LoadItem(int id)
    {
        try
        {
            var item = await DataStore.GetItemAsync(id);
            if (item == null)
                return;

            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
            Instructions = item.Instructions;
            PrepTime = item.PrepTime;
            CookTime = item.CookTime;
            Url = item.Url;
            //  Ingredients = item.Ingredients?.ToList() ?? new List<IngredientDto>();
            // Categories = item.Categories?.ToList() ?? new List<CategoryDto>();
        }
        catch (Exception)
        {
            Debug.WriteLine("Failed to Load Item");
        }
    }

    public override RecipeDto SetItem()
    {
        return new RecipeDto()
        {
            Id = ItemId,
            Title = Title,
            Description = Description,
            Instructions = Instructions,
            PrepTime = PrepTime,
            CookTime = CookTime,
            Url = Url
            //  Ingredients = Ingredients,
            //  Categories = Categories
        };
    }

    public override bool ValidateSave()
    {
        return !string.IsNullOrWhiteSpace(Title);
    }

    #region fields

    private int id;
    private string title;
    private string description;
    private string instructions;
    private int prepTime; // In minutes

    private int cookTime; // In minutes

    // private List<IngredientDto> ingredients;
    // private List<CategoryDto> categories;
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

    /*  public List<IngredientDto> Ingredients
      {
          get => ingredients;
          set => SetProperty(ref ingredients, value);
      }

      public List<CategoryDto> Categories
      {
          get => categories;
          set => SetProperty(ref categories, value);
      }
    */

    #endregion
}