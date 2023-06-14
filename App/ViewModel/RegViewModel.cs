using Newtonsoft.Json;

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
		Password = Password?.Trim();
		Login = Login?.Trim();
		ConfirmPassword = ConfirmPassword?.Trim();


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


		string uriNewAcc = Routes.postUserAccountUri;

		HttpResponseMessage? response = await ApiClient<object>.PostAsync(uriNewAcc, acc);
        if (response == null) { TextError = "Что-то пошло не так"; return; }

        acc = JsonConvert.DeserializeObject<UserAccount>(response.Content.ReadAsStringAsync().Result);

		Client client = new()
		{
			first_name = "Имя",
			second_name = "Фамилия",
			last_name ="Отчество",
			gender="empty",
			email = "mail@mail",
			phone = "+7900",
			user_account_id = acc.id
		};

        string uriNewClient = Routes.updateClientUri;
        HttpResponseMessage? response2 = await ApiClient<Client>.PostAsync(uriNewClient, client);
        if (response2 == null) { TextError = "Что-то пошло не так"; return; }


        if (response2.IsSuccessStatusCode)
		{
			await Shell.Current.GoToAsync("auth", true);
		}



	}
}
