using System.Threading.Tasks;
using CulinaryRecipesApp.Services;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels.Abstract;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public abstract class AItemUpdateViewModel<T> : BaseViewModel
{
    private int itemId;

    public AItemUpdateViewModel(string title)
    {
        Title = title;
        SaveCommand = new Command(OnSave, ValidateSave);
        CancelCommand = new Command(OnCancel);
        PropertyChanged +=
            (_, __) => SaveCommand.ChangeCanExecute();
    }

    public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

    public int ItemId
    {
        get => itemId;
        set
        {
            itemId = value;
            LoadItem(value).GetAwaiter().GetResult();
        }
    }

    public Command SaveCommand { get; }
    public Command CancelCommand { get; }
    public abstract bool ValidateSave();

    private async void OnCancel()
    {
        await Shell.Current.GoToAsync("..");
    }

    public abstract T SetItem();
    public abstract Task LoadItem(int id);

    private async void OnSave()
    {
        await DataStore.UpdateItemAsync(SetItem());
        // This will pop the current page off the navigation stack
        await Shell.Current.GoToAsync("..");
    }
}