using MySqlConnector;
using System.Diagnostics;


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
		await using var connection = new MySqlConnection(GetConnectionString());
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

	public static async Task<string> GetUserId(string login, string password)
	{
		const string commandText = "select id from аккаунты where Логин = @login and Пароль = @password";
		await using var connection = new MySqlConnection(GetConnectionString());

		try
		{
			await connection.OpenAsync();
			string hashedPassword =  Security.Hasher.ComputeSha256(password + GetUserSalt(login));
			using var command = new MySqlCommand(commandText, connection);
			command.Parameters.AddWithValue("@password", hashedPassword);
			command.Parameters.AddWithValue("@login", login);

			await using MySqlDataReader reader = await command.ExecuteReaderAsync();
			while(reader.Read())
			{
				return reader.GetValue(0).ToString();
			}
			return "-1";

		}
		catch (Exception ex)
		{
			Trace.WriteLine(ex.Message);
			return null;
		}

		finally
		{
			await connection.CloseAsync();
		}
	}

	public static string GetUserSalt(string login)
	{
		const string commandText = "select Salt from аккаунты where Логин = @login";
		using var connection = new MySqlConnection(GetConnectionString());

		try
		{
			connection.Open();
			using var command = new MySqlCommand(commandText, connection);
			command.Parameters.AddWithValue("@login", login);

			string salt = command.ExecuteScalar()?.ToString();
			return salt ?? string.Empty;
		}
		catch (Exception ex)
		{
			Trace.WriteLine(ex.Message);
			return "-1";
		}
		finally
		{
			connection.Close();
		}

	}

	private static string GetConnectionString() => "Server=localhost;Port=3306;User ID=root;Password=root;Database=bank_db";


}
