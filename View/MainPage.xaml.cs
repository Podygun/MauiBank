namespace MauiBank.View;


public partial class MainPage : ContentPage
{
	MainViewModel viewmodel;
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = viewmodel = vm;
	}

	private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		viewmodel.CardDetailCommand.Execute(null);
    }
	 


	private async void TapHistory(object sender, TappedEventArgs e)
	{
		await test.ScaleTo(0.95, 50);
		await test.ScaleTo(1, 200);
	}

	private async void TapQR(object sender, TappedEventArgs e)
	{
		await QR.ScaleTo(0.95, 50);
		await QR.ScaleTo(1, 200);
	}
}

