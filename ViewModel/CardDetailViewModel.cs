namespace MauiBank.ViewModel;


public partial class CardDetailViewModel : BaseViewModel, IQueryAttributable
{


	[ObservableProperty]
	Card currentCard;


	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{ 
		CurrentCard = query["Card"] as Card;
		OnPropertyChanged();

		
	}
}
