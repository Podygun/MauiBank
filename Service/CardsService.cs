namespace MauiBank.Service;


public class CardsService
{
	public string GetNewCardNumber(string cardSystem)
	{
		string finalNumber;

		do
		{
			finalNumber = string.Empty;
			switch (cardSystem)
			{
				case "мир":
					finalNumber += "2";
					break;
				case "visa":
					finalNumber += "4";
					break;
				case "maestro":
					finalNumber += "6";
					break;
				case "mastercard":
					finalNumber += "5";
					break;
				default:
					break;
			}
			Random rnd = new();
			finalNumber += RandomString(rnd, 15);
		}
		while (!isUnique(finalNumber));

		return finalNumber;

	}

	private bool isUnique(string finalNumber)
	{
		//TODO
		//Обращение на уникальность номера к БД
		return true;
	}

	public static string RandomString(Random random, int length)
	{
		const string chars = "0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}

}
