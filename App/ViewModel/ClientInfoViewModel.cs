namespace MauiBank.ViewModel;

public partial class ClientInfoViewModel : BaseViewModel, IQueryAttributable
{

	[ObservableProperty]
	UserData userData;

	UserData oldUserData = new();

	[ObservableProperty]
	public bool isVisibleButton = false;


	public ClientInfoViewModel()
    {

	}

    public void ApplyQueryAttributes(IDictionary<string, object> query) => UserData = oldUserData = query["UserData"] as UserData;



	[RelayCommand]
	public async Task SaveChanges()
	{
		if (Busy) return;
		try
		{
			Busy = true;

			Client client = new Client
			{
				id = UserData.id,
				first_name = UserData.first_name,
				second_name = UserData.second_name,
				last_name = UserData.last_name,
				email = UserData.email,
				phone = UserData.phone,
				gender = "empty"

			};

			var result = ApiClient<Client>.PostAsync(Routes.updateClientUri + UserData.id, client, false);
			if(result.IsCompletedSuccessfully) 
			{
				await Shell.Current.DisplayAlert("Успешно", "Данные были обновлены", "OK");
				await Shell.Current.GoToAsync("main");
			}
		}
		catch (Exception ex)
		{
			Trace.WriteLine(ex.Message);
		}
		finally
		{
			Busy = false;
		}
	}

	
}
