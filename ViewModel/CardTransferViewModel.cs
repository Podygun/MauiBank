namespace MauiBank.ViewModel;

public partial class CardTransferViewModel : BaseViewModel
{
	[ObservableProperty]
	string cardNumber = string.Empty;

	[ObservableProperty]
	double sum = 0;

	[ObservableProperty]
	double fee = 0;

	[ObservableProperty]
	int favourId = 1;

    public CardTransferViewModel()
    {
		//TODO
        //if doesnt MAUIBANK set FEE = 0.1% from sum
    }


    [RelayCommand]
	public async Task Transfer()
	{
		if (Busy) return;
		try
		{
			Busy = true;
			PayCheck payCheck = new PayCheck
			{
				bank_account_id = Preferences.Default.Get("bank_account_id", -1),
				sum = Sum,
				fee = Fee,
				requisite_value = CardNumber,
				favour_id = FavourId
			};

			var result = await ApiClient<PayCheck>.PostAsync(Routes.setNewPaymentUri, payCheck);
			
			if (result.IsSuccessStatusCode)
			{
				await Shell.Current.DisplayAlert("Успешно", "Перевод выполнен", "OK");
				Preferences.Default.Set("IsUpdateCards", 1);
				await Shell.Current.GoToAsync("main", true);

			}
	
		}
		catch (Exception ex)
		{
			Trace.WriteLine(ex.Message);
		}
		finally
		{
			Busy = false;
		}
	}
}
