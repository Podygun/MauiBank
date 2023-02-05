namespace MauiBank.Service;

public class CardsService
{
	ObservableCollection<Card> cardsCollection = new();

	public async Task<ObservableCollection<Card>> GetCardsAsync(string userId)
	{
		string sqlQuery = $"select " +
			$"карты.* " +
			$", ch.Баланс" +
			$", ch.код_валюты" +
			$"from карты " +
			$"left join `банковские счета` as ch on id_Банковского_счета=ch.id " +
				$"WHERE id_Банковского_счета in (" +
				$"select id FROM `банковские счета` " +
				$"WHERE id_клиента = (" +
				$"select distinct id from клиенты " +
				$"WHERE id_аккаунта = {userId}))";

		DataSet cardsDS = await Database.Database.GetDataSet(sqlQuery);

		cardsCollection = new ObservableCollection<Card>();

		string tempColor = String.Empty;
		int i = 0;

		foreach (DataRow card in cardsDS.Tables[0].Rows)
		{
			if (i == Colors.Length) i = 0;
			tempColor = Colors[i];

			cardsCollection.Add(new Card()
			{
				Id = card.ItemArray[0].ToString(),
				Type = card.ItemArray[1].ToString(),
				Number = card.ItemArray[2].ToString(),
				Cvv = card.ItemArray[3].ToString(),
				DateEnd = card.ItemArray[4].ToString(),
				Balance = card.ItemArray[5].ToString(),
				Code = card.ItemArray[6].ToString(),
				Color = tempColor
			});

			i++;
		}

		return cardsCollection;
	}


	readonly static string[] Colors = new string[]
	{
		"#8916FF",
		"#ECC200",
		"#424874"
	};
}
