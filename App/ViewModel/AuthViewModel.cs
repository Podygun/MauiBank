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

		//TODO
		var navigationParameter = new Dictionary<string, object>
		{
			{ "UserId", 1 }
		};
		Shell.Current.GoToAsync("main", navigationParameter);
		Login = "1";
		Password = "1";
		//TryEntry();
	}
#nullable enable
	[RelayCommand]
	public async Task TryEntry()
	{
		
		if (Busy) return;
		Busy = true;
		TextError = String.Empty;
		Password = Password.Trim();
		Login = Login.Trim();

		int userId = -1;
		if (!String.IsNullOrWhiteSpace(Login) || !String.IsNullOrWhiteSpace(Password))
		{

			string uri = Routes.getUserIdUri
				.Replace(@"{0}", Login)
				.Replace(@"{1}", Password);

			Id? _id = await ApiClient<Id>.GetAsync(uri);
			
			if(_id == null) {
				TextError = "Что-то пошло не так";
				return;
			}
			userId = _id.id;

		}
		else
		{
			TextError = "Заполните поля";
			Busy = false;
			return;
		}
		if (userId == -1) { TextError = "Проверьте введенные данные"; Busy = false; return; }

		var navigationParameter = new Dictionary<string, object>
		{
			{ "UserId", userId }
		};
		Busy = false;
		await Shell.Current.GoToAsync("main", navigationParameter);
	}

	[RelayCommand]
	public void OpenRegPage()
	{
		TextError = String.Empty;
		Shell.Current.GoToAsync("reg");
	}
}
