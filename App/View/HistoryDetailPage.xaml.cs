namespace MauiBank.View;

[QueryProperty("selectedHistory", "historyId")]
public partial class HistoryDetailPage : ContentPage
{
	public HistoryDetailPage(HistoryDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	public string selectedHistory
	{
		set
		{
			// do smth with id
		}
		
	}
}

//