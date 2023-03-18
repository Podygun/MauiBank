namespace MauiBank.Model;

public class PayCheck
{
	public int id { get; set; }
	public string? created_at { get; set; }
	public double sum { get; set; }
	public double fee { get; set; }
	public int bank_account_id { get; set; }
	public int favour_id { get; set; }
	public string requisite_value { get; set; }
}
