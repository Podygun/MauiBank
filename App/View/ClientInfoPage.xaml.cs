namespace MauiBank.View;

public partial class ClientInfoPage : ContentPage
{
	ClientInfoViewModel viewmodel;

	public ClientInfoPage(ClientInfoViewModel vm)
	{
		InitializeComponent();
		BindingContext = viewmodel = vm;
	}

	private void Entry_TextChanged(object sender, TextChangedEventArgs e)
	{ 

		viewmodel.IsVisibleButton = true; 
	}
    
}