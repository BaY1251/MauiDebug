using CommunityToolkit.Maui.Views;
namespace Toolkit;

public partial class NewPopup : Popup
{
	public NewPopup()
	{
		InitializeComponent();
	}

	public async static Task Show()
	{
		var popup = new NewPopup();
		popup.Opened += (s, e) => Task.Delay(500).ContinueWith(s =>
		{
			Thread.Sleep(1000);
			MainThread.BeginInvokeOnMainThread(() => popup.Close());
		});

		await Shell.Current.ShowPopupAsync(popup);
	}
}