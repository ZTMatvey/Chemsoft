using System.Collections.ObjectModel;
using Chemsoft.MVVM.Model;
using System.Windows.Input;
using Chemsoft.Core.Commands;
using Chemsoft_DB;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Chemsoft.MVVM.ViewModel
{
    internal sealed class UsersViewModel
    {
        public UserModel? SelectedUser { get; set; }

        public ObservableCollection<UserModel> Users { get; set; } = new();

        public ICommand UserCellEditEnding { get; set; }

        public ICommand UpdateUser { get; set; }

        public UsersViewModel()
        {
            Update();
            UpdateUser = new UpdateInfoCommand(this);
        }

        public async void Update()
        {
            Users.Clear();
            var context = new Context("Data Source=DESKTOP-N3F9INH;Initial Catalog=Chemsoft;Persist Security Info=True;User ID=sa;Password=sa;");
            await context.ExecuteReaderAsync("SELECT * FROM Users", async reader => //todo сделать выгрузку чанками
            {
                while (await reader.ReadAsync())
                {
                    var isDeletedObj = reader.GetValue(1);
                    var isDeleted = Convert.ToInt16(isDeletedObj);
                    if (isDeleted == 1) continue;

                    var id = reader.GetValue(0);
                    var age = reader.GetValue(2);
                    var firstName = reader.GetValue(3);
                    var lastName = reader.GetValue(4);

                    var user = new UserModel(Convert.ToUInt64(id), firstName.ToString(), lastName.ToString(), Convert.ToUInt32(age));

                    Users?.Add(user);
                }
            });
        }
    }
}
;