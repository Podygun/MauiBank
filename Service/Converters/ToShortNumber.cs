using Microsoft.Maui.Graphics.Converters;
using System.Globalization;

namespace MauiBank.Service.Converters;

public class ToShortNumber : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null) return "";
		string _value = (string)value;
		string tempStr = ". . . . ";	
		tempStr += _value.Substring(_value.Length - 4, 4);
		return tempStr;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return null;
	}
}
