namespace MauiBank.HTTP;


public static class Routes
{
	private const short isNgrok =1;
	private const string ngrokUri = @"https://ff83-136-169-210-93.eu.ngrok.io/";

	private const string port = "8000/";
	private const string localhost = @"http://127.0.0.1:";
	private const string emulatorhost = @"http://10.0.2.2:";


	

	#region GetUserData
#if WINDOWS
	public static string getUserDataUri = localhost + port + @"api/userdata/id";
#elif ANDROID
	public static string getUserDataUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"api/userdata/id" :
		ngrokUri + @"api/userdata/id";

#endif
	#endregion

	#region SaveUserAccount
#if WINDOWS
	public static string postUserAccountUri =
		localhost + port + @"api/userAccounts";
#elif ANDROID
	public static string postUserAccountUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"api/userAccounts" :
		ngrokUri + @"api/userAccounts";

#endif
	#endregion

	#region GetUserId
#if WINDOWS
	public static string getUserIdUri =
		localhost + port + @"api/users/get?login={0}&password={1}";
#elif ANDROID
	public static string getUserIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"api/userAccounts/get?login={0}&password={1}" :
		ngrokUri + @"api/userAccounts/get?login={0}&password={1}";
#endif
	#endregion

	#region GetClientOnUserIdUri
#if WINDOWS
	public static string getClientOnUserIdUri =
		localhost + port + @"api/clients/getOnUserAccountId?id={0}";
#elif ANDROID
	public static string getClientOnUserIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"api/clients/getOnUserAccountId?id={0}" :
		ngrokUri + @"api/clients/getOnUserAccountId?id={0}";

#endif
	#endregion

	#region GetValutes
#if WINDOWS
	public static string getValutesUri =
		localhost + port + @"api/valutes/";
#elif ANDROID
	public static string getValutesUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"api/userAccounts/get?login={0}&password={1}" :
		ngrokUri + @"api/userAccounts/get?login={0}&password={1}";
#endif
	#endregion

	#region GetAllClientOnUserIdUri
#if WINDOWS
	public static string getAllClientOnUserIdUri =
		localhost + port + @"api/clients/getAllOnUserAccountId?id={0}";
#elif ANDROID
	public static string getAllClientOnUserIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"api/clients/getAllOnUserAccountId?id={0}" :
		ngrokUri + @"api/clients/getAllOnUserAccountId?id={0}";

#endif
	#endregion

}
