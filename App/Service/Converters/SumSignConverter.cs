using System.Globalization;

namespace MauiBank.Service.Converters;

    class SumSignConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		string str = value.ToString();
		if ((double)value >= 0)
		{
			return "+" + str;
		}

		return str;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}