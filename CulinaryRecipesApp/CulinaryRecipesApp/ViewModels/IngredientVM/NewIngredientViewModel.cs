﻿using CulinaryRecipesApp.ViewModels.Abstract;
using RecipeAppService;

namespace CulinaryRecipesApp.ViewModels.IngredientVM;

public class NewIngredientViewModel : ANewItemViewModel<IngredientDto>
{
    public NewIngredientViewModel()
        : base("Add new Ingredient")
    {
    }

    public override bool ValidateSave()
    {
        return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Url);
    }

    public override IngredientDto SetItem()
    {
        return new IngredientDto()
        {
            //Id = 0,
            Name = Name,
            Url = Url
        };
    }

    #region fields

    // private int id;
    private string name;
    private string url;

    #endregion

    #region properties

    //public int Id
    //{
    //    get => id;
    //    set => SetProperty(ref id, value);
    //}
    public string Name
    {
        get => name;
        set => SetProperty(ref name, value);
    }

    public string Url
    {
        get => url;
        set => SetProperty(ref url, value);
    }

    #endregion
}