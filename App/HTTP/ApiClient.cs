using Newtonsoft.Json;
using System.Globalization;
using System.Text;


namespace MauiBank.HTTP;
#nullable enable
public class ApiClient<T>
{
	static HttpClient _client = new();
	private static readonly TimeSpan timeOut = TimeSpan.FromSeconds(5);

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
		catch (Exception ex)
		{
			if (ex is TimeoutException) Trace.WriteLine("TIMEOUT");
			else Trace.WriteLine($"\t fail to POST request: {ex.Message}");
			return null;
		}
	}


	public static async Task<T?> GetAsync(string uri)
	{
		var task = _client.GetAsync(uri);
		HttpResponseMessage? result = await task.WaitAsync(timeOut);
		if (result.IsSuccessStatusCode)
		{
			string jsonStr = result.Content.ReadAsStringAsync().Result;
			T? response = JsonConvert.DeserializeObject<T>(jsonStr);
			if (response == null) Trace.WriteLine("GET Response is null");
			Trace.WriteLine($"\tsuccess GET ({typeof(T)})");
			return response;
		}
		else
		{
			throw new Exception("Ошибка подключения к серверу");
		}
	}

}
