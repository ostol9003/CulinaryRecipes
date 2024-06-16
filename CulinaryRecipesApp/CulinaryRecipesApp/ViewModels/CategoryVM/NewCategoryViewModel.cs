using CulinaryRecipesApp.ViewModels.Abstract;
using RecipeAppService;

namespace CulinaryRecipesApp.ViewModels.CategoryVM
{
    public class NewCategoryViewModel : ANewItemViewModel<CategoryDto>
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
        public NewCategoryViewModel()
            : base("Add new category")
        {
        }

        public override bool ValidateSave()
            => Id > 0 && !string.IsNullOrWhiteSpace(Name);
        public override CategoryDto SetItem()
            => new CategoryDto()
            {
                Id = Id,
                Name = Name,
                Url = url
            };
    }
}
