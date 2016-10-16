using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjectResourcesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            // Get the brush and make a change.
            //RadialGradientBrush b = (RadialGradientBrush)Resources["myBrush"];
            //b.GradientStops[1] = new GradientStop(Colors.Black, 0.0);

            // Put a totally new brush into the myBrush slot.
            Resources["myBrush"] = new SolidColorBrush(Colors.Red);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            TestWindow w = new TestWindow();
            w.Owner = this;
            w.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            w.ShowDialog();
        }
    }
}
