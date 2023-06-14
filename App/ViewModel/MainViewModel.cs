namespace MauiBank.ViewModel;


public partial class MainViewModel : BaseViewModel
{

	[ObservableProperty]
	ObservableCollection<Card> cards = new();
	
	//TODO
	//не меняется qrкод при выборе другой кары

	private UserData userData { get; set; }

	[ObservableProperty]
	bool cardsBtnEnable = true;

	[ObservableProperty]
	Card selectedCard;

	public MainViewModel()
	{
		try
		{
			string? prevPage = CacheService.GetValue("PrevPage") as string;
			if (prevPage == "allcards")
			{
				Card? chosenCard = CacheService.GetValue("SelectedCard") as Card;
				SelectedCard ??= chosenCard;

                CacheService.SetValue("bank_account_id", SelectedCard.bank_account_id);
				Cards = CacheService.GetValue("Cards") as ObservableCollection<Card>;
				userData = CacheService.GetValue("UserData") as UserData;
				CacheService.SetValue("PrevPage", "null");

            }
			else
			{
				Load();				
			}
		}
		catch
		{
			
		}
		
	}

	private void SetEmptyCard()
	{
		Card emptyCard = new()
		{
			number="",
			type_name = "Открыть карту",
			date_end = DateOnly.FromDateTime(DateTime.Now),
		};
		SelectedCard = emptyCard;
		CardsBtnEnable = false;
	}

	private async Task GetUserData()
	{
		if (Busy) return;
		try
		{
			Busy = true;
			var tempUserData = await ApiClient<List<UserData>>.GetAsync(Routes.getUserDataUri.Replace("{0}", CacheService.GetValue("UserId").ToString()));			
			userData = tempUserData[0];
			CacheService.SetValue("UserData", userData, TimeSpan.FromMinutes(60));
			CacheService.SetValue("ClientId", userData.id);
			Trace.WriteLine("SUCCESS USERDATA");
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
	private async Task FillCardsAsync()
	{
		if (Busy) return;
		try
		{
			Busy = true;			
			var tempCards = await ApiClient<List<Card>>.GetAsync(Routes.getCardsUriOnUserId + CacheService.GetValue("UserId"));
			Cards = new ObservableCollection<Card>(tempCards);
			CacheService.SetValue("Cards", Cards);
            Trace.WriteLine("SUCCESS CARDS");
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

	[RelayCommand]
	public async Task Load()
	{
		//After transaction
		if (CacheService.GetValue("IsUpdateCards") as string == "1")
		{
			if (Cards?.Count > 0) Cards?.Clear();
			await FillCardsAsync();
			CacheService.SetValue("IsUpdateCards", "0");
			return;
		}

		string idd = CacheService.GetValue("UserId").ToString();
		Id? clientId = await ApiClient<Id?>.GetAsync(Routes.getClientOnUserIdUri.Replace(@"{0}", idd));

		//If client doesnt have cards
		if (clientId == null)
		{
			SetEmptyCard();
			return;
		}		
		await FillCardsAsync();
		await GetUserData();
		SelectedCard = Cards[0];
		CacheService.SetValue("bank_account_id", SelectedCard.bank_account_id);
	}

	[RelayCommand]
	public async Task GoToClientInfo() =>
		await Shell.Current.GoToAsync("clientinfo",true, 
		new Dictionary<string, object>
		{
			{"UserData", userData }
		});

	[RelayCommand]
	public async Task GoToAuth() => await Shell.Current.GoToAsync("auth", true);

	[RelayCommand]
	public async Task GoToHistory() => await Shell.Current.GoToAsync("history");

	[RelayCommand]
	public async Task GoToOrganisation() => await Shell.Current.GoToAsync("orgtransfer");

	[RelayCommand]
	public async Task GoToNewCard() => await Shell.Current.GoToAsync(nameof(OpenCardPage));

	[RelayCommand]
	public async Task GoToPayment() =>
		await Shell.Current.GoToAsync("payment",
		true, new Dictionary<string, object>
		{
			{ "Favour", new Favour{ Id=-1, Name=""} }
		});

	[RelayCommand]
	public async Task GoToCardDetail()
	{
		if(SelectedCard.number == "")
		{
			await Shell.Current.GoToAsync(nameof(OpenCardPage));
		}

		await Shell.Current.GoToAsync("carddetail", true,
		new Dictionary<string, object>
			{
				{ "Card", SelectedCard }
			});
	}

	[RelayCommand]
	public async Task GoToQR() {
		CacheService.SetValue("CardNumber", SelectedCard.number);
		await Shell.Current.GoToAsync("QR", true);
	}

	[RelayCommand]
	public async Task ShowAllCards()
	{
		await Shell.Current.GoToAsync("allcards", true, new Dictionary<string, object>
		{
			{"Cards", Cards }
		});
	}

}
