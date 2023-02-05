using System.Security.Cryptography;
using System.Text;

namespace MauiBank.Service.Security;

public class Hasher
{
	public static string GenerateSalt()
	{
		Random RNG = new Random();
		int length = 16;
		string salt = "";
		for (var i = 0; i < length; i++)
		{
			salt += ((char)(RNG.Next(1, 26) + 64)).ToString().ToLower();
		}
		return salt;
	}

	public static string ComputeSha256(string password)
	{
		using (SHA256 sha256Hash = SHA256.Create())
		{
			byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < bytes.Length; i++)
			{
				builder.Append(bytes[i].ToString("x2"));
			}
			return builder.ToString();
		}
	}
}
