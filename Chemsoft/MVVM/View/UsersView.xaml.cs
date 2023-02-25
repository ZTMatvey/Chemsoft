using Chemsoft.MVVM.Model;
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

        private void UsersView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCommand?.Execute(null);
        }
        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            var user = dtUsers.SelectedItem as UserModel;
            if (dtUsers.SelectedItem is not UserModel userr) return;

            UserCellEditEnding?.Execute(user);
        }

        private void dtUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("start");
        }

        private void dtUsers_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show("atop");
        }
    }
}