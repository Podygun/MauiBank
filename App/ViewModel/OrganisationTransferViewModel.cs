namespace MauiBank.ViewModel;


public partial class OrganisationTransferViewModel : BaseViewModel
{
    [ObservableProperty]
    ObservableCollection<Requisite> requisites = new();

    [ObservableProperty]
    string requisiteValue;

	[ObservableProperty]
	string organisation;

	[ObservableProperty]
	double sum;

	[ObservableProperty]                                                                                                                                                                                         
	double fee;

	public OrganisationTransferViewModel()
    {
        
    }

    [RelayCommand]
    public async Task Transfer()
    {

    }


    private async Task FillRequisites()
    {
        if (Busy) return;
        try
        {
            Busy = true;
            var tempRequisites = await ApiClient<List<Requisite>>.GetAsync(Routes.getClientOnUserIdUri);
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
