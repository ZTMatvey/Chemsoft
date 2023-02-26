using System.Collections.ObjectModel;
using Chemsoft.MVVM.Model;
using System.Windows.Input;
using Chemsoft.Core.Commands;
using Chemsoft_DB;
using System.Collections.Generic;
using System;

namespace Chemsoft.MVVM.ViewModel
{
    internal sealed class UsersViewModel
    {
        private ICommand _createInfoCommand;
        private ICommand _userCellEditEnding;

        public UserModel? User { get; set; }

        public ObservableCollection<UserModel>? Users { get; set; } = new();

        public ICommand UserCellEditEnding { get; set; }

        public ICommand CreateInfoCommand { get; set; }

        public UsersViewModel()
        {
            Initialize();
            _userCellEditEnding = new UpdateInfoCommand(this);
            _createInfoCommand = new CreateInfoCommand(this);
        }

        private async void Initialize()
        {
            var context = new Context("Data Source=DESKTOP-N3F9INH;Initial Catalog=Chemsoft;Persist Security Info=True;User ID=sa;Password=sa;");
            await context.ExecuteReaderAsync("SELECT * FROM Users", async reader =>
            {
                while (await reader.ReadAsync())
                {
                    var id = reader.GetValue(0);
                    var age = reader.GetValue(1);
                    var firstName = reader.GetValue(2);
                    var lastName = reader.GetValue(3);

                    Users?.Add(new UserModel(Convert.ToUInt64(id), firstName.ToString(), lastName.ToString(), Convert.ToInt32(age)));
                }
            });
        }
    }
}
