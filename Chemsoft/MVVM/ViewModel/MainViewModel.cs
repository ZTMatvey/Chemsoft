using Chemsoft.Core;
using Chemsoft.Core.Commands;
using Chemsoft.Windows;
using System;
using System.Windows;

namespace Chemsoft.MVVM.ViewModel
{
    internal sealed class MainViewModel : ObservableObject
    {
        private object? _currentView;

        public object? CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand HomeRelayCommand { get; set; }

        public RelayCommand CloseRelayCommand { get; set; }

        public RelayCommand UsersRelayCommand { get; set; }

        public HomeViewModel HomeViewModel { get; set; } = new();

        public UsersViewModel UsersViewModel { get; set; }

        public MainViewModel()
        {
            HomeRelayCommand = new(o =>
            {
                HomeViewModel = new();
                CurrentView = HomeViewModel;
            });
            UsersRelayCommand = new(o =>
            {
                UsersViewModel = new();
                UsersViewModel?.Users?.Clear();
                CurrentView = UsersViewModel;
            });
            CloseRelayCommand = new(o =>
            {
                var confirm = new Confirm();
                var result = confirm.ShowDialog();

                if (result != null && result.Value)
                {
                    App.Current.MainWindow.Close();
                }
            });

            CurrentView = HomeViewModel;
        }
    }
}
