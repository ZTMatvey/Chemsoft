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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using var context = new Context("Data Source=DESKTOP-N3F9INH;Initial Catalog=Chemsoft;Persist Security Info=True;User ID=sa;Password=sa;");
            await context.Connect();
            await context.ExecuteNonQueryAsync($"INSERT INTO Users (Age, IsDeleted, FirstName, LastName) VALUES  ({ageTB.Text}, 0, '{fNameTB.Text}', '{sNameTB.Text}')");
            DialogResult = true;
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
