namespace MauiBank.View;


public partial class MainPage : ContentPage
{
	MainViewModel viewmodel;
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		
		BindingContext = viewmodel = vm;

		Loaded += MainPage_Loaded;
	}

	private async void MainPage_Loaded(object sender, EventArgs e)
	{
		_ = StartAnimation();
	}

	private async Task StartAnimation()
	{
		await cardBlock.FadeTo(0, 0);
		await balanceBlock.FadeTo(0, 0);
		await btnsBlock.FadeTo(0, 0);

		await Task.Delay(200);
		var animations = new List<Task>();
		await cardBlock.TranslateTo(0, -75, 0);		
		await btnsBlock.TranslateTo(0, 75, 0);

		animations.Add(cardBlock.TranslateTo(0, 0, 1000, Easing.CubicOut));
		animations.Add(btnsBlock.TranslateTo(0, 0, 1000, Easing.CubicOut));
		animations.Add(balanceBlock.FadeTo(1,3000, Easing.CubicInOut));
		animations.Add(cardBlock.FadeTo(1,500, Easing.CubicInOut));
		animations.Add(btnsBlock.FadeTo(1,500, Easing.CubicInOut));

		await Task.WhenAll(animations);
	}

	private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) => viewmodel.GoToCardDetailCommand.Execute(null);
    
	private async void TapHistory(object sender, TappedEventArgs e)		=> await Anim(history);
	private async void TapQR(object sender, TappedEventArgs e)			=> await Anim(QR);
	private async void TapUserInfo(object sender, TappedEventArgs e)	=> await Anim(UserInfo);
	private async void TapNewCard(object sender, TappedEventArgs e)		=> await Anim(NewCard);
	private async void TapAuth(object sender, TappedEventArgs e)		=> await Anim(Auth);
	private async void TapPay(object sender, TappedEventArgs e)			=> await Anim(Pay);


	private async Task Anim(VisualElement elem)
	{
		await elem.ScaleTo(0.9, 50);
		await elem.ScaleTo(1, 100);
	}

	
}

