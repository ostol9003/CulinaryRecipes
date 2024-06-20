using System;
using System.Threading.Tasks;
using RecipeAppService;

namespace CulinaryRecipesApp.Services
{
    public class UserDataStore : ADataStore
    {
        public UserDataStore()
            : base()
        {
        }
          public async Task<UserDto> GetUser(string email)
              => await recipeService.EmailAsync(email);
    }
}