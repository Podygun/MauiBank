namespace MauiBank.ViewModel;

public partial class ClientInfoViewModel : BaseViewModel, IQueryAttributable
{

	[ObservableProperty]
	UserData userData;

	[ObservableProperty]
	bool isVisibleButton = true;


	public ClientInfoViewModel()
    {

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
	{

		UserData = query["UserData"] as UserData;
		OnPropertyChanged();

	}


	[RelayCommand]
	public async Task SaveChanges()
	{
		OnPropertyChanged();
	}
}
