
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
		TextError= string.Empty;
	}

	[RelayCommand]
	public async Task RegEntry()
	{
		TextError = string.Empty;
		Password = Password.Trim();
		Login = Login.Trim();
		ConfirmPassword = ConfirmPassword.Trim();

		
		if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(ConfirmPassword)) 
		{
			TextError = "Заполнены не все поля";
			return;							   
		}
		if (Password != ConfirmPassword)
		{
			TextError = "Пароли не совпадают";
			return;
		}


		string Salt = "test";

		UserAccount acc = new()
		{
			login = Login,
			password = Password,
			salt = Salt
		};
		try
		{
			await ApiClient.SaveUserAsync(acc);
			if (await ApiClient.GetUserId(Login, Password) != -1)
				await Shell.Current.GoToAsync("main");
			else TextError= "Неверные данные";
		}
		catch (Exception)
		{

			TextError = "Что-то пошло не так";
		}
		
	}
}
