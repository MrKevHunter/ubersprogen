using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProcedureGenerator.Ui.Convertors
{
	public class BoolToVisibleConvertor : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool visible = (bool) value;
			return visible ? Visibility.Visible : Visibility.Hidden;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Visibility.Hidden;
		}
	}
}