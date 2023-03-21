namespace MauiBank.ViewModel;

public partial class MyQRViewModel : BaseViewModel, IQueryAttributable
{

    [ObservableProperty]
    string ownerName;

	[ObservableProperty]
	string barcodeValue;

	[ObservableProperty]
	string qrcodeValue;


	public MyQRViewModel()
    {
		
    }

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		OwnerName = query["UserName"] as string;
		string cardNumber = query["CardNumber"] as string;
		//BarcodeValue = cardNumber;
		BarcodeValue = "5712067348295671";
		QrcodeValue = "card:" + cardNumber;
	}
}
