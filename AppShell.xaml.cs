namespace MauiBank;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("auth", typeof(AuthPage));
		Routing.RegisterRoute("auth/reg", typeof(RegPage));
		Routing.RegisterRoute("carddetail", typeof(CardDetailPage));
	}
}
