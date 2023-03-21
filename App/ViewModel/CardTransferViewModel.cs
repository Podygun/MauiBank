namespace MauiBank.ViewModel;

public partial class CardTransferViewModel : BaseViewModel
{
	bool fromQr = false;

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
		if (Preferences.Default.ContainsKey("cardToTransfer"))
		{
			CardNumber = Preferences.Default.Get("cardToTransfer", "Неверные данные");
			Preferences.Default.Clear("cardToTransfer");
			fromQr = true;
		}
		else fromQr = false;
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
				await GoBack();

				

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

	private async Task GoBack()
	{
		if (fromQr) await Shell.Current.GoToAsync("../../..", true);
		else		await Shell.Current.GoToAsync("main", true);
	}
}
