namespace MauiBank.ViewModel;

public partial class QRViewModel : BaseViewModel
{
    public QRViewModel()
    {
		
	}

	[RelayCommand]
	public async Task GoToMyQrCode() => await Shell.Current.GoToAsync("myQR");

	[RelayCommand]
	public async Task GoToScanQrCode() => await Shell.Current.GoToAsync("scanQR");

}
