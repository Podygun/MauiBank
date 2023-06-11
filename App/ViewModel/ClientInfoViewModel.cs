
using Android.Locations;

namespace MauiBank.ViewModel;

public partial class ClientInfoViewModel : BaseViewModel, IQueryAttributable
{

	[ObservableProperty]
	UserData userData;


	[ObservableProperty]
	public bool isVisibleButton = false;

	[ObservableProperty]
	public bool isVisibleFingerPrint;

	private bool IsFingerPrint;
	private bool IsNewClient = false;

	[ObservableProperty]
	Color bgColorFingerPrint;

	public ClientInfoViewModel()
    {		
		if (!(bool)CacheService.GetValue("AvailabilityFP"))
			IsVisibleFingerPrint = false;		
		else
			IsVisibleFingerPrint = true;
		IsFingerPrint = (bool?)CacheService.GetValue("IsFingerPrint") ?? false;
		if (!IsFingerPrint)
		{
			App.Current.Resources.TryGetValue("Primary", out object lightColor);
			bgColorFingerPrint = (Color)lightColor;
		}
		else
		{
			App.Current.Resources.TryGetValue("Tertiary", out object darkColor);
			bgColorFingerPrint = (Color)darkColor;
		}

	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		UserData = query["UserData"] as UserData;
		if(UserData == null)
		{
			UserData = new();
			IsNewClient = true;

        }
		
	}



	[RelayCommand]
	public async Task SaveChanges()
	{
		if (Busy) return;
		try
		{
            Busy = true;
			Client client;

            if (IsNewClient)
			{
				client = new Client
				{
					first_name = UserData.first_name,
					second_name = UserData.second_name,
					last_name = UserData.last_name,
					email = UserData.email,
					phone = UserData.phone,
					user_account_id = (int)CacheService.GetValue("UserId"),
					gender = "empty"
				};
			}
			else
			{

				client = new Client
				{
					id = UserData.id,
					first_name = UserData.first_name,
					second_name = UserData.second_name,
					last_name = UserData.last_name,
					email = UserData.email,
					phone = UserData.phone,
                    user_account_id = (int)CacheService.GetValue("UserId"),
                    gender = "empty"

				};
			}

			var result = await ApiClient<Client>.PostAsync(Routes.updateClientUri + UserData.id, client);
			if(result.IsSuccessStatusCode) 
			{
				CacheService.SetValue("IsFingerPrint", IsFingerPrint, TimeSpan.FromDays(30));
				await Shell.Current.DisplayAlert("Успешно", "Данные были обновлены", "OK");
				await Shell.Current.GoToAsync("main");
			}
		}
		catch (Exception ex)
		{
			await Shell.Current.DisplayAlert("Ошибка", "Что-то пошло не так", "OK");
			Trace.WriteLine(ex.Message);
		}
		finally
		{
			Busy = false;
		}
	}

	[RelayCommand]
	public void TapFingerPrint()
	{
		App.Current.Resources.TryGetValue("Primary", out object lightColor);
		App.Current.Resources.TryGetValue("Tertiary", out object darkColor);

		if (BgColorFingerPrint == darkColor)
		{
			BgColorFingerPrint = (Color)lightColor;
			CacheService.SetValue("IsFingerPrint", false, TimeSpan.FromDays(30));
			IsFingerPrint = false;
		}
		else if (BgColorFingerPrint == lightColor)
		{
			BgColorFingerPrint = (Color)darkColor;
			CacheService.SetValue("IsFingerPrint", true, TimeSpan.FromDays(30));
			IsFingerPrint = true;
		}

	}


}
