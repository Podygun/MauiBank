namespace MauiBank.ViewModel;

public partial class OpenCardViewModel : BaseViewModel
{
    private CardsService _cardsService = new();
    private BankAccountService _bankAccountService = new();

    [ObservableProperty]
    ObservableCollection<Valute> valuteList;

	[ObservableProperty]
	Valute selectedValute;

	[ObservableProperty]
	string dateEnd;
    DateOnly DateEndDate;

	[ObservableProperty]
	ObservableCollection<CardType> cardTypes;

    [ObservableProperty]
    CardType selectedCardType;

    [ObservableProperty]
    Card newCard = new();

    [ObservableProperty]
    string textError;

	public OpenCardViewModel(CardsService cardsService, BankAccountService bankAccountService)
    {
        _cardsService = cardsService;
        _bankAccountService = bankAccountService;
		DateEndDate = DateOnly.FromDateTime(DateTime.Now).AddYears(4);
        DateEnd = DateEndDate.ToString().Replace('/','.');
        FillCardTypes();
        //FillValuteList();
    }

    [RelayCommand]
    async Task CreateCardAsync()
    {
        if (Busy) return;
        try
        {
            Busy = true;
			string cvv = _cardsService.GetCvv();
			//var newBankAccId = await ApiClient<List<Card>>.GetAsync(Routes.getCardsUriOnUserId)
			CardDB newCard = new()
			{
				number = await _cardsService.GetNewCardNumber(SelectedCardType.prefix),
				bank_account_id = -1,
				cvv = cvv,
				date_end = DateEndDate,
				card_type_id = SelectedCardType.id

			};
			var result = await ApiClient<CardDB>.PostAsync(Routes.postCard, newCard);
			if (result == null) Trace.WriteLine("result from post card is null");
            await CreateBankAccAsync();
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
	async Task CreateBankAccAsync()
	{
		if (Busy) return;
        try
        {
			
			Busy = true;

			
			BankAccount newBankAccount = new()
			{
				balance = 0,
				valute_id = 1,
				client_id = (int)CacheService.GetValue("ClientId")
			};
            var result = await _bankAccountService.Post(newBankAccount);
            if (result == null) Trace.WriteLine("result from post bank_acc is null");
            
			
		}
        catch (Exception ex)
        {
            Trace.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, ex.StackTrace);
        }
        finally
        {
            Busy = false;
        }

	}


	async Task FillCardTypes() 
    {
		var tempCardTypes = await ApiClient<List<CardType>>.GetAsync(Routes.getCardTypes);
        CardTypes = new ObservableCollection<CardType>(tempCardTypes);
        SelectedCardType = CardTypes.FirstOrDefault();
	}

	async Task FillValuteList()
	{
		var tempValutes = await ApiClient<List<Valute>>.GetAsync(Routes.getValutesUri);
		ValuteList = new ObservableCollection<Valute>(tempValutes);
        SelectedValute = ValuteList.FirstOrDefault();
	}
}
