using System.Net.Http;
using System.Threading;
using RecipeAppService;
namespace CulinaryRecipesApp.Services
{
    public abstract class ADataStore
    { 
        protected RecipeApp recipeService;
        public ADataStore()
        {

              //In case of using HTTPS on local - that's only for testing
              //- you can use preprocessor method for checking if we are running in development.
                var handler = new HttpClientHandler();
#if DEBUG
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            var client = new HttpClient(handler);
             
            recipeService = new RecipeApp("https://localhost:7117", client);
        }
    }
}