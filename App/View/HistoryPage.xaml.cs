namespace MauiBank.View;

public partial class HistoryPage : ContentPage
{
	public HistoryPage(HistoryViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}