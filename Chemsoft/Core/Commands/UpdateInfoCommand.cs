using Chemsoft.MVVM.ViewModel;
using Chemsoft_DB;
using System;
using System.Windows.Input;
using Chemsoft.MVVM.Model;
using System.Windows.Resources;
using System.Collections;

namespace Chemsoft.Core.Commands
{
    [Obsolete]
    internal class UpdateInfoCommand : ICommand
    {
        private UsersViewModel _viewModel;

        public UpdateInfoCommand(UsersViewModel viewModel)
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
            if (parameter is not UserModel user) return; 

            var expression = $@"UPDATE Users SET {parameter} WHERE Id={user.ID}";

            var context = new Context(expression);

            await context.ExecuteNonQueryAsync(expression);

        }
    }
}