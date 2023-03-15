namespace MauiBank.View;

public partial class QRPage : ContentPage
{
	public QRPage(QRViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		//barCodeReader.IsDetecting = true;
		//barCodeReader.Options = new BarcodeReaderOptions
		//{
		//	Formats = BarcodeFormat.QrCode,
		//	Multiple = false,
		//	AutoRotate = true

		//};

	}





	private async void MyQrCodeTapped(object sender, TappedEventArgs e) => await Anim(MyQrCode);
	private async void ScanQrCodeTapped(object sender, TappedEventArgs e) => await Anim(ScanQrCode);


	private async Task Anim(VisualElement elem)
	{
		await elem.ScaleTo(0.9, 50);
		await elem.ScaleTo(1, 100);
	}

	//private void barCodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
	//{
	//	barCodeReader.IsDetecting = false;
	//	if (e.Results.Any())
	//	{
	//		var result = e.Results.FirstOrDefault();

	//		Dispatcher.Dispatch(async () =>
	//		{

	//			var navParam = new Dictionary<string, object>()
	//			{
	//				{"qrCodeResult", result.Value }
	//			};

	//			Trace.WriteLine(result.Value);
	//			//TODO
	//			await Shell.Current.GoToAsync("main", navParam);
	//		});
	//	}
	//}
}