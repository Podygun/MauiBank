namespace MauiBank.HTTP;


public static class Routes
{
	private const short isNgrok = 0;
	private const string ngrokUri = @"https://de9b-136-169-210-76.ngrok-free.app/api/";
	
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
		emulatorhost + port + @"valutes/" :
		ngrokUri + @"valutes/";
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

	#region ShortPayChecks
#if WINDOWS
	public static string getShortPayChecks =
		localhost + port + @"payChecks/short?id=";
#elif ANDROID
	public static string getShortPayChecks =
	(isNgrok == 0) ?
		emulatorhost + port + @"payChecks/short?id=" :
		ngrokUri + @"payChecks/short?id=";

#endif
	#endregion

	#region FullPayChecks
#if WINDOWS
	public static string getFullPayChecks =
		localhost + port + @"payChecks/getAllFields?id=";
#elif ANDROID
	public static string getFullPayChecks =
	(isNgrok == 0) ?
		emulatorhost + port + @"payChecks/getAllFields?id=" :
		ngrokUri + @"payChecks/getAllFields?id=";

#endif
	#endregion

	#region GetOrganisationsOnFavourId
#if WINDOWS
	public static string getOrganisationsOnFavourIdUri =
		localhost + port + @"organisations/getOrganisationsOnFavourId?id=";
#elif ANDROID
	public static string getOrganisationsOnFavourIdUri =
	(isNgrok == 0) ?
		emulatorhost + port + @"organisations/getOrganisationsOnFavourId?id=" :
		ngrokUri + @"organisations/getOrganisationsOnFavourId?id=";

#endif
	#endregion

	#region GetRequisitesOnOrganisationId
#if WINDOWS
	public static string getRequisitesOnOrganisationId =
		localhost + port + @"listRequisites/getOnOrganisationId?id=";
#elif ANDROID
	public static string getRequisitesOnOrganisationId =
	(isNgrok == 0) ?
		emulatorhost + port + @"listRequisites/getOnOrganisationId?id=" :
		ngrokUri + @"listRequisites/getOnOrganisationId?id=";

#endif
	#endregion

	#region GetCardOnNumber
#if WINDOWS
	public static string getCardOnNumber =
		localhost + port + @"cards/getByNumber?number={0}";
#elif ANDROID
	public static string getCardOnNumber =
	(isNgrok == 0) ?
		emulatorhost + port + @"cards/getByNumber?number={0}" :
		ngrokUri + @"cards/getByNumber?number={0}";
#endif
	#endregion

	#region GetCardTypes
#if WINDOWS
	public static string getCardTypes =
		localhost + port + @"card_types/";
#elif ANDROID
	public static string getCardTypes =
	(isNgrok == 0) ?
		emulatorhost + port + @"card_types/" :
		ngrokUri + @"card_types/";
#endif
	#endregion

	#region PostBankAccount
#if WINDOWS
	public static string postBankAccount =
		localhost + port + @"bank_accounts/";
#elif ANDROID
	public static string postBankAccount =
	(isNgrok == 0) ?
		emulatorhost + port + @"bank_accounts/" :
		ngrokUri + @"bank_accounts/";
#endif
	#endregion
}
