using MauiBank.ViewModel;

namespace MauiBank.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}

}

