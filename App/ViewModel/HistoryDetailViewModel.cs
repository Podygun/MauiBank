

namespace MauiBank.ViewModel;


public partial class HistoryDetailViewModel : BaseViewModel, IQueryAttributable
{
	[ObservableProperty]
	public PayCheckFromDB thisPayCheck;

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
			ThisPayCheck = ListPayChecks.FirstOrDefault();
			FullName = ThisPayCheck.Sender_Second_name + " " + ThisPayCheck.Sender_First_name + " " + ThisPayCheck.Sender_Last_name;

		}
		catch (Exception ex)
		{
			await Shell.Current.DisplayAlert(ex.Message,"Ошибка", "OK");
			
		}
		
	}
}
