using MauiBank.Service.Security;
using MySqlConnector;
using System.Diagnostics;
using System.Security;

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

	public static DataSet GetDataSet(string sqlQuery)
	{
		var connString = "Server=localhost;Port=3306;User ID=root;Password=root;Database=bank_db";
		//var builder = new MySqlConnectionStringBuilder
		//{
		//	Server = "localhost",
		//	UserID = "root",
		//	Password = "root",
		//	Database = "bank_db",
		//	Port = 3306,
		//	SslMode = MySqlSslMode.None,
		//};

		using var connection = new MySqlConnection(connString);
		connection.Open();
		//connection.CloseAsync();
		//try
		//{
			//await connection.OpenAsync();
			
			MySqlDataAdapter DA = new MySqlDataAdapter(sqlQuery, connection);
			DataSet ds = new DataSet();

			//MySqlCommand cmd = new MySqlCommand();

			//cmd.CommandType = CommandType.Text;
			//cmd.CommandText = sqlQuery;
			//cmd.Connection = connection;

			//DA.SelectCommand = cmd;
			DA.Fill(ds);
		
		return ds;
		connection.Close();
		//}
		//catch
		//{
		return null;
		//}
		//finally
		//{
			
		//}

	}

	//private static string GetConnectionString() => "host=127.0.0.1;port=3306;user=root;password=root;database=bank_db";

	public static void tryConnect()
	{
		var connString = "Server=192.168.1.105;Port=3306;User ID=root;Password=root;Database=bank_db";

		using var connection = new MySqlConnection(connString);
		connection.OpenAsync();
		connection.CloseAsync();
		// open a connection asynchronously

	}
}
