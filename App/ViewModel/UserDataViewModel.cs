using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiBank.ViewModel;

public partial class UserDataViewModel : BaseViewModel
{

	#region fields
	[ObservableProperty]
	string firstName;

	[ObservableProperty]
	string secondName;

	[ObservableProperty]
	string thirdName;

	[ObservableProperty]
	string gender;

	[ObservableProperty]
	string email;

	[ObservableProperty]
	string phone; 
	#endregion

	public UserDataViewModel()
	{

	}

	[RelayCommand]
	void Accept()
	{
		
	}
}
