using CommunityToolkit.Maui.Views;
namespace Toolkit;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await Application.Current.MainPage.ShowPopupAsync(new NewPopup());
	}
}

