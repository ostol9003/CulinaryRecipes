using CulinaryRecipesApp.ViewModels.Abstract;
using RecipeAppService;

namespace CulinaryRecipesApp.ViewModels.RecipeVM;

public class NewRecipeViewModel : ANewItemViewModel<RecipeDto>
{
    public NewRecipeViewModel()
        : base("Add new recipe")
    {
    }

    public override bool ValidateSave()
    {
        return !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Instructions) &&
               !string.IsNullOrWhiteSpace(Description) && PrepTime > 0 && CookTime > 0;
    }

    public override RecipeDto SetItem()
    {
        return new RecipeDto
        {
            Title = Title,
            Description = Description,
            Instructions = Instructions,
            PrepTime = PrepTime,
            CookTime = CookTime,
            Url = Url
        };
    }

    #region Fields

    private string title;
    private string description;
    private string instructions;
    private int prepTime;
    private int cookTime;
    private string url;

    #endregion

    #region Properties

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

    #endregion
}