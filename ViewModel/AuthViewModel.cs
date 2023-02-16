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
		TextError = String.Empty;
	}

	[RelayCommand]
	public async Task TryEntry()
	{
		TextError = String.Empty;
		Password = Password.Trim();
		Login = Login.Trim();

		int userId = -1;
		if (!String.IsNullOrWhiteSpace(Login) || !String.IsNullOrWhiteSpace(Password))
		{
			try
			{
				userId = await ApiClient.GetUserId(Login, Password);
			}
			catch (Exception ex)
			{
				TextError = ex.Message;
				return;
			}
			
		}
		else
		{
			TextError = "Заполните поля";
			return;
		}
		if (userId == -1) { TextError = "Проверьте введенные данные"; return; }
		await Shell.Current.GoToAsync("main");
	}

	[RelayCommand]
	public void OpenRegPage()
	{
		TextError = String.Empty;
		Shell.Current.GoToAsync("reg");
	}
}
