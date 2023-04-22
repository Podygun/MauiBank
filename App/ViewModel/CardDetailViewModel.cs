using AndroidX.ConstraintLayout.Core.Parser;

namespace MauiBank.ViewModel;


public partial class CardDetailViewModel : BaseViewModel, IQueryAttributable
{
	[ObservableProperty]
	Card currentCard;

	[ObservableProperty]
	string name;

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		CurrentCard = query["Card"] as Card;
		UserData ud = CacheService.GetValue("UserData") as UserData;
		Name = ud.first_name + " " + ud.second_name;
	}

	#region CopyToClipboard

	[RelayCommand]
	private async void CopyNumber()  {
		await ShowPopUp("Номер карты скопирован");
		await Clipboard.Default.SetTextAsync(CurrentCard.number);
	}

	[RelayCommand]
	private async void CopyCvv()
	{
		await ShowPopUp("Код скопирован");
		await Clipboard.Default.SetTextAsync(CurrentCard.cvv);
	}

	[RelayCommand]
	private async void CopyName()
	{
		await ShowPopUp("Имя и фамилия скопированы");
		await Clipboard.Default.SetTextAsync(Name);
	}

	#endregion

	private async Task ShowPopUp(string message) =>
	
		await Shell.Current.DisplayAlert("",message,"OK");
	
}
