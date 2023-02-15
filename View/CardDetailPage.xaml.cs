namespace MauiBank.View;

public partial class CardDetailPage : ContentPage
{
	public CardDetailPage(CardDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}