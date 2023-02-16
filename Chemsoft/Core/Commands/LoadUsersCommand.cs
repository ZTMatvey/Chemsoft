using Chemsoft.Core;
using Chemsoft.MVVM.Model;
using Chemsoft.MVVM.ViewModel;
using Chemsoft_DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chemsoft.Core.Commands
{
    internal class LoadUsersCommand : ICommand
    {
        private UsersViewModel _viewModel;

        public LoadUsersCommand(UsersViewModel viewModel)
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
            string connectionString = "Data Source=DESKTOP-BGRF52O;Initial Catalog=Chemsoft;Persist Security Info=True;User ID=sa;Password=sa;";
            var context = new Context(connectionString);
            await context.Connect();
            var reader = await context.GetReaderAsync("SELECT * FROM Users");

            List<User> users = new();

            while (await reader.ReadAsync())
            {
                object id = reader.GetValue(0);
                object age = reader.GetValue(1);
                object firstName = reader.GetValue(2);
                object lastName = reader.GetValue(3);

                _viewModel.Users.Add(new User()
                {
                    Id = Convert.ToInt32(id),
                    Age = Convert.ToInt32(age),
                    FirstName = firstName?.ToString() ?? "",
                    LastName = lastName?.ToString() ?? ""
                });
            }

            await context.Disconnect();
        }
    }
}
