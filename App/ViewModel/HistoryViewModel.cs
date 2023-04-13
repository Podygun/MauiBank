namespace MauiBank.ViewModel;

public partial class HistoryViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<Grouping<DateOnly, ShortPayCheck>> histories = new();


	public HistoryViewModel()
	{

		LoadPayChecks();
		
	}


	[RelayCommand]
	public async Task LoadPayChecks()
	{
		if (Busy) return;
		
		try
		{
			Busy = true;
			int bank_account_id = Preferences.Default.Get("bank_account_id", -1);

			Histories = await CacheService.GetOrCreateHistories(bank_account_id + "-histories", TimeSpan.FromSeconds(1),async () =>
			{
				var temp = await ApiClient<List<ShortPayCheck>>.GetAsync(Routes.getShortPayChecks + bank_account_id);
				return temp;
			});
		
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


	[RelayCommand]
	public async Task GoToHistoryDetail(ShortPayCheck selectedPayCheck)
	{
		if (Busy) return;
		if (selectedPayCheck is null) return;	
		try
		{
			Busy = true;
			await Shell.Current.GoToAsync("historydetail", true, new Dictionary<string, object>
			{
				{"selectedHistoryId", selectedPayCheck.Id }
			});
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
