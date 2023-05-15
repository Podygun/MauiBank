namespace MauiBank;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("auth", typeof(AuthPage));
		Routing.RegisterRoute("main", typeof(MainPage));
		Routing.RegisterRoute("reg", typeof(RegPage));
		Routing.RegisterRoute("history", typeof(HistoryPage));
		Routing.RegisterRoute("carddetail", typeof(CardDetailPage));
		Routing.RegisterRoute("clientinfo", typeof(ClientInfoPage));
		Routing.RegisterRoute("payment", typeof(PaymentPage));
		Routing.RegisterRoute("cardtransfer", typeof(CardTransferPage));
		Routing.RegisterRoute("QR", typeof(QRPage));
		Routing.RegisterRoute("myQR", typeof(MyQRPage));
		Routing.RegisterRoute("scanQR", typeof(ScanQRPage));
		Routing.RegisterRoute("orgtransfer", typeof(OrganisationTransferPage));
		Routing.RegisterRoute("historydetail", typeof(HistoryDetailPage));
		Routing.RegisterRoute("allcards", typeof(AllCardsPage));
		Routing.RegisterRoute(nameof(OpenCardPage), typeof(OpenCardPage));


	}
}
