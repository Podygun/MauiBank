namespace MauiBank.ViewModel;

public partial class HistoryViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<Grouping<DateOnly, HistoryD>> histories = new();

	private bool isFirstEntry = true;

	public HistoryViewModel()
	{
		if(isFirstEntry) LoadPayChecks();
		
	}

	//NODE
	//	Название организации или ФИО владельца
	//	Услуга
	//	Сумма
	//	Валюта
	//	Created_at

	[RelayCommand]
	public async Task LoadPayChecks()
	{
		if (Busy) return;
		if (!isFirstEntry) Histories.Clear();
		try
		{
			Busy = true;
			var DBPayChecks = await ApiClient<List<History>>.GetAsync(Routes.payChecksOnBankAccIdUri + Preferences.Default.Get("bank_account_id", -1));
			var ConvertedPayChecks = ConvertDateTimeToDateOnly(DBPayChecks);
			var groups = ConvertedPayChecks
				.GroupBy(p => p.Time)
				.Select(g => new Grouping<DateOnly, HistoryD>(g.Key, g))
				.OrderByDescending(o => o.Time);
			var finalList = new ObservableCollection<Grouping<DateOnly, HistoryD>>(groups);

			foreach (var hist in finalList)
			{	
				Histories.Add(hist);
			}
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

	private ObservableCollection<HistoryD> ConvertDateTimeToDateOnly(List<History> histories)
	{
		ObservableCollection<HistoryD> finalList = new();

		foreach (History item in histories)
		{
			HistoryD newItem = new HistoryD
			{
				Id = item.Id,
				Favour = item.Favour,
				Sum = item.Sum,
				Fee = item.Fee,
				Requisite_value = item.Requisite_value,
				First_name = item.First_name,
				Last_name = item.Last_name,
				Second_name = item.Second_name,
				Valute = item.Valute,
				Time = DateOnly.FromDateTime(item.Time)
			};

			finalList.Add(newItem);
		}
		return finalList;
	}

	[RelayCommand]
	public async Task GoToHistoryDetail(History selectedHistory)
	{
		if (Busy) return;
		try
		{
			Busy = true;
			await Shell.Current.GoToAsync($"historydetail?historyId={selectedHistory.Id}");
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
