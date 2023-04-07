namespace MauiBank.View;

public partial class HistoryDetailPage : ContentPage
{
	public HistoryDetailPage(HistoryDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}

