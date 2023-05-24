using MauiBank.Model;

namespace MauiBank.ViewModel;

public partial class HistoryViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<Grouping<DateOnly, PayCheck>> histories = new();


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
			int bank_account_id = (int)CacheService.GetValue("bank_account_id");

			Histories = await CacheService.GetOrCreateHistories(bank_account_id + "-histories", TimeSpan.FromSeconds(1),async () =>
			{
				var temp = await ApiClient<List<PayCheck>>.GetAsync(Routes.getShortPayChecks + bank_account_id);
                foreach (var item in temp)
                {
					if (item.bank_account_id == bank_account_id) item.sum *= -1;
					
				}
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
	public async Task GoToHistoryDetail(PayCheck selectedPayCheck)
	{
		if (Busy) return;
		if (Busy) return;
		if (selectedPayCheck is null) return;	
		try
		{
			Busy = true;
			await Shell.Current.GoToAsync("historydetail", true, new Dictionary<string, object>
			{
				{"selectedHistoryId", selectedPayCheck.id }
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
