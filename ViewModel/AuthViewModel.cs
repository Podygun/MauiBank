
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;


namespace MauiBank.ViewModel;

public partial class AuthViewModel : BaseViewModel
{
	[ObservableProperty]
	public string login;

	[ObservableProperty]
	public string password;

	public AuthViewModel()
	{
		
	}

	[RelayCommand]
	public async Task TryEntry()
	{
		string? userId = await Database.GetUserId(Login, Password);
		//null if ERROR
		//"-1" if not found
		Trace.WriteLine(userId);

	}
}
