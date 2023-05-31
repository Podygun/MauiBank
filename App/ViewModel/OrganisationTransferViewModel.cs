namespace MauiBank.ViewModel;


public partial class OrganisationTransferViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    ObservableCollection<Requisite> requisites = new();

	[ObservableProperty]
	ObservableCollection<Organisation> organisations = new();

	[ObservableProperty]
	ObservableCollection<Card> cards = new();

	[ObservableProperty]
    string requisiteValue;

	[ObservableProperty]
	string organisationName;

	int OrganisationId;

	[ObservableProperty]
	Card selectedCard = new();


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

	private void ComputeFee() => Fee = sum * 0.0;

	public OrganisationTransferViewModel()
    {
        
    }

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
        Favour tempFavour = query["Organisation"] as Favour;
        OrganisationName = tempFavour.Name;
        OrganisationId = tempFavour.Id;
        FillRequisites();
		FillCards();
	}

	[RelayCommand]
    public async Task Transfer()
    {
		if (Busy) return;
		try
		{
			Busy = true;
			PostPayCheck payCheck = new PostPayCheck
			{
				bank_account_id = SelectedCard.bank_account_id,
				sum = Sum,
				fee = Fee,
				requisite_value = RequisiteValue,
				favour_id = Preferences.Default.Get("favour_id", 0),
				to_bank_account_id = null
			};
			Preferences.Clear("favour_id");

			var result = await ApiClient<PostPayCheck>.PostAsync(Routes.setNewPaymentUri, payCheck);

			if (result.IsSuccessStatusCode)
			{
				await Shell.Current.DisplayAlert("Успешно", $"Оплата {OrganisationName} выполнена", "OK");
				CacheService.SetValue("IsUpdateCards", "1");
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

	private void FillCards()
	{
		Cards = new ObservableCollection<Card>(CacheService.GetValue("Cards") as ObservableCollection<Card>);
	}
}
