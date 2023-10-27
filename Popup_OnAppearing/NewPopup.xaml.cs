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
		popup.Opened += (s, e) => Task.Delay(800).ContinueWith(s =>
		{
			//action?.Invoke();
			Thread.Sleep(500);
			MainThread.BeginInvokeOnMainThread(() => popup.Close());
		});

		await Shell.Current.CurrentPage.ShowPopupAsync(popup);
	}
}