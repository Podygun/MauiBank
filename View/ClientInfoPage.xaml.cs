namespace MauiBank.View;

public partial class ClientInfoPage : ContentPage
{
	public ClientInfoPage(ClientInfoViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}

}