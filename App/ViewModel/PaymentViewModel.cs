namespace MauiBank.ViewModel;


public partial class PaymentViewModel : BaseViewModel, IQueryAttributable
{
	[ObservableProperty]
	public ObservableCollection<Favour> favours = new();

	public Favour mainFavour;

    public PaymentViewModel()
    {
		
	}

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

	[RelayCommand]
	public async Task TapFavour(Favour favour)
	{
		Trace.WriteLine("Нажатие на услугу");
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
		//LoadList(mainFavour);
		Transfer();

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

	public async Task Transfer()
	{
		if (Busy) return;
		try
		{
			Busy = true;
			PayCheck payCheck = new PayCheck
			{
				bank_account_id = Preferences.Default.Get("bank_account_id", -1),
				sum = 100,
				fee = 0,
				requisite_value = "toto",
				favour_id = 1
			};

			var result = await ApiClient<PayCheck>.PostAsync(Routes.setNewPaymentUri, payCheck);

			if (result.IsSuccessStatusCode)
			{
				await Shell.Current.DisplayAlert("Успешно", "Перевод выполнен", "OK");
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
}
