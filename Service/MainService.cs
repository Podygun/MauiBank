namespace MauiBank.Service;

public class MainService
{
	private static List<UserData> userDatas = new();

	public MainService()
	{
		
	}

	public static async Task<List<Card>> GetCardsAsync(int userId)
	{
		userDatas = await ApiClient.GetUserDataAsync(userId);

		List<Card> tempCards = new();

		foreach (var data in userDatas)
		{
			tempCards.Add(new()
			{
				Balance = data.balance,
				Cvv = data.cvv,
				Number = data.number,
				Type = data.card_type_name,
				Date_end = DateOnly.ParseExact(data.date_end, "yyyy-MM-dd")

			}) ;
		}

		for (int i = 0, j = 0; j < tempCards.Count; i++, j++)
		{
			if (i == Colors.Length) i = 0;
			tempCards[j].Color = Colors[i];
		}
		return tempCards;
	}

	readonly static string[] Colors = new string[]
	{
		"#8916FF",
		"#ECC200",
		"#424874"
	};

}
