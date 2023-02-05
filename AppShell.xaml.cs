namespace MauiBank;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("auth", typeof(AuthPage));
	}
}
