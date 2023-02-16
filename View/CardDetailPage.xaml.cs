namespace MauiBank.View;

public partial class CardDetailPage : ContentPage
{
	public CardDetailPage(CardDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private async void CopyNumber(object sender, TappedEventArgs e) =>
		await Clipboard.Default.SetTextAsync(LblNumber.Text);


	private async void CopyCvv(object sender, TappedEventArgs e) =>
		await Clipboard.Default.SetTextAsync(LblCvv.Text);

	private async void CopyName(object sender, TappedEventArgs e) =>
		await Clipboard.Default.SetTextAsync(LblName.Text);

	


}