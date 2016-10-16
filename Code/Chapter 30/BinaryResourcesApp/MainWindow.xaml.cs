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

namespace BinaryResourcesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // An List of BitmapImage files.
        List<BitmapImage> images = new List<BitmapImage>();

        // Current position in the list.
        private int currImage = 0;
        private const int MAX_IMAGES = 2;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //string path = Environment.CurrentDirectory;

                // Load these images when the window loads. 
                //images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\Deer.jpg", path))));
                //images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\Dogs.jpg", path))));
                //images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\Welcome.jpg", path))));

                images.Add(new BitmapImage(new Uri(@"/Images/Deer.jpg", UriKind.Relative)));
                images.Add(new BitmapImage(new Uri(@"/Images/Dogs.jpg", UriKind.Relative)));
                images.Add(new BitmapImage(new Uri(@"/Images/Welcome.jpg", UriKind.Relative)));

                imageHolder.Source = images[currImage];                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {                   
            if (--currImage < 0)
                currImage = MAX_IMAGES;           
            imageHolder.Source = images[currImage];
        }

        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            if (++currImage > MAX_IMAGES)
                currImage = 0;         
            imageHolder.Source = images[currImage];
        }
    }
}
