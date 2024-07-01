using System.ComponentModel;
namespace eferenceException_WeakEventProxy;

public partial class MainPage : ContentPage
{
	public int Count { get; set; }
	private readonly BackgroundWorker commTask = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
		commTask.DoWork += delegate
		{
			while(true)
			{
				Thread.Sleep(0);
				MainThread.InvokeOnMainThreadAsync(delegate
				{
					Count++;
					OnPropertyChanged(nameof(Count));
				}).Wait();
			}
		};
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		commTask.RunWorkerAsync();
	}
}

