namespace MauiBank.View;

public partial class MyQRPage : ContentPage
{
	public MyQRPage(MyQRViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}