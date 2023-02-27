using Chemsoft.MVVM.Model;
using Chemsoft_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chemsoft.Windows
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private UserModel _user;

        internal EditUser(UserModel? user)
        {
            if (user == null) throw new ArgumentException("User cannot be null");

            InitializeComponent();
            _user = user;
            nameTB.Text = $"Редактирование пользователя #{user.ID}";
            ageTB.Text = _user.Age.ToString();
            fNameTB.Text = _user.FirstName;
            sNameTB.Text = _user.LastName;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)//todo добавить проверку на пустую строку
        {
            _user.Age = Convert.ToUInt32(ageTB.Text);
            
            using var context = new Context("Data Source=DESKTOP-N3F9INH;Initial Catalog=Chemsoft;Persist Security Info=True;User ID=sa;Password=sa;");
            await context.Connect();
            await context.ExecuteNonQueryAsync($"UPDATE Users SET Age={ageTB.Text}, FirstName='{fNameTB.Text}', LastName='{sNameTB.Text}' WHERE ID={_user.ID}");
            DialogResult = true;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using var context = new Context("Data Source=DESKTOP-N3F9INH;Initial Catalog=Chemsoft;Persist Security Info=True;User ID=sa;Password=sa;");
            await context.Connect();
            await context.ExecuteNonQueryAsync($"UPDATE Users SET IsDeleted=1 WHERE ID={_user.ID}");
            DialogResult = true;
        }
    }
}
