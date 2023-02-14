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
		int userId = -1;
		if (!String.IsNullOrEmpty(Login) || !String.IsNullOrEmpty(Password))
		{
			userId = await ApiClient.GetUserId(Login, Password);
		}
		else
		{
			TextError = "Заполните поля";
			return;
		}

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
