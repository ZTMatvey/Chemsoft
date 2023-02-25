using System.Collections.ObjectModel;
using Chemsoft.MVVM.Model;
using System.Windows.Input;
using Chemsoft.Core.Commands;

namespace Chemsoft.MVVM.ViewModel
{
    internal sealed class UsersViewModel
    {
        private ICommand _createInfoCommand;
        private ICommand _userCellEditEnding;
        private ICommand _loadUsersCommand;

        public UserModel? User { get; set; }

        public ICommand LoadUsersCommand { get; set; }

        public ICommand UserCellEditEnding { get; set; }
        public ICommand CreateInfoCommand { get; set; }

        public ObservableCollection<UserModel>? Users { get; set; } = new();

        public UsersViewModel()
        {
            _loadUsersCommand = new LoadUsersCommand(this);
            _userCellEditEnding = new UpdateInfoCommand(this);
            _createInfoCommand = new CreateInfoCommand(this);
        }
    }
}
