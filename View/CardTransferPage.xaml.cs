namespace MauiBank.View;

public partial class CardTransferPage : ContentPage
{
	public CardTransferPage(CardTransferViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}