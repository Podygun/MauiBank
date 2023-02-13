using Newtonsoft.Json;


namespace MauiBank.HTTP;

public class ApiClient
{
	static HttpClient _client = new();

	static short isNgrok = 0;
	static string ngrokUri = "";
	static string uri = "";

	public ApiClient()
	{

	}


	public static async Task<List<UserData>> GetUserDataAsync(int id)
	{	
		string uriTemplate = $"8001/api/userdata?userId={id}";
		
#if ANDROID
		uri = (isNgrok == 0) ?
			"http://10.0.2.2:" + uriTemplate :
			ngrokUri + $"api/usercards?clientId={id}";	
#elif WINDOWS
		uri = "http://127.0.0.1:" + uriTemplate;
#endif
		var result = await _client.GetAsync(uri);
		string jsonStr = result.Content.ReadAsStringAsync().Result;
		List<UserData> data = JsonConvert.DeserializeObject<List<UserData>>(jsonStr);
		return data;
	}

	public static async Task<int> GetUserId(string login, string password)
	{
		string uriTemplate = $"8001/api/users/get?login={login}&password={password}";

#if ANDROID
		uri = (isNgrok == 0) ?
			"http://10.0.2.2:" + uriTemplate :
			ngrokUri + $"api/usercards?clientId={id}";	
#elif WINDOWS
		uri = "http://127.0.0.1:" + uriTemplate;
#endif
		var result = await _client.GetAsync(uri);
		string jsonStr = result.Content.ReadAsStringAsync().Result;

		JsonTextReader reader = new JsonTextReader(new StringReader(jsonStr));
		while (reader.Read())
		{
			if (reader.Value != null)
				return (int)reader.Value;
		}
		return -1;
	}
}
