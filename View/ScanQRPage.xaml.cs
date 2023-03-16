using ZXing.Net.Maui;

namespace MauiBank.View;

public partial class ScanQRPage : ContentPage
{
	ScanQRViewModel viewmodel;
	private string QRData = string.Empty;
	
	public ScanQRPage(ScanQRViewModel vm)
	{
		InitializeComponent();
		BindingContext = viewmodel =vm;
		QRCodeReader.Options = new BarcodeReaderOptions
		{
			Formats = BarcodeFormat.QrCode,
			AutoRotate = true,
			Multiple = false
		};
		EntryBtn.FadeTo(0,0);
		DoneImage.FadeTo(0,0);
	}

	private async void QRCodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
	{
		QRCodeReader.IsDetecting = false;

		if (e.Results.Any())
		{
			await AnimateDone();
			var result = e.Results.FirstOrDefault();
			Trace.WriteLine(result.Value);
			QRData = result.Value;

		}
	}

	private async Task AnimateDone()
	{
		var animations = new List<Task>();
		animations.Add(DoneImage.FadeTo(1, 1000, Easing.CubicInOut));
		animations.Add(EntryBtn.FadeTo(1, 1000, Easing.CubicInOut));
		await Task.WhenAll(animations);
	}


	private async Task EntryBtn_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("cardtransfer", new Dictionary<string, object>
		{

		});
	}

}