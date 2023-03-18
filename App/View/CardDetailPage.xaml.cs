namespace MauiBank.View;

public partial class CardDetailPage : ContentPage
{
	public CardDetailPage(CardDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		Loaded += CardDetailPage_Loaded;
	}



	#region CopyToClipboard
	private async void CopyNumber(object sender, TappedEventArgs e) =>
	await Clipboard.Default.SetTextAsync(LblNumber.Text);

	private async void CopyCvv(object sender, TappedEventArgs e) =>
		await Clipboard.Default.SetTextAsync(LblCvv.Text);

	private async void CopyName(object sender, TappedEventArgs e) =>
		await Clipboard.Default.SetTextAsync(LblName.Text);





	#endregion

	private async void CardDetailPage_Loaded(object sender, EventArgs e)
	{
		await lbl.ScaleTo(2, 2000, Easing.CubicInOut);
		await lbl.ScaleTo(1, 2000, Easing.CubicInOut);
	}
}