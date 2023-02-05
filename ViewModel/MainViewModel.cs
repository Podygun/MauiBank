using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiBank.ViewModel;

public partial class MainViewModel : BaseViewModel
{

	CardsService cardsService;
	public ObservableCollection<Card> cards { get; set; } = new();

	public MainViewModel(CardsService cs)
	{

		this.cardsService = cs;
		GetCards();
	}

	[RelayCommand]
	async void GetCards()
	{
		if (Busy) return;
		try
		{
			Busy = true;
			var tempCards = await cardsService.GetCardsAsync("13");
			if (cards.Count != 0)
				cards.Clear();
			foreach (var card in tempCards) {
				
				cards.Add(card); 
			}
		}
		catch(Exception ex)
		{
			await Shell.Current.DisplayAlert("Error", $"Unable to get cards: {ex.Message}", "OK");
		}
		finally
		{
			Busy = false;
		}
	}

	[RelayCommand]
	void GetFakeCards()
	{
		var tempCards = new ObservableCollection<Card>
		{
			new Card{ Number="12345678912346729", Cvv="123", Id="1", Type="VISA", DateEnd="12.12.23", Color="#8916FF", Balance="57813.53"},
			new Card{ Number="1234567893862", Cvv="123", Id="2", Type="МИР", DateEnd="12.12.23", Color="#ECC200", Balance="0.00"},
			new Card{ Number="1234567891234562907", Cvv="123", Id="3", Type="MAESTRO", DateEnd="12.12.23", Color="#424874", Balance="6928544.32"}
		};

		foreach (var card in tempCards)
		{

			cards.Add(card);
		}


		cards = tempCards;
	}

	[RelayCommand]
	void GoToAuth()
	{
		Shell.Current.GoToAsync("//MainPage/auth");
	}
}
