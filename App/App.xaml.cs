//using Microsoft.UI;
//using Microsoft.UI.Windowing;
//using Windows.Graphics;

namespace MauiBank;

public partial class App : Application
{
	const int WindowWidth = 533;
	const int WindowHeight = 1152;
	public App()
	{
		InitializeComponent();

//#if ANDROID
//		Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping("NoUnderline", (h, v) =>
//		{
//			h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
//		});
//#endif


		//		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		//		{
		//#if WINDOWS
		//			var mauiWindow = handler.VirtualView;
		//			var nativeWindow = handler.PlatformView;
		//			nativeWindow.Activate();
		//			IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
		//			WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
		//			AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
		//			appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
		//#endif
		//		});
		MainPage = new AppShell();
		Resources.MergedDictionaries.Add(new Resources.Styles.ColorsNew());
	}
}
