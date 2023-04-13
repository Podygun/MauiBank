namespace MauiBank.Service;


public class CardsService
{
	public async Task<string> GetNewCardNumber(string prefix)
	{
		string finalNumber;
		bool isUnique;
		do
		{
			finalNumber = string.Empty + prefix;
			Random rnd = new();
			finalNumber += RandomString(rnd, 15);
			isUnique = await isUniqueNumber(finalNumber);			
		}
		while (!isUnique);
		return finalNumber;
	}

	private async Task<bool> isUniqueNumber(string sourceNumber)
	{
		Card? foundCard = await ApiClient<Card?>.GetAsync(Routes.getCardOnNumber.Replace("{0}",sourceNumber));
		if (foundCard == null) return true;
		return false;
	}

	public string RandomString(Random random, int length)
	{
		const string chars = "0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}

	public string GetCvv(int length = 3)
	{
		Random rnd = new();
		const string chars = "0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[rnd.Next(s.Length)]).ToArray());
	}
}
