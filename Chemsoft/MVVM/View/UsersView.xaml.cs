using Chemsoft.MVVM.Model;
using Chemsoft.MVVM.ViewModel;
using Chemsoft.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chemsoft.MVVM.View
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public ICommand LoadCommand
        {
            get { return (ICommand)GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value); }
        }

        public static readonly DependencyProperty LoadCommandProperty =
            DependencyProperty.Register("LoadCommand", typeof(ICommand), typeof(UsersView), new PropertyMetadata(null));

        public ICommand UserCellEditEnding
        {
            get { return (ICommand)GetValue(CellEditEndingProperty); }
            set { SetValue(CellEditEndingProperty, value); }
        }

        public static readonly DependencyProperty CellEditEndingProperty =
            DependencyProperty.Register("UserCellEditEnding", typeof(ICommand), typeof(UsersView), new PropertyMetadata(null));

        public ICommand CreateInfoCommand
        {
            get { return (ICommand)GetValue(CreateInfoCommandProperty); }
            set { SetValue(CreateInfoCommandProperty, value); }
        }

        public static readonly DependencyProperty CreateInfoCommandProperty =
            DependencyProperty.Register("CreateInfoCommand", typeof(ICommand), typeof(UsersView), new PropertyMetadata(null));

        public UsersView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dtUsers.SelectedValue is not UserModel model) return;

            var editUser = new EditUser(model);
            editUser.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var editUser = new Create();
            editUser.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ((UsersViewModel)DataContext).Update();
        }
    }
}