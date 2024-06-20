using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CulinaryRecipesApp.Helpers;

public static class RequestHelper
{
    public static async Task<bool> HandleRequest(this Task serviceMethod)
    {
        try
        {
            await serviceMethod;
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}