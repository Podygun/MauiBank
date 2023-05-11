using Microsoft.Maui.Storage;
using System.Collections.Specialized;

namespace MauiBank.ViewModel;


public partial class MainViewModel : BaseViewModel
{
	[ObservableProperty]
	bool isScrollable = true;

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
		Load();
		if (Cards.Count == 1) IsScrollable = false;
		else IsScrollable = true;
	}


	private void SetEmptyCard()
	{
		Card emptyCard = new()
		{
			number="",
			type_name = "Открыть карту",
			date_end = DateOnly.FromDateTime(DateTime.Now),
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
			CacheService.GetOrCreateCacheValue("UserData", TimeSpan.FromMinutes(60), userData);
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

			for (int i = 0, j = 0; j < tempCards.Count; i++, j++)
			{
				if (i == Colors.Length) i = 0;
				tempCards[j].color = Colors[i];
			}
			Cards = new ObservableCollection<Card>(tempCards);

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
		if (CacheService.GetValue("IsUpdateCards") as string == "1")
		{
			if (Cards?.Count > 0)
				Cards?.Clear();
			await FillCardsAsync();
			CacheService.SetValue("IsUpdateCards", "0");
			return;
		}


		if (!flagFirstEntry) return;

		string idd = CacheService.GetValue("UserId").ToString();
		Id? clientId = await ApiClient<Id?>.GetAsync(Routes.getClientOnUserIdUri.Replace(@"{0}", idd));

		if (clientId == null)
		{
			SetEmptyCard();
			Trace.WriteLine("setted empty card");
			return;
		}
		await FillCardsAsync();
		await GetUserData();
		

		flagFirstEntry = false;
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
	public async Task GoToAuth() => await Shell.Current.GoToAsync("auth");

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
	

	readonly static string[] Colors = new string[]
	{
		"#8916FF",
		"#ECC200",
		"#424874"
	};



}
