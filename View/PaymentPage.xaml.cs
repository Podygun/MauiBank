namespace MauiBank.View;

public partial class PaymentPage : ContentPage
{

	public PaymentPage(PaymentViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}
}