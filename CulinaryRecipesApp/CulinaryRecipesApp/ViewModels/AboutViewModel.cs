using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CulinaryRecipesApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private ObservableCollection<CarouselItemViewModel> _carouselItems;
        private int _currentIndex;
        private bool _isAutoScrolling;
        private readonly int _totalItems;

        public AboutViewModel()
        {
            _currentIndex = 0;
            _isAutoScrolling = true;
            _totalItems = 4; // Ustaw ilość elementów w karuzeli
            CarouselItems = new ObservableCollection<CarouselItemViewModel>
            {
                new CarouselItemViewModel { ImageSource = "Assets/car1.jpg" },
                new CarouselItemViewModel { ImageSource = "Assets/car2.jpg" },
                new CarouselItemViewModel { ImageSource = "Assets/car3.jpg" },
                new CarouselItemViewModel { ImageSource = "Assets/car4.jpg" }
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
                    OnPropertyChanged(nameof(CurrentIndex)); // Powiadom o zmianie indeksu
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
}
