namespace MauiBank.ViewModel;

public partial class CardTransferViewModel : BaseViewModel
{
	[ObservableProperty]
	string cardNumber;

	[RelayCommand]
	public async Task Transfer()
	{

	}
}
