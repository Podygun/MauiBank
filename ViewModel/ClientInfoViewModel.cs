
namespace MauiBank.ViewModel;

public partial class ClientInfoViewModel : BaseViewModel, IQueryAttributable
{
	int userId;

	[ObservableProperty]
	Client client;


	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		userId = (int)query["userId"];
		OnPropertyChanged();
		
		Load();

	}

	[RelayCommand]
	public async void Load()
	{
		string uri = Routes.getAllClientOnUserIdUri;
		uri = uri.Replace("{0}", userId.ToString());

		Client = await ApiClient<Client>.GetAsync(uri);

		OnPropertyChanged();
	}
}
