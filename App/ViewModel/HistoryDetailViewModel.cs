

namespace MauiBank.ViewModel;


public partial class HistoryDetailViewModel : BaseViewModel, IQueryAttributable
{
	[ObservableProperty]
	public PayCheckFromDB payCheck;

	[ObservableProperty]
	public string fullName;

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		_ = Task.Run(async () =>
		{
			await FillAllFields((int)query["selectedHistoryId"]);
		});
		



	}

	async Task FillAllFields(int id)
	{
		try
		{
			var ListPayChecks = await ApiClient<List<PayCheckFromDB>>.GetAsync(Routes.getFullPayChecks + id);
			PayCheck = ListPayChecks.FirstOrDefault();
			FullName = PayCheck.Sender_Second_name + " " + PayCheck.Sender_First_name + " " + PayCheck.Sender_Last_name;

		}
		catch (Exception ex)
		{
			await Shell.Current.DisplayAlert(ex.Message,"Ошибка", "OK");
			
		}
		
	}
}
