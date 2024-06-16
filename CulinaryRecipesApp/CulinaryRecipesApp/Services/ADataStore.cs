namespace CulinaryRecipesApp.Services
{
    public abstract class ADataStore
    { 
        protected RecipeService recipeService;
        public ADataStore()
        {
            /*  //In case of using HTTPS on local - that's only for testing 
             *  //- you can use preprocessor method for checking if we are running in development.
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback = 
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

                var client = new HttpClient(handler);
             */
            recipeService = new RecipeService("http://localhost:7117", new System.Net.Http.HttpClient());
        }
    }
}