using Microsoft.AspNetCore.SignalR.Client;
namespace Issue24710;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		HubConnection hub = new HubConnectionBuilder()
			.WithUrl("https://localhost:7141/chathub")
			.AddMessagePackProtocol()
			.Build();

		try
		{
			await hub.StartAsync();
		}
		catch(Exception x)
		{
			await Shell.Current.DisplayAlert("检索异常", x.Message, "OK");
		}
		finally
		{
			await hub.StopAsync();
		}
	}
}

