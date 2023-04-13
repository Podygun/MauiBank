namespace MauiBank.Service;


public class BankAccountService
{

	public async Task<HttpResponseMessage?> Post(BankAccount ba)
	{
		var result = await ApiClient<BankAccount>.PostAsync(Routes.postBankAccount, ba);
		return result;
	}
}
