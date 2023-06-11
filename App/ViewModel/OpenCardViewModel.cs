using Newtonsoft.Json;
using Org.Json;

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
            var newBankAccId = await CreateBankAccAsync();
            Busy = true;
			string cvv = _cardsService.GetCvv();
            //var newBankAccId = await ApiClient<List<Card>>.GetAsync(Routes.getCardsUriOnUserId);
			CardDB newCard = new()
			{
				number = await _cardsService.GetNewCardNumber(SelectedCardType.prefix),
				bank_account_id = newBankAccId,
				cvv = cvv,
				date_end = DateEndDate,
				card_type_id = SelectedCardType.id

			};
			var result = await ApiClient<CardDB>.PostAsync(Routes.postCard, newCard);
			if (result == null) Trace.WriteLine("result from post card is null");
            if (result.IsSuccessStatusCode) await Shell.Current.GoToAsync("main");
            
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
	async Task<int> CreateBankAccAsync()
	{
		if (Busy) return -1;
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
            var bacc = JsonConvert.DeserializeObject<BankAccount>(result.Content.ReadAsStringAsync().Result);
            return bacc.id;
		}
        catch (Exception ex)
        {
            Trace.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, ex.StackTrace);
            return -2;
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
