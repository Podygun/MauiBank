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
        FillCardTypes();
        FillValuteList();
    }

    [RelayCommand]
    async Task CreateCardAsync()
    {
        string cvv = _cardsService.GetCvv();
        CardDB newCard = new()
        {
            bank_account_id = 1
        };

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
				valute_id = SelectedValute.id,
				client_id = (int)CacheService.GetValue("ClientId")
			};
            var result = await _bankAccountService.Post(newBankAccount);
            if (result == null) return;
            //newBankAccount = await ApiClient<BankAccount>.GetAsync(Routes.getBankAccount)
			//result = await CreateCardAsync();
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
