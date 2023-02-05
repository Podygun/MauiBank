using MySqlConnector;

namespace MauiBank.Service.Database;

internal class Database
{


	//private static readonly MySqlConnection con = new MySqlConnection(GetConnectionString());

	///// <summary>
	///// 
	///// </summary>
	///// <param name="login"></param>
	///// <param name="password"></param>
	///// <returns>
	///// "-1"     if not found
	///// null     if Database Error
	///// </returns>
	//public static string? GetUserId(string login, SecureString password)
	//{
	//	string commandText = "select id from аккаунты " +
	//			"where Логин = @login and Пароль = @password";
	//	using (MySqlCommand command = new MySqlCommand(commandText, con))
	//	{

	//		string hashedPassword = Hasher.ComputeSha256(new System.Net.NetworkCredential(string.Empty, password).Password + GetUserSalt(login));


	//		command.Parameters.AddWithValue("@password", hashedPassword);
	//		command.Parameters.AddWithValue("@login", login);
	//		try
	//		{
	//			con.Open();
	//			string? id = command.ExecuteScalar()?.ToString();
	//			return id ?? "-1";
	//		}
	//		catch (System.Exception e)
	//		{
	//			Trace.WriteLine(e.Message);
	//			return null;
	//		}
	//		finally
	//		{
	//			con.Close();
	//		}
	//	}
	//}

	//public static string? GetUserSalt(string login)
	//{
	//	string commandText = "select Salt from аккаунты " +
	//			"where Логин = @login";
	//	using (MySqlCommand command = new MySqlCommand(commandText, con))
	//	{
	//		command.Parameters.AddWithValue("@login", login);
	//		try
	//		{
	//			con.Open();
	//			string? salt = command.ExecuteScalar()?.ToString();
	//			return salt ?? string.Empty;
	//		}
	//		catch (System.Exception e)
	//		{
	//			Trace.WriteLine(e.Message);
	//			return null;
	//		}
	//		finally
	//		{
	//			con.Close();
	//		}
	//	}
	//}

	//public static bool ModifyDataBase(MySqlCommand command)
	//{
	//	try
	//	{
	//		con.Open();
	//		command.ExecuteNonQuery();
	//		return true;
	//	}
	//	catch (System.Exception e)
	//	{
	//		Trace.WriteLine(e.Message);
	//		return false;
	//	}
	//	finally
	//	{
	//		con.Close();
	//	}
	//}

	//public static bool InsertUser(string login, string password)
	//{
	//	string salt = Hasher.GenerateSalt();
	//	string commandText = PatternStrings.insertQuery
	//		.Replace("_table", "аккаунты")
	//		.Replace("_columns", "Логин, Пароль, Salt")
	//		.Replace("_values", "@login, @password, @Salt");

	//	using (MySqlCommand command = new MySqlCommand(commandText, con))
	//	{
	//		command.Parameters.AddWithValue("@login", login);
	//		command.Parameters.AddWithValue("@password", Hasher.ComputeSha256(password + salt));
	//		command.Parameters.AddWithValue("@Salt", salt);
	//		return ModifyDataBase(command);
	//	}
	//}

	//public static ObservableCollection<string> GetColumn(string column, string table)
	//{
	//	string sqlQuery = $"select distinct {column} from {table}";
	//	using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
	//	{
	//		try
	//		{
	//			DataSet ds = new DataSet();
	//			MySqlDataAdapter DA = new MySqlDataAdapter();
	//			MySqlCommand cmd = new MySqlCommand();

	//			cmd.CommandType = CommandType.Text;
	//			cmd.CommandText = sqlQuery;
	//			cmd.Connection = con;

	//			con.Open();

	//			DA.SelectCommand = cmd;
	//			DA.Fill(ds, "defaultTable");

	//			ObservableCollection<string> list = new ObservableCollection<string>();

	//			foreach (DataRow row in ds.Tables[0].Rows)
	//			{
	//				list.Add(row[0].ToString());
	//			}
	//			return list;
	//		}
	//		catch
	//		{
	//			return null;
	//		}
	//		finally
	//		{
	//			con.Close();
	//		}
	//	}
	//}

	public static async Task<DataSet> GetDataSet(string sqlQuery)
	{
		var connString = "Server=localhost;Port=3306;User ID=root;Password=root;Database=bank_db";
		await using var connection = new MySqlConnection(connString);
		try
		{
			await connection.OpenAsync();
			MySqlDataAdapter DA = new MySqlDataAdapter(sqlQuery, connection);
			DataSet ds = new DataSet();
			DA.Fill(ds);
			return ds;
		}
		catch
		{
			return null;
		}
		finally
		{
			await connection.CloseAsync();
		}
	}
}
