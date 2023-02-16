using Chemsoft.Core;
using Chemsoft.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public RelayCommand UsersRelayCommand { get; set; }

        public HomeViewModel HomeViewModel { get; set; } = new();

        public UsersViewModel UsersViewModel { get; set; } = new();

        public MainViewModel()
        {
            CurrentView = HomeViewModel;

            HomeRelayCommand = new(o =>
            {
                CurrentView = HomeViewModel;
            });
            UsersRelayCommand = new(o =>
            {
                CurrentView = UsersViewModel;
            });
        }
    }
}
