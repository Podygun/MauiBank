
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
		if(String.IsNullOrWhiteSpace(Login) ||
		   String.IsNullOrWhiteSpace(Password) ||
		   String.IsNullOrWhiteSpace(ConfirmPassword)) 
		{
			//bad	
			return;							   
		}

		string Salt = "test";
		UserAccount acc = new()
		{
			login = Login,
			password = Password,
			salt = Salt
		};
		await ApiClient.SaveUserAsync(acc);

	}
}
