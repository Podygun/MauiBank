using CommunityToolkit.Mvvm.ComponentModel;


namespace MauiBank.ViewModel;

public partial class BaseViewModel : ObservableObject
{
	[ObservableProperty]
	string title;

	[ObservableProperty]
	bool busy;

	public BaseViewModel()
	{

	}

	public bool isNotBusy() => !Busy;
}
