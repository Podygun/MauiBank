namespace MauiBank.Model;

public class PayCheck
{
	public string? Time { get; set; }
	public int id { get; set; }
	public string? created_at { get; set; }
	public double sum { get; set; }
	public double fee { get; set; }
	public int bank_account_id { get; set; }
	public int? to_bank_account_id { get; set; }
	public int? favour_id { get; set; }
	public string favour { get; set; }
	public string valute { get; set; }
	public string requisite_value { get; set; }
}

public class PayCheckFromDB
{
	public string Time { get; set; }
	public int Id { get; set; }
	public double Sum { get; set; }
	public double Fee { get; set; }
	public string Requisite_value { get; set; }
	public int Bank_account_id { get; set; }
	public int To_bank_account_id { get; set; }
	public string Sender_First_name { get; set; }
	public string Sender_Second_name { get; set; }
	public string Sender_Last_name { get; set; }
	public string Reciever_First_name { get; set; }
	public string Reciever_Second_name { get; set; }
	public string Reciever_Last_name { get; set; }
	public string Valute { get; set; }
	public string Favour { get; set; }
}

public class ShortPayCheck
{
	public string Time { get; set; }
	public string Requisite_value { get; set; }
	public int Id { get; set; }
	public double Sum { get; set; }
	public string Valute { get; set; }
	public string Favour { get; set; }

}
