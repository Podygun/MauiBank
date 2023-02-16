
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
				fonts.AddFont("Inter-Thin.ttf", "Thin");
				fonts.AddFont("Inter-ExtraLight.ttf", "ExtraLight");
				fonts.AddFont("Inter-Light.ttf", "Light");
				fonts.AddFont("Inter-Regular.ttf", "Regular");
				fonts.AddFont("Inter-Medium.ttf", "Medium");
				fonts.AddFont("Inter-SemiBold.ttf", "SemiBold");
				fonts.AddFont("Inter-Bold.ttf", "Bold");
				fonts.AddFont("Inter-ExtraBold.ttf", "ExtraBold");
				fonts.AddFont("Inter-Black.ttf", "Black");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<RegPage>();
		builder.Services.AddSingleton<AuthPage>();
		builder.Services.AddSingleton<UserDataPage>();
		builder.Services.AddSingleton<CardDetailPage>();

		builder.Services.AddSingleton<CardsService>();

		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<RegViewModel>();
		builder.Services.AddSingleton<AuthViewModel>();
		builder.Services.AddSingleton<UserDataViewModel>();
		builder.Services.AddSingleton<CardDetailViewModel>();
		

		return builder.Build();
	}
}
