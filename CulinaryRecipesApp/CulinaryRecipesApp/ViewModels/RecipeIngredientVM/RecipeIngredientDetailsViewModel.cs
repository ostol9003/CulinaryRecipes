using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CulinaryRecipesApp.ViewModels.Abstract;
using CulinaryRecipesApp.Views.RecipeIngredientV;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.RecipeIngredientVM
{
    internal class RecipeIngredientDetailsViewModel : AItemDetailsViewModel<RecipeIngredientDto>
    {
        #region fields

        private int id;
        private int recipeId;
        private int ingredientId;
        private double quantity;
        private string unit;
        private string recipeName;
        private string ingredientName;
        #endregion

        #region properties

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public int RecipeId
        {
            get => recipeId;
            set => SetProperty(ref recipeId, value);
        }
        public int IngredientId
        {
            get => ingredientId;
            set => SetProperty(ref ingredientId, value);
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
        public string RecipeName
        {
            get => recipeName;
            set => SetProperty(ref recipeName, value);
        }
        public string IngredientName
        {
            get => ingredientName;
            set => SetProperty(ref ingredientName, value);
        }
        #endregion
        public RecipeIngredientDetailsViewModel() 
            : base("RecipeIngredient details")
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
                RecipeId = item.RecipeId;
                IngredientId = item.IngredientId;
                Quantity = item.Quantity;
                Unit = item.Unit;
                RecipeName = item.RecipeName;
                IngredientName = item.IngredientName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }


        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"{nameof(RecipeIngredientUpdatePage)}?{nameof(RecipeIngredientDetailsViewModel.ItemId)}={ItemId}");
    }
}
