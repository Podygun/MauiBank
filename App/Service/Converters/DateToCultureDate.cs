using System.Globalization;

namespace MauiBank.Service.Converters;

public class DateToCultureDate : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		DateOnly sendDate = (DateOnly)value;
		DateOnly theDate = DateOnly.MinValue;

		if(sendDate.ToString().Contains('/'))
			theDate = DateOnly.ParseExact(sendDate.ToString(),"M/dd/yyyy" ,CultureInfo.InvariantCulture);
		else if (sendDate.ToString().Contains('.'))
			theDate = DateOnly.ParseExact(sendDate.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

		return theDate.ToString("ddd, d MMMM", CultureInfo.GetCultureInfo("ru-RU"));
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return String.Empty;
	}
}
