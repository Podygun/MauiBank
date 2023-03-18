namespace MauiBank.View;

public partial class UserDataPage : ContentPage
{
	public UserDataPage(UserDataViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}