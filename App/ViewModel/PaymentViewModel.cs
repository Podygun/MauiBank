namespace MauiBank.ViewModel;


public partial class PaymentViewModel : BaseViewModel, IQueryAttributable
{
	[ObservableProperty]
	public ObservableCollection<Favour> favours = new();

	public Favour mainFavour;

	private bool flagOrganisation = false;

    public PaymentViewModel(){	}



	private async Task LoadPrimaryFavours()
	{
		Trace.WriteLine("Главные услуги");
		if (Busy) return;
		try
		{ 
			Busy = true;
			var tempFavours = await ApiClient<List<Favour>>.GetAsync(Routes.getPrimaryFavoursUri);
			foreach (var favour in tempFavours)
			{
				Favours.Add(favour);
			}
		}
		catch (Exception ex)
		{
			Trace.WriteLine($"FAIL TO LOAD PRIMARY FAVOURS: {ex.Message}");
		}
		finally
		{
			Busy = false;
		}
	}

	private async Task LoadSubFavours(int id)
	{
		Trace.WriteLine("Загрузка ПодУслуг");
		try
		{
			var tempFavours = await ApiClient<List<Favour>>
				.GetAsync(Routes.getSecondaryFavoursUri.Replace("{0}", id.ToString()));
			if(tempFavours.Count == 0)
			{
				await LoadOrganisations(id);
				Preferences.Default.Set("favour_id",id);
				return;
			}
			foreach (var favour in tempFavours)
			{
				Favours.Add(favour);
			}
		}
		catch (Exception ex)
		{
			Trace.WriteLine($"fail to load SECONDARY favours: {ex.Message}");
		}

	}

	private async Task LoadOrganisations(int id)
	{
		try
		{
			var tempOragnisations = await ApiClient<List<Organisation>>
				.GetAsync(Routes.getOrganisationsOnFavourIdUri + id);
            foreach (var org in tempOragnisations)
			{
				var fakeFavour = new Favour
				{
					Name = org.Name,
					Id = org.Id,
				};
				Favours.Add(fakeFavour);
			}
			flagOrganisation = true;
		}
		catch (Exception ex)
		{
			Trace.WriteLine(ex.Message);
		}
		

	}

	[RelayCommand]
	public async Task TapFavour(Favour favour)
	{
		Trace.WriteLine("Нажатие на услугу");

		if (flagOrganisation)
		{
			await Shell.Current.GoToAsync("orgtransfer", true, new Dictionary<string, object>
			{
				{"Organisation", favour }
			});
			return;
		}

		if (favour.Id == 1)
		{
			await LoadCardPayment();
			return;
		}

		if (Busy) return;
		try
		{
			Busy = true;
			if (favour is null) return;
			Trace.WriteLine(String.Format("Going to {0} favour", favour.Name));
			await Shell.Current.GoToAsync("payment", true,
				new Dictionary<string, object>
				{
					{"Favour", favour }
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


	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		Trace.WriteLine("Аттрибуты");
		Favours.Clear();
		mainFavour = (Favour)query["Favour"];
		LoadList(mainFavour);
		

	}

	private async Task LoadList(Favour favour)
	{
		if (favour.Id == -1) await LoadPrimaryFavours();
		else await LoadSubFavours(favour.Id);
		
	
	}

	private async Task LoadCardPayment()
	{
		Trace.WriteLine("cardtransfer");
		await Shell.Current.GoToAsync("cardtransfer");
	}

	
}
