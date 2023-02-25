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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chemsoft.Controls
{
    /// <summary>
    /// Interaction logic for Cross.xaml
    /// </summary>
    public partial class Cross : UserControl
    {
        public string CrossColor
        {
            get { return (string)GetValue(CrossColorProperty); }
            set { SetValue(CrossColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CrossColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CrossColorProperty =
            DependencyProperty.Register("CrossColor", typeof(string), typeof(Cross), new PropertyMetadata(string.Empty));

        public int CornerRadiusProperty
        {
            get { return (int)GetValue(CornerRadiusPropertyProperty); }
            set { SetValue(CornerRadiusPropertyProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusPropertyProperty =
            DependencyProperty.Register("CornerRadiusProperty", typeof(int), typeof(Cross), new PropertyMetadata(0));

        public int CrossHeightProperty
        {
            get { return (int)GetValue(CrossHeightPropertyProperty); }
            set { SetValue(CrossHeightPropertyProperty, value); }
        }

        public static readonly DependencyProperty CrossHeightPropertyProperty =
            DependencyProperty.Register("CrossHeightProperty", typeof(int), typeof(Cross), new PropertyMetadata(0));

        public int CrossWidthProperty
        {
            get { return (int)GetValue(CrossWidthPropertyProperty); }
            set { SetValue(CrossWidthPropertyProperty, value); }
        }

        public static readonly DependencyProperty CrossWidthPropertyProperty =
            DependencyProperty.Register("CrossWidthProperty", typeof(int), typeof(Cross), new PropertyMetadata(0));

        public Cross()
        {
            InitializeComponent();  
        }
    }
}
