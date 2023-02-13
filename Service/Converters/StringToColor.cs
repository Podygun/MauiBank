using Microsoft.Maui.Graphics.Converters;
using System.Globalization;

namespace MauiBank.Service.Converters;

public class StringToColor : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null) value = "#FCBE0B";
		ColorTypeConverter converter = new ColorTypeConverter();
		Color color = (Color)(converter.ConvertFromInvariantString((string)value));
		return color;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		string colorString = "White"; //TODO

		return colorString;
	}
}
