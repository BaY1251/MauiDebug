using CommunityToolkit.Maui.Views;
namespace Toolkit;

public partial class NewPopup : Popup
{
	private static NewPopup popup = null;
	public NewPopup()
	{
		InitializeComponent();
		Opened += (s, e) => Task.Delay(800).ContinueWith(s =>
		{
			MainThread.BeginInvokeOnMainThread(() => popup.Close());
		});
	}

	public async static Task Show()
	{
		popup ??= new NewPopup();
		await Shell.Current.CurrentPage.ShowPopupAsync(popup);
		await Shell.Current.CurrentPage.ShowPopupAsync(popup);
		await Shell.Current.CurrentPage.ShowPopupAsync(popup);
	}
}