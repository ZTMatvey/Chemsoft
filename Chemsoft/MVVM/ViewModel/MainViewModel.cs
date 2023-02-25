using Chemsoft.Core;
using Chemsoft.Core.Commands;

namespace Chemsoft.MVVM.ViewModel
{
    internal sealed class MainViewModel : ObservableObject
    {
        private object? _currentView;
        private object? _previousView;

        public object? CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public object? PreviousUer
        {
            get { return _previousView; }
            set
            {
                _previousView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand HomeRelayCommand { get; set; }

        public RelayCommand CloseRelayCommand { get; set; }

        public RelayCommand UsersRelayCommand { get; set; }

        public HomeViewModel HomeViewModel { get; set; } = new();

        public UsersViewModel UsersViewModel { get; set; }

        public CloseViewModel CloseViewModel { get; set; }

        public MainViewModel()
        {
            HomeRelayCommand = new(o =>
            {
                HomeViewModel = new();
                CurrentView = HomeViewModel;
            });
            UsersRelayCommand = new(o =>
            {
                UsersViewModel?.Users?.Clear();
                UsersViewModel = new();
                CurrentView = UsersViewModel;
            });
            CloseRelayCommand = new(e =>
            {
                CloseViewModel = new();
                CurrentView = CloseViewModel;
            });

            CurrentView = HomeViewModel;

        }
    }
}
