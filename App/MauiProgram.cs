
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace MauiBank;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseBarcodeReader()
			
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
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<AllCardsPage>();
		builder.Services.AddSingleton<RegPage>();
		builder.Services.AddSingleton<AuthPage>();
		//builder.Services.AddSingleton<UserDataPage>();
		builder.Services.AddTransient<HistoryPage>();
		builder.Services.AddTransient<CardDetailPage>();
		builder.Services.AddTransient<ClientInfoPage>();
		builder.Services.AddTransient<PaymentPage>();
		builder.Services.AddTransient<CardTransferPage>();
		builder.Services.AddTransient<OrganisationTransferPage>();
		builder.Services.AddTransient<QRPage>();
		builder.Services.AddSingleton<MyQRPage>();
		builder.Services.AddTransient<ScanQRPage>();
		builder.Services.AddTransient<HistoryDetailPage>();
		builder.Services.AddTransient<OpenCardPage>();
		
		
		builder.Services.AddSingleton<CardsService>();
		builder.Services.AddSingleton<BankAccountService>();


		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<AllCardsViewModel>();
		builder.Services.AddSingleton<RegViewModel>();
		builder.Services.AddSingleton<AuthViewModel>();
		//builder.Services.AddSingleton<UserDataViewModel>();
		builder.Services.AddTransient<HistoryViewModel>();	
		builder.Services.AddTransient<CardDetailViewModel>();
		builder.Services.AddTransient<ClientInfoViewModel>();
		builder.Services.AddTransient<PaymentViewModel>();
		builder.Services.AddTransient<CardTransferViewModel>();
		builder.Services.AddTransient<OrganisationTransferViewModel>();
		builder.Services.AddTransient<QRViewModel>();
		builder.Services.AddSingleton<MyQRViewModel>();
		builder.Services.AddTransient<ScanQRViewModel>();
		builder.Services.AddTransient<HistoryDetailViewModel>();
		builder.Services.AddTransient<OpenCardViewModel>();


		return builder.Build();
	}
}
