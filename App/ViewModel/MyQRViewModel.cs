namespace MauiBank.ViewModel;

public partial class MyQRViewModel : BaseViewModel
{

    [ObservableProperty]
    string ownerName;

	[ObservableProperty]
	string barcodeValue;

	[ObservableProperty]
	string qrcodeValue;


	public MyQRViewModel()
    {
		UserData data = CacheService.GetValue("UserData") as UserData;
		OwnerName = data.first_name + " " + data.last_name;
		string cardNumber = CacheService.GetValue("CardNumber") as string;

		BarcodeValue = cardNumber;
		QrcodeValue = "card:" + cardNumber;
	}

}
