using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;


namespace MauiBank.HTTP;
#nullable enable
public class ApiClient<T>
{
	static HttpClient _client = new();
	private static readonly TimeSpan timeOut = TimeSpan.FromSeconds(5);

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
				response = await task.WaitAsync(timeOut);
			}
			else
			{ 
				var task = _client.PutAsync(uri, content);
				response = await task.WaitAsync(timeOut);
			}
				
			if (response.IsSuccessStatusCode)
			{
				if (isNewItem) Trace.WriteLine("\tsuccess POST");
				else Trace.WriteLine("\tsuccess PUT");
			}
				
			else Trace.WriteLine($"\n{response.StatusCode} , {response.ReasonPhrase}\n");
			return response;
		}
		catch(Exception ex)
		{
			if (ex is TimeoutException) Trace.WriteLine("TIMEOUT");
			else Trace.WriteLine($"\t fail to POST request: {ex.Message}");
			return null;
		}
	}

	public static async Task<T?> GetAsync(string uri)
	{
		try
		{
			HttpResponseMessage? result = null;
			var task = _client.GetAsync(uri);
			result = await task.WaitAsync(timeOut);

			string jsonStr = result.Content.ReadAsStringAsync().Result;
			T? response = JsonConvert.DeserializeObject<T>(jsonStr);
			Trace.WriteLine($"\tsuccess GET ({typeof(T)})");
			return response;
		}
		catch (Exception ex)
		{
			if (ex is TimeoutException) Trace.WriteLine("TIMEOUT");
			else Trace.WriteLine("\tfail GET request: " + ex.Message + $"\turi:{uri}");
			return default;
		}
	}

}
