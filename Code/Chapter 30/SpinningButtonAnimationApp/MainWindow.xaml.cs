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

using System.Windows.Media.Animation;

namespace SpinningButtonAnimationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isSpinning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region MouseEnter handler
        private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isSpinning)
            {
                isSpinning = true;

                // Make a double animation object, and register
                // with the Completed event. 
                DoubleAnimation dblAnim = new DoubleAnimation();
                dblAnim.Completed += (o, s) => { isSpinning = false; };

                // Button has 4 seconds to finish the spin!
                dblAnim.Duration = new Duration(TimeSpan.FromSeconds(4));

                // Set the start value and end value. 
                dblAnim.From = 0;
                dblAnim.To = 360;

                // Now, create a RotateTransform object, and set 
                // it to the RenderTransform property of our
                // button
                RotateTransform rt = new RotateTransform();
                btnSpinner.RenderTransform = rt;

                // Now, animation the RotateTransform object. 
                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
            }
        }
        #endregion

        #region Click handler
        private void btnSpinner_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = 1.0;
            dblAnim.To = 0.0;
            
            // Reverse when done.
            dblAnim.AutoReverse = true;

            // Loop forever.
            dblAnim.RepeatBehavior = RepeatBehavior.Forever;
            btnSpinner.BeginAnimation(Button.OpacityProperty, dblAnim);
        }
        #endregion
    }
}