namespace MauiBank.ViewModel;


public partial class OrganisationTransferViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    ObservableCollection<Requisite> requisites = new();

	[ObservableProperty]
	ObservableCollection<Organisation> organisations = new();

	[ObservableProperty]
    string requisiteValue;

	[ObservableProperty]
	string organisationName;

	int OrganisationId;

	Organisation SelectedOrganisation = new();


	[ObservableProperty]                                                                                                                                                                                         
	double fee;

	private double sum;
	public double Sum
	{
		get => sum;
		set
		{
			SetProperty(ref sum, value);
			ComputeFee();
		}
	}

	private void ComputeFee() => Fee = sum * 0.01;

	public OrganisationTransferViewModel()
    {
        
    }

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
        Favour tempFavour = query["Organisation"] as Favour;
        OrganisationName = tempFavour.Name;
        OrganisationId = tempFavour.Id;
        FillRequisites();
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
				requisite_value = RequisiteValue,
				favour_id = Preferences.Default.Get("favour_id", 0)
			};
			Preferences.Clear("favour_id");

			var result = await ApiClient<PayCheck>.PostAsync(Routes.setNewPaymentUri, payCheck);

			if (result.IsSuccessStatusCode)
			{
				await Shell.Current.DisplayAlert("Успешно", $"Оплата {OrganisationName} выполнена", "OK");
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


    private async Task FillRequisites()
    {
        if (Busy) return;
        try
        {
            Busy = true;
            var tempRequisites = await ApiClient<List<Requisite>>.GetAsync(Routes.getRequisitesOnOrganisationId + OrganisationId);
            foreach (var requisite in tempRequisites)
            {
                Requisites.Add(requisite);
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
