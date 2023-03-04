namespace MauiBank;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("auth", typeof(AuthPage));
		Routing.RegisterRoute("main", typeof(MainPage));
		Routing.RegisterRoute("reg", typeof(RegPage));
		Routing.RegisterRoute("history", typeof(HistoryPage));
		Routing.RegisterRoute("carddetail", typeof(CardDetailPage));
		Routing.RegisterRoute("clientinfo", typeof(ClientInfoPage));
	}
}
