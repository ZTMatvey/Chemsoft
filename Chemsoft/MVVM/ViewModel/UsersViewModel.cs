using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chemsoft_DB;
using System.Windows;
using System.Collections.ObjectModel;
using Chemsoft.MVVM.Model;
using System.Windows.Controls;
using System.Windows.Input;
using Chemsoft.Core.Commands;

namespace Chemsoft.MVVM.ViewModel
{
    internal sealed class UsersViewModel
    {
        public ICommand LoadUsersCommand { get; set; } 
        public ObservableCollection<User> Users { get; set; } = new();

        public UsersViewModel()
        {
            LoadUsersCommand = new LoadUsersCommand(this);
        }
    }
}
