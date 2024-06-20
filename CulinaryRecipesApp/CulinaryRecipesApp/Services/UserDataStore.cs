using System.Threading.Tasks;
using RecipeAppService;

namespace CulinaryRecipesApp.Services;

public class UserDataStore : ADataStore
{
    public async Task<UserDto> GetUser(string email)
    {
        return await recipeService.EmailAsync(email);
    }
}