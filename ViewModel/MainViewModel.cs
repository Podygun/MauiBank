using MauiBank.Service;

namespace MauiBank.ViewModel;


public partial class MainViewModel : BaseViewModel, IQueryAttributable
{

	MainService mainService;
	public ObservableCollection<Card> cards { get; set; } = new();

	private int currentUserId { get; set; }

	[ObservableProperty]
	Card selectedCard;

	public MainViewModel(MainService ms)
	{
		mainService = ms;	
	}

	[RelayCommand]
	static async void GoToAuth()
	{
		await Shell.Current.GoToAsync("auth");
	}

	private void SetEmptyCard()
	{
		Card emptyCard = new()
		{
			Type = "Открыть карту"
		};
		cards.Clear();
		cards.Add(emptyCard);
	}

	[RelayCommand]
	async void GetUserData()
	{
		try
		{
			Busy = true;
			List<Card> tempCards = await mainService.GetCardsAsync(currentUserId);
			foreach (var card in tempCards)
			{
				cards.Add(card);
			}

		}
		catch (Exception ex)
		{
			await Shell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
		}
		finally
		{
			Busy = false;
		}
	}

	[RelayCommand]
	async void CardDetail()
	{
		var navigationParameter = new Dictionary<string, object>
		{
			{ "Card", SelectedCard }
		};
		await Shell.Current.GoToAsync("carddetail", navigationParameter);
	}


	//Принятие id с форм авторизации
	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		currentUserId = (int)query["UserId"];
		OnPropertyChanged();
		Load();
		
	}

	[RelayCommand]
	public async Task Load()
	{
		bool isClientExists = await ApiClient<bool>.IsClientExist(currentUserId);

		if (!isClientExists)
		{
			SetEmptyCard();
			Trace.WriteLine("setted empty card");
			return;
		}
		GetUserData();
		Trace.WriteLine("getted user data");
	}

	[RelayCommand]
	public async void GoToClientInfo()
	{
		var navigationParameter = new Dictionary<string, object>
		{
			{ "userId", 1 }
		};
		await Shell.Current.GoToAsync("clientinfo", navigationParameter);
	}


}
