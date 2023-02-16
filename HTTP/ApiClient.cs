using Newtonsoft.Json;
using System.Text;

namespace MauiBank.HTTP;

public class ApiClient
{
	static HttpClient _client = new();

	static readonly short isNgrok = 1;
	static readonly string ngrokUri = @"https://d49a-136-169-210-93.eu.ngrok.io/";


	static readonly string port =		   "8000";
	static readonly string localhost =    @"http://127.0.0.1";
	static readonly string emulatorhost = @"http://10.0.2.2";





	public ApiClient()
	{ 

	}


	public static async Task<List<UserData>> GetUserDataAsync(int id)
	{
		string uri = Routes.getUserDataUri.Replace("id", id.ToString());
		var result = await _client.GetAsync(uri);
		string jsonStr = result.Content.ReadAsStringAsync().Result;
		List<UserData> data = JsonConvert.DeserializeObject<List<UserData>>(jsonStr);
		return data;
	}

	public static async Task<int> GetUserId(string login, string password)
	{
		string uri = "";
		string uriTemplate = $"api/users/get?login={login}&password={password}";

#if ANDROID
		uri = (isNgrok == 0) ?
			$"{emulatorhost}:{port}/" + uriTemplate :
			$"{ngrokUri} + {uriTemplate}";
#elif WINDOWS
		uri = $"{localhost}:{port}/" + uriTemplate;
#endif
		try
		{
			var result = await _client.GetAsync(uri);
			string jsonStr = result.Content.ReadAsStringAsync().Result;
			Id currentId = JsonConvert.DeserializeObject<Id>(jsonStr);
			return currentId.id;
		}
		catch (Exception ex)
		{
			return -1;
			throw;
		}

		

	}

	public static async Task SaveUserAsync(UserAccount account, bool isNewItem = true)
	{
		string uri = Routes.postUserAccountUri;
		try
		{
			string json = JsonConvert.SerializeObject(account);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

			HttpResponseMessage response = null;
			if (isNewItem)
				response = await _client.PostAsync(uri, content);
			else
				response = await _client.PutAsync(uri, content);

			if (response.IsSuccessStatusCode)
				Trace.WriteLine(@"\New UserAccounnt successfully saved.");
		}
		catch (Exception ex)
		{
			Trace.WriteLine(@"\tERROR {0}", ex.Message);
		}
	}

}
