namespace MauiBank.ViewModel;

public partial class AllCardsViewModel : BaseViewModel, IQueryAttributable
{
	[ObservableProperty]
	ObservableCollection<Card> cards;

    public AllCardsViewModel()
    {
        
    }

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		Cards = new ObservableCollection<Card>(query["Cards"] as ObservableCollection<Card>);
	}

	[RelayCommand]
	public async Task GoBack(Card selectedCard)
	{
		CacheService.SetValue("SelectedCard", selectedCard);
		await Shell.Current.GoToAsync("main");
	}
}
