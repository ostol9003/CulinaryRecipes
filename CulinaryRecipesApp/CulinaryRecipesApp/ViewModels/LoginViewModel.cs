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
        userDataStore = new UserDataStore(); // Zakładam, że masz serwis do zarządzania danymi użytkowników

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
            // Możesz obsłużyć przypadek, gdy email lub hasło są puste
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter email and password.", "OK");
            return;
        }

        // Pobierz użytkownika na podstawie emaila z serwisu (lub innej odpowiedniej metody)
        var user = await userDataStore.GetUser(Email);

        if (user.Email.Equals("1"))
        {
            // Obsłuż przypadek, gdy użytkownik nie istnieje
            await Application.Current.MainPage.DisplayAlert("Error", "Invalid email or password.", "OK");
            return;
        }

        // Sprawdź hasło tylko jeśli użytkownik nie jest null
        if (!PasswordHelper.VerifyPassword(Password, user.PasswordHash))
            // Obsłuż przypadek, gdy hasło jest niepoprawne
            await Application.Current.MainPage.DisplayAlert("Error", "Invalid email or password.", "OK");
        else
            // Przejdź do kolejnej strony po poprawnym zalogowaniu
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
    }
}