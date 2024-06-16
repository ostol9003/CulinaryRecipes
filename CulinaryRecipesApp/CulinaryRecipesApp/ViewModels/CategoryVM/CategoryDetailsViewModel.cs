using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CulinaryRecipesApp.ViewModels.Abstract;
using CulinaryRecipesApp.Views.CategoryV;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.CategoryVM
{
    internal class CategoryDetailsViewModel : AItemDetailsViewModel<CategoryDto>
    {
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
        public CategoryDetailsViewModel() 
            : base("Category details")
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
                Name = item.Name;
                Url = item.Url;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }


        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"{nameof(CategoryUpdatePage)}?{nameof(CategoryDetailsViewModel.ItemId)}={ItemId}");
    }
}
