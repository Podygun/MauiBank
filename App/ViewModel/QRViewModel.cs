namespace MauiBank.ViewModel;

public partial class QRViewModel : BaseViewModel, IQueryAttributable
{

	private string UserName;
	private string CardNumber;

    public QRViewModel()
    {
		
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		UserName = query["UserName"] as string;
		CardNumber = query["CardNumber"] as string;
	}

	[RelayCommand]
	public async Task GoToMyQrCode() => await Shell.Current.GoToAsync("myQR", true, 
		new Dictionary<string, object>
		{
			{ "UserName", UserName },
			{ "CardNumber", CardNumber }
		});

	[RelayCommand]
	public async Task GoToScanQrCode() => await Shell.Current.GoToAsync("scanQR");

}
