using System.Windows;
using System.Windows.Input;

namespace Chemsoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isMaximazed;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (_isMaximazed)
                {
                    Minimaze();
                }
                DragMove();
            }
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Ellipse_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (_isMaximazed)
            {
                Minimaze();
            }
            else
            {
                Maximaze();
            }
        }

        private void Maximaze()
        {
            WindowState = WindowState.Maximized;
            _isMaximazed = true;
        }

        private void Minimaze()
        {
            WindowState = WindowState.Normal;
            Width = 800;
            Height = 600;
            _isMaximazed = false;
        }
    }
}
