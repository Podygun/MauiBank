
using Microsoft.Extensions.Logging;

namespace MauiBank;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Raleway-Regular.ttf", "BaseFontRegular");
				fonts.AddFont("Raleway-Light.ttf", "BaseFontLight");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<CardsService>();
		builder.Services.AddSingleton<MainViewModel>();

		return builder.Build();
	}
}
