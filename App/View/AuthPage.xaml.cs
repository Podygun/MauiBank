namespace MauiBank.View;

public partial class AuthPage : ContentPage
{
	public AuthPage(AuthViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}