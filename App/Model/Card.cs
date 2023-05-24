namespace MauiBank.Model;


public partial class Card : ObservableObject
{
	
	public string number { get; set; }
	public string cvv { get; set; }
	public DateOnly date_end { get; set; }
	public int bank_account_id { get; set; }
	public double balance { get; set; }
	public string type_name { get; set; }
	public string valute { get; set; }
}

public class CardDB
{
	public int id { get; set; }
	public string number { get; set; }
	public string cvv { get; set; }
	public DateOnly date_end { get; set; }
	public int card_type_id { get; set; }
	public int bank_account_id { get; set; }

}

