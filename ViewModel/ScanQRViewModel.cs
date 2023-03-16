namespace MauiBank.ViewModel;

public partial class ScanQRViewModel : BaseViewModel
{

    public ScanQRViewModel()
    {
        
    }

    //TODO dictionary 
    [RelayCommand]
    public async Task GoToPayment() => await Shell.Current.GoToAsync("payment");
}
