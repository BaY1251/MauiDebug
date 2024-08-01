namespace ToolkitIssue2071;

public partial class MainPage : ContentPage
{
	public List<string>? ItemList { get; set; } = ["A", "B", "C", "D", "E", "F", "G", "H", "I",];

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		ItemList = null;
		OnPropertyChanged(nameof(ItemList));
	}
}

