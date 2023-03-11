using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;


namespace MauiBank.HTTP;
#nullable enable
public class ApiClient<T>
{
	static HttpClient _client = new();

	//public static async Task<List<UserData>> GetUserDataAsync(int id)
	//{
		
	//	var result = await _client.GetAsync(uri);
	//	string jsonStr = result.Content.ReadAsStringAsync().Result;
	//	List<UserData> data = JsonConvert.DeserializeObject<List<UserData>>(jsonStr);
	//	return data;
	//}

	//public static async Task<int> GetUserId(string login, string password)
	//{
	//	string uri = Routes.getUserIdUri
	//		.Replace(@"{0}", login)
	//		.Replace(@"{1}", password);

	//	try
	//	{
	//		var result = await _client.GetAsync(uri);
	//		string jsonStr = result.Content.ReadAsStringAsync().Result;
	//		Id currentId = JsonConvert.DeserializeObject<Id>(jsonStr);
	//		return currentId.id;
	//	}
	//	catch (Exception ex)
	//	{
	//		Trace.WriteLine("\nERROR {0}\n", ex.Message);
	//		return -1;

	//	}


	//}


	public static async Task<bool> IsClientExist(int userAccountId)
	{
		string uri = Routes.getClientOnUserIdUri
			.Replace(@"{0}", userAccountId.ToString());

		try
		{
			var result = await _client.GetAsync(uri);
			string jsonStr = result.Content.ReadAsStringAsync().Result;
			try
			{
				Id currentId = JsonConvert.DeserializeObject<Id>(jsonStr);
				if (currentId == null) return false;
				return true;
			}
			catch
			{
				return false;
			}

		}
		catch (Exception ex)
		{
			Trace.WriteLine(@"\tERROR {0}", ex.Message);
			return false;
		}
	}

	public static async Task<HttpResponseMessage?> PostAsync(string uri, T obj, bool isNewItem = true)
	{ 
		try
		{
			string json = JsonConvert.SerializeObject(obj);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage? response = null;
			if (isNewItem)
			{ 
				var task = _client.PostAsync(uri, content);
				response = await task.WaitAsync(TimeSpan.FromSeconds(3));
			}
			else
			{ 
				var task = _client.PutAsync(uri, content);
				response = await task.WaitAsync(TimeSpan.FromSeconds(3));
			}
				

			if (response.IsSuccessStatusCode)
				Trace.WriteLine("\nSUCCESS new item saved.\n");
			else Trace.WriteLine($"\n{response.StatusCode} , {response.ReasonPhrase}\n");
			return response;
		}
		catch(Exception ex)
		{
			if (ex is TimeoutException) Trace.WriteLine("TIMEOUT");
			else Trace.WriteLine($"\nFAIL TO   POST   REQUEST: {ex.Message}");
			return null;
		}
	}

	public static async Task<T?> GetAsync(string uri)
	{
		try
		{
			HttpResponseMessage? result = null;
			var task = _client.GetAsync(uri);
			result = await task.WaitAsync(TimeSpan.FromSeconds(3));

			string jsonStr = result.Content.ReadAsStringAsync().Result;
			T? response = JsonConvert.DeserializeObject<T>(jsonStr);
			return response;
		}
		catch (Exception ex)
		{
			if (ex is TimeoutException) Trace.WriteLine("TIMEOUT");
			else Trace.WriteLine("\nFAIL TO   GET   REQUEST: " + ex.Message);
			return default;
		}
	}

}
