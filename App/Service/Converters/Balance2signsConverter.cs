
using System.Globalization;

namespace MauiBank.Service.Converters;

public class Balance2signsConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double oldValue = (double)value;
		return Math.Round(oldValue, 2);
		
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return String.Empty;
	}
}
