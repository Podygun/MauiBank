namespace MauiBank.HTTP;


public static class Routes
{
	private const short isNgrok = 1;
	private const string ngrokUri = @"https://93fd-136-169-210-93.eu.ngrok.io/api/";

	private const string port = "8000/api/";
	private const string localhost = @"http://127.0.0.1:";
	private const string emulatorhost = @"http://10.0.2.2:";


	

	#region GetUserData
#if WINDOWS
	public static string getUserDataUri = localhost + port + @"userdata/{0}";
#elif ANDROID
	public static string getUserDataUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"userdata/{0}" :
		ngrokUri + @"userdata/{0}";

#endif
	#endregion

	#region SaveUserAccount
#if WINDOWS
	public static string postUserAccountUri =
		localhost + port + @"userAccounts";
#elif ANDROID
	public static string postUserAccountUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"userAccounts" :
		ngrokUri + @"userAccounts";

#endif
	#endregion

	#region GetUserId
#if WINDOWS
	public static string getUserIdUri =
		localhost + port + @"userAccounts/get?login={0}&password={1}";
#elif ANDROID
	public static string getUserIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"userAccounts/get?login={0}&password={1}" :
		ngrokUri + @"userAccounts/get?login={0}&password={1}";
#endif
	#endregion

	#region GetClientOnUserIdUri
#if WINDOWS
	public static string getClientOnUserIdUri =
		localhost + port + @"clients/getOnUserAccountId?id={0}";
#elif ANDROID
	public static string getClientOnUserIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"clients/getOnUserAccountId?id={0}" :
		ngrokUri + @"clients/getOnUserAccountId?id={0}";

#endif
	#endregion

	#region GetValutes
#if WINDOWS
	public static string getValutesUri =
		localhost + port + @"valutes/";
#elif ANDROID
	public static string getValutesUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"userAccounts/get?login={0}&password={1}" :
		ngrokUri + @"userAccounts/get?login={0}&password={1}";
#endif
	#endregion

	#region GetAllClientOnUserIdUri
#if WINDOWS
	public static string getAllClientOnUserIdUri =
		localhost + port + @"clients/getAllOnUserAccountId?id={0}";
#elif ANDROID
	public static string getAllClientOnUserIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"clients/getAllOnUserAccountId?id={0}" :
		ngrokUri + @"clients/getAllOnUserAccountId?id={0}";

#endif
	#endregion

	#region GetPrimaryFavours
#if WINDOWS
	public static string getPrimaryFavoursUri =
		localhost + port + @"favours/primary";
#elif ANDROID
	public static string getPrimaryFavoursUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"favours/primary" :
		ngrokUri + @"favours/primary";

#endif
	#endregion

	#region GetSecondaryFavours
#if WINDOWS
	public static string getSecondaryFavoursUri =
		localhost + port + @"favours/secondary?id={0}";
#elif ANDROID
	public static string getSecondaryFavoursUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"favours/secondary?id={0}" :
		ngrokUri + @"favours/secondary?id={0}";

#endif
	#endregion

	#region SetNewPayment
#if WINDOWS
	public static string setNewPaymentUri =
		localhost + port + @"payCheck";
#elif ANDROID
	public static string setNewPaymentUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"payCheck" :
		ngrokUri + @"payCheck";

#endif
	#endregion

	#region GetCardsUriOnUserId
#if WINDOWS
	public static string getCardsUriOnUserId =
		localhost + port + @"cards/";
#elif ANDROID
	public static string getCardsUriOnUserId =
	(isNgrok == 0) ?
		emulatorhost + port + @"cards/" :
		ngrokUri + @"cards/";

#endif
	#endregion

	#region UpdateClient
#if WINDOWS
	public static string updateClientUri =
		localhost + port + @"clients/";
#elif ANDROID
	public static string updateClientUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"clients/" :
		ngrokUri + @"clients/";

#endif
	#endregion

	#region PayChecks
#if WINDOWS
	public static string payChecksOnBankAccIdUri =
		localhost + port + @"payChecks/bankAcc?id=";
#elif ANDROID
	public static string payChecksOnBankAccIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"payChecks/bankAcc?id=" :
		ngrokUri + @"payChecks/bankAcc?id=";

#endif
	#endregion

	#region GetOrganisationsOnFavourId
#if WINDOWS
	public static string getOrganisationsOnFavourIdUri =
		localhost + port + @"getOrganisationsOnFavourId?id=";
#elif ANDROID
	public static string getOrganisationsOnFavourIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"getOrganisationsOnFavourId?id=" :
		ngrokUri + @"getOrganisationsOnFavourId?id=";

#endif
	#endregion

}
