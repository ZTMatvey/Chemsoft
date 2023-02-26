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
    }
}