namespace MauiBank.Model;

#nullable enable
public class Client
{
	public int id { get; set; }
	public string first_name { get; set; }
	public string second_name { get; set; }
	public string last_name { get; set; }
	public string gender { get; set; }
	public string? email { get; set; }
	public string phone { get; set; }
	public int user_account_id { get; set; }
	public DateTime? deleted_at { get; set; }
	public DateTime? created_at { get; set; }
	public DateTime? updated_at { get; set; }

}
