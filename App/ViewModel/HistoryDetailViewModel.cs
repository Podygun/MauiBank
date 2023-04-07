using Microsoft.Maui.Controls;

namespace MauiBank.ViewModel;


public partial class HistoryDetailViewModel : BaseViewModel, IQueryAttributable
{
	[ObservableProperty]
	public HistoryD history;

	[ObservableProperty]
	public string fullName;

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		History = query["history"] as HistoryD;
		FullName = History.Second_name + " " + History.First_name + " " + History.Last_name;
	}
}
