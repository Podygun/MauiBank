using MauiBank.Model;

namespace MauiBank.ViewModel;


public partial class NewBankAccountViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<Valute> valuteCollection = new();

	public NewBankAccountViewModel()
	{
		//var tempValutes = ApiClient.GetValutesAsync();
	}
}
