namespace MauiBank.View;

public partial class RegPage : ContentPage
{
	public RegPage(RegViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	
}