﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CulinaryRecipesApp.Helpers;
using CulinaryRecipesApp.ViewModels.Abstract;
using RecipeAppService;

namespace CulinaryRecipesApp.ViewModels.CategoryVM;

public class CategoryUpdateViewModel : AItemUpdateViewModel<CategoryDto>
{
    public CategoryUpdateViewModel()
        : base("Update category")
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
            this.CopyProperties(item);
        }
        catch (Exception)
        {
            Debug.WriteLine("Failed to Load Item");
        }
    }

    public override CategoryDto SetItem()
    {
        return new CategoryDto
        {
            Id = ItemId
        }.CopyProperties(this);
    }

    public override bool ValidateSave()
    {
        return ItemId > 0 && !string.IsNullOrWhiteSpace(Name);
    }

    #region fields

    private int id;
    private string name;
    private string url;

    #endregion

    #region properties

    public int Id
    {
        get => id;
        set => SetProperty(ref id, value);
    }

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