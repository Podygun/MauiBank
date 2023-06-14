namespace MauiBank.Model;

public class UserAccount
{
	public int id { get; set; }
	public string login { get; set; }
	public string password { get; set; }
	public string salt { get; set; }
}
