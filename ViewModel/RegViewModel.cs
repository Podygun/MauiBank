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
		TextError = string.Empty;
	}

#nullable enable
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

		string uriNewClient = Routes.postUserAccountUri;
		HttpResponseMessage? response = await ApiClient<Object>.PostAsync(uriNewClient, acc);
		Trace.WriteLine(response.IsSuccessStatusCode);
		if (response == null)			   TextError = "Что-то пошло не так";
		if (!response.IsSuccessStatusCode) TextError = "Неверные данные"; 

		//await Shell.Current.GoToAsync("main");

		

	}
}
