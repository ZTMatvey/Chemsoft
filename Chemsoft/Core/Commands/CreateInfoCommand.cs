using Chemsoft.MVVM.Model;
using Chemsoft.MVVM.ViewModel;
using Chemsoft_DB;
using System;
using System.Windows.Input;

namespace Chemsoft.Core.Commands
{
    [Obsolete]
    internal sealed class CreateInfoCommand : ICommand
    {
        private UsersViewModel _viewModel;

        public CreateInfoCommand(UsersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            if (parameter is null || parameter is not UserModel user) return;

            var context = new Context("Data Source=DESKTOP-N3F9INH;Initial Catalog=Chemsoft;Persist Security Info=True;User ID=sa;Password=sa;");
            var query = $"INSERT INTO Users (Age, IsDeleted, FirstName, LastName) VALUES ({user.Age}, 0, '{user.FirstName}', '{user.LastName}')";

            await context.ExecuteNonQueryAsync(query);
        }
    }
}
