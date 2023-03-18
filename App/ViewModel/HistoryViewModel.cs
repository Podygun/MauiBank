namespace MauiBank.ViewModel;

public partial class HistoryViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<History> histories = new();

	private bool isFirstEntry = true;

	public HistoryViewModel()
	{
		if(isFirstEntry) LoadPayChecks();
		
	}

	[RelayCommand]
	public async Task LoadPayChecks()
	{

		if (Busy) return;
		if (!isFirstEntry) Histories.Clear();
		try
		{
			Busy = true;
			var tempPayChecks = await ApiClient<List<History>>.GetAsync(Routes.payChecksOnBankAccIdUri + Preferences.Default.Get("bank_account_id", -1));
			
			foreach (var payCheck in tempPayChecks)
			{
				Histories.Add(payCheck);
			}
			Trace.WriteLine("count is " + Histories.Count);
			isFirstEntry = false;
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
