using System.Threading.Tasks;
using CulinaryRecipesApp.ViewModels.Abstract;
using CulinaryRecipesApp.Views.CategoryV;
using RecipeAppService;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.CategoryVM;

public class CategoryViewModel : AItemsViewModel<CategoryDto>
{
    public CategoryViewModel() :
        base("Category")
    {
    }

    public override async Task GoToAddPage()
    {
        await Shell.Current.GoToAsync(nameof(CategoryNewPage));
    }

    public override async Task GoToDetailsPage(CategoryDto category)
    {
        await Shell.Current.GoToAsync(
            $"{nameof(CategoryDetailPage)}?{nameof(CategoryDetailsViewModel.ItemId)}={category.Id}");
    }
}