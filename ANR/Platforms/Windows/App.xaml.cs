﻿// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.UI;
using Microsoft.UI.Windowing;

namespace ANR.WinUI;
/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
	/// <summary>
	/// Initializes the singleton application object.  This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public App()
	{
		this.InitializeComponent();

		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		{
			var mauiWindow = handler.VirtualView;
			var nativeWindow = handler.PlatformView;
			IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
			WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
			AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			nativeWindow.ExtendsContentIntoTitleBar = false;
			appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
		});

	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

