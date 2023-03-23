namespace MauiBank.Model;

public class History
{
	public int Id { get; set; }
	public DateTime Time { get; set; }
	public double Sum { get; set; }
	public double Fee { get; set; }
	public string Requisite_value { get; set; }
	public string First_name { get; set; }
	public string Second_name { get; set; }
	public string Last_name { get; set; }
	public string Valute { get; set; }
	public string Favour { get; set; }
}

public class HistoryD
{
	public int Id { get; set; }
	public DateOnly Time { get; set; }
	public double Sum { get; set; }
	public double Fee { get; set; }
	public string Requisite_value { get; set; }
	public string First_name { get; set; }
	public string Second_name { get; set; }
	public string Last_name { get; set; }
	public string Valute { get; set; }
	public string Favour { get; set; }
}
