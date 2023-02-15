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


}

