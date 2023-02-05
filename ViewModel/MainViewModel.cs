namespace MauiBank.ViewModel;

public partial class MainViewModel : BaseViewModel
{
	CardsService cardsService;
	public ObservableCollection<Card> cards { get; set; } = new();

	public MainViewModel(CardsService cs)
	{
		Title = "Карты клиента";
		this.cardsService = cs;
	}

	[RelayCommand]
	void GetCards()
	{
		if (Busy) return;
		try
		{
			Busy = true;
			var tempCards = cardsService.GetCardsAsync("13");
			if (cards.Count != 0)
				cards.Clear();
			cards = tempCards;
		}
		catch(Exception ex)
		{
			Shell.Current.DisplayAlert("Error", $"Unable to get cards: {ex.Message}", "OK");
		}
		finally
		{
			Busy = false;
		}
	}
}
