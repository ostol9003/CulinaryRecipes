using System.Threading.Tasks;
using API.Helpers;
using CulinaryRecipesApp.Services;
using CulinaryRecipesApp.Views;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly UserDataStore userDataStore;

    private string email;
    private string password;

    public LoginViewModel()
    {
        userDataStore = new UserDataStore(); 

        LoginCommand = new Command(async () => await OnLoginClicked());
    }

    public string Email
    {
        get => email;
        set => SetProperty(ref email, value);
    }

    public string Password
    {
        get => password;
        set => SetProperty(ref password, value);
    }

    public Command LoginCommand { get; }

    private async Task OnLoginClicked()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter email and password.", "OK");
            return;
        }

        
        var user = await userDataStore.GetUser(Email);

        if (user.Email.Equals("1"))
        {
           
            await Application.Current.MainPage.DisplayAlert("Error", "Invalid email or password.", "OK");
            return;
        }

        // Sprawdź hasło tylko jeśli użytkownik nie jest null
        if (!PasswordHelper.VerifyPassword(Password, user.PasswordHash))
           
            await Application.Current.MainPage.DisplayAlert("Error", "Invalid email or password.", "OK");
        else
            
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
    }
}