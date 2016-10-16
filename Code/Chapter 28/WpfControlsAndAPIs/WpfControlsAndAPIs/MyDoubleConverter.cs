using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfControlsAndAPIs
{
	class MyDoubleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
								System.Globalization.CultureInfo culture)
		{
			// Convert the double to an int.
			double v = (double)value;
			return (int)v;
		}
		
		public object ConvertBack(object value, Type targetType, object parameter,
									System.Globalization.CultureInfo culture)
		{
			// We won't worry about "two way" bindings
			// here, so just return the value.
			return value;
		}
	}
}