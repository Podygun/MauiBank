using System.Globalization;

namespace MauiBank.Service.Converters;

public class DateToCultureDate : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		DateOnly sendDate = (DateOnly)value;
		var theDate = DateOnly.ParseExact(sendDate.ToString(),"M/dd/yyyy" ,CultureInfo.InvariantCulture);
		
		return theDate.ToString("m", CultureInfo.GetCultureInfo("ru-RU"));
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return String.Empty;
	}
}
