
using System.Diagnostics;

namespace MauiBank.ViewModel;

public partial class RegViewModel : BaseViewModel
{
	[ObservableProperty]
	public string login;

	[ObservableProperty]
	public string password;

	[ObservableProperty]
	public string confirmPassword;

	[ObservableProperty]
	public string textError;

	public RegViewModel()
	{
		
	}

	[RelayCommand]
	public async Task RegEntry()
	{
		

	}
}
