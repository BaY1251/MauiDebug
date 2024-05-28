using System.Collections.ObjectModel;

namespace BindingAdapterPositionException;

public partial class MainPage : ContentPage
{
	public ObservableCollection<string> ItemList { get; } = ["A", "B", "C", "D", "E", "F", "G", "H", "I",];
	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if(sender is CollectionView view && view.SelectedItem is string item)
		{
			ItemList.Remove(item);
		}
	}
}

