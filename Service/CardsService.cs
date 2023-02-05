namespace MauiBank.Service;

public class CardsService
{
	ObservableCollection<Card> cardsCollection = new();

	public ObservableCollection<Card> GetCardsAsync(string userId)
	{
		string sqlQuery = $"select * from карты " +
				$"WHERE id_Банковского_счета in (" +
				$"select id FROM `банковские счета` " +
				$"WHERE id_клиента = (" +
				$"select distinct id from клиенты " +
				$"WHERE id_аккаунта = {userId}))";

		DataSet cardsDS =  Database.Database.GetDataSet(sqlQuery);

		cardsCollection = new ObservableCollection<Card>();

		foreach (DataRow card in cardsDS.Tables[0].Rows)
		{
			cardsCollection.Add(new Card()
			{
				id = card.ItemArray[0].ToString(),
				type = card.ItemArray[1].ToString(),
				number = card.ItemArray[2].ToString(),
				cvv = card.ItemArray[3].ToString(),
				dateEnd = card.ItemArray[4].ToString()
			});
		}

		return cardsCollection;
	}
}
