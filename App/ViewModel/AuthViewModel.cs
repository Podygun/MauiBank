using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

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
		TryEntry();
		//ScanFinger();


	}

	[RelayCommand]
	public async Task TryEntry()
	{
		if (Busy) return;

		if(CacheService.GetValue("UserId") != null)
		{
			await ScanFinger();
			return;
		}
		
		//TODO убрать эти две строки
		CacheService.SetValue("UserId", 1, TimeSpan.FromHours(1));
		await Shell.Current.GoToAsync("main");
		
		try
		{
			Busy = true;
			TextError = String.Empty;
			Password = Password?.Trim();
			Login = Login?.Trim();

			if (!String.IsNullOrWhiteSpace(Login) || !String.IsNullOrWhiteSpace(Password))
			{
				string uri = Routes.getUserIdUri
					.Replace(@"{0}", Login)
					.Replace(@"{1}", Password);

				Id? _id = await ApiClient<Id>.GetAsync(uri) ?? new Id { id = -1 };
				
				if (_id.id == -1)
				{
					TextError = "Проверьте введенные данные";
					return;
				}
				CacheService.SetValue("UserId", _id.id, TimeSpan.FromHours(24));
				await Shell.Current.GoToAsync("main");
			}
			else
			{
				TextError = "Заполните поля";
				return;
			}
			
			
		}
		catch (Exception ex)
		{
			Trace.WriteLine(ex.Message);
			TextError = ex.Message;
		}
		finally
		{
			Busy = false;
		}
		
	}

	[RelayCommand]
	public async Task OpenRegPage()
	{
		TextError = String.Empty;
		await Shell.Current.GoToAsync("reg");
	}

	[RelayCommand]
	public async Task ScanFinger()
	{

		var availability = await CrossFingerprint.Current.IsAvailableAsync();

		if (!availability)
		{
			await Shell.Current.DisplayAlert("", "false IsAvailableAsync", "OK");
			return;
		}

		var request = new AuthenticationRequestConfiguration("Prove you have fingers!", "Because without it you can't have access");
		var result = await CrossFingerprint.Current.AuthenticateAsync(request);

		if (CrossFingerprint.Current.GetAvailabilityAsync() == null) await Shell.Current.DisplayAlert("", "null GetAvailabilityAsync", "OK");

		if (result.Authenticated)
		{
			await Shell.Current.GoToAsync("main");
		}
		else
		{
			await Shell.Current.DisplayAlert("Ошибка", "Неверный отпечаток", "OK");
		}

	}
}
