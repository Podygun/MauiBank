namespace MauiBank.View;

public partial class OpenCardPage : ContentPage
{
	public OpenCardPage(OpenCardViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}