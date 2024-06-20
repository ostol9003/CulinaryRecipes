using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CulinaryRecipesApp.ViewModels;

public class AboutViewModel : BaseViewModel
{
    private readonly int _totalItems;
    private ObservableCollection<CarouselItemViewModel> _carouselItems;
    private int _currentIndex;
    private bool _isAutoScrolling;

    public AboutViewModel()
    {
        _currentIndex = 0;
        _isAutoScrolling = true;
        _totalItems = 4; // Ustaw ilość elementów w karuzeli
        CarouselItems = new ObservableCollection<CarouselItemViewModel>
        {
            new() { ImageSource = "Assets/car1.jpg" },
            new() { ImageSource = "Assets/car2.jpg" },
            new() { ImageSource = "Assets/car3.jpg" },
            new() { ImageSource = "Assets/car4.jpg" }
        };

        StartAutoScroll();
    }

    public ObservableCollection<CarouselItemViewModel> CarouselItems
    {
        get => _carouselItems;
        set => SetProperty(ref _carouselItems, value);
    }

    public int CurrentIndex
    {
        get => _currentIndex;
        set
        {
            if (_currentIndex != value)
            {
                _currentIndex = value;
                OnPropertyChanged(); // Powiadom o zmianie indeksu
            }
        }
    }

    private async void StartAutoScroll()
    {
        while (_isAutoScrolling)
        {
            await Task.Delay(3000); // Czas oczekiwania na następny przewijany element
            CurrentIndex = (_currentIndex + 1) % _totalItems; // Przełącz na następny element
        }
    }

    public void StopAutoScroll()
    {
        _isAutoScrolling = false;
    }

    public void ResumeAutoScroll()
    {
        _isAutoScrolling = true;
        StartAutoScroll();
    }
}

public class CarouselItemViewModel
{
    public string ImageSource { get; set; }
}