using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Plugin.Fingerprint;

namespace MauiBank;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] { Intent.ActionView },
	Categories = new[]
	{
		Intent.ActionView,
		Intent.CategoryDefault,
		Intent.CategoryBrowsable
	},
	DataScheme = "https", 
	DataHost = "9b10-136-169-210-93.eu.ngrok.io", 
	DataPathPrefix = "/api",
	AutoVerify = true
	)
]
public class MainActivity : MauiAppCompatActivity
{
	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);

		CrossFingerprint.SetCurrentActivityResolver(() =>
		Platform.CurrentActivity);
		Intent intent = this.Intent;
		var action = intent.Action;
		var strLink = intent.DataString;
		if (Intent.ActionView == action && !string.IsNullOrWhiteSpace(strLink))
		{

			Toast.MakeText(this, strLink, ToastLength.Short).Show();
		}


	}
}
