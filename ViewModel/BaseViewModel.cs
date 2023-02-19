namespace MauiBank.ViewModel;


public partial class BaseViewModel : ObservableObject
{
	[ObservableProperty]
	string title;

	[ObservableProperty]
	bool busy;

	public bool isNotBusy() => !Busy;
}
