﻿using System;
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

namespace RenderingWithVisuals
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

        #region Loaded handler
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const int TextFontSize = 30;

           // Make a System.Windows.Media.FormattedText object.
            FormattedText text = new FormattedText("Hello Visual Layer!",
                    new System.Globalization.CultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface(this.FontFamily, FontStyles.Italic, 
                        FontWeights.DemiBold, FontStretches.UltraExpanded),
                    TextFontSize,
                    Brushes.Green);

            // Create a DrawingVisual, and obtain the DrawingContext.
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Now, call any of the methods of DrawingContext to render data. 
                drawingContext.DrawRoundedRectangle(Brushes.Yellow, new Pen(Brushes.Black, 5),
                  new Rect(5, 5, 450, 100), 20, 20);
                drawingContext.DrawText(text, new Point(20, 20));
            }

            // Dynamically make a bitmap, using the data in the DrawingVisual.
            RenderTargetBitmap bmp = new RenderTargetBitmap(500, 100, 100, 90, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            
            // Set the source of the Image control!
            myImage.Source = bmp;
        }
        #endregion
    }
}
