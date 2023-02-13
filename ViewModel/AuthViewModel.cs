using CommunityToolkit.Mvvm.ComponentModel;
using MauiBank.HTTP;
using System.Diagnostics;


namespace MauiBank.ViewModel;

public partial class AuthViewModel : BaseViewModel
{
	[ObservableProperty]
	public string login;

	[ObservableProperty]
	public string password;

	[ObservableProperty]
	public string textError;

	public AuthViewModel()
	{

	}

	[RelayCommand]
	public async Task TryEntry()
	{
		int userId;
		if (!String.IsNullOrEmpty(Login) || !String.IsNullOrEmpty(Password))
			userId = await ApiClient.GetUserId(Login, Password);

		if (userId == -1) TextError = "Проверьте введенные данные";

		//null if ERROR
		//"-1" if not found
		Trace.WriteLine(userId);

	}

	[RelayCommand]
	public void OpenRegPage()
	{
		Shell.Current.GoToAsync("//MainPage/auth/reg");
	}
}
