
namespace MauiBank.ViewModel;


public partial class MainViewModel : BaseViewModel, IQueryAttributable
{

	[ObservableProperty]
	ObservableCollection<Card> cards = new();

	private UserData userData { get; set; }

	
	private Card selectedCard;
	public Card SelectedCard
	{
		get => selectedCard;
		set
		{
			SetProperty(ref selectedCard, value);
			Preferences.Default.Set("bank_account_id", SelectedCard.bank_account_id);
		}
	}

	private bool flagFirstEntry = true;

	public MainViewModel()
	{

	}


	private void SetEmptyCard()
	{
		Card emptyCard = new()
		{
			type_name = "Открыть карту"
		};
		Cards.Clear();
		Cards.Add(emptyCard);
	}

	private async Task GetUserData()
	{
		if (Busy) return;
		try
		{
			Busy = true;
			var tempUserData = await ApiClient<List<UserData>>.GetAsync(Routes.getUserDataUri.Replace("{0}", Preferences.Default.Get("UserId", -1).ToString()));
			userData = tempUserData[0];
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

	private async Task FillCardsAsync()
	{
		if (Busy) return;
		try
		{
			Busy = true;
			
			var tempCards = await ApiClient<List<Card>>.GetAsync(Routes.getCardsUriOnUserId + Preferences.Default.Get("UserId",-1));

			for (int i = 0, j = 0; j < tempCards.Count; i++, j++)
			{
				if (i == Colors.Length) i = 0;
				tempCards[j].color = Colors[i];
			}

			foreach (var card in tempCards)
			{
				Cards.Add(card);
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

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{

		if (Preferences.Default.Get("IsUpdateCards", 0) != 0)
		{
			if (Cards?.Count > 0)
				Cards?.Clear();
			FillCardsAsync();
			Preferences.Default.Remove("IsUpdateCards");
			return;
		} 
			
		
		if (!flagFirstEntry) return;

		try
		{
			Preferences.Default.Set("UserId", (int)query["UserId"]);
		}
		catch { }

		Load();

	}

	[RelayCommand]
	public async Task Load()
	{
		bool isClientExists = await ApiClient<bool>.IsClientExist(Preferences.Default.Get("UserId", -1));

		if (!isClientExists)
		{
			SetEmptyCard();
			Trace.WriteLine("setted empty card");
			return;
		}
		await FillCardsAsync();
		Trace.WriteLine("SUCCESS CARDS");

		await GetUserData();
		Trace.WriteLine("SUCCESS USERDATA");

		flagFirstEntry = false;
		Preferences.Default.Set("bank_account_id", SelectedCard.bank_account_id);
	}

	[RelayCommand]
	public async Task GoToClientInfo() =>
		await Shell.Current.GoToAsync("clientinfo",true, 
		new Dictionary<string, object>
		{
			{"UserData", userData }
		});
	

	[RelayCommand]
	public async Task GoToAuth() => await Shell.Current.GoToAsync("auth");

	[RelayCommand]
	public async Task GoToPayment() =>
		await Shell.Current.GoToAsync("payment",
		true, new Dictionary<string, object>
		{
			{ "Favour", new Favour{ Id=-1, Name=""} }
		});


	[RelayCommand]
	public async Task GoToCardDetail() => await Shell.Current.GoToAsync("carddetail", true,
		new Dictionary<string, object>
			{
				{ "Card", SelectedCard }
			});


	readonly static string[] Colors = new string[]
	{
		"#8916FF",
		"#ECC200",
		"#424874"
	};


	

}
