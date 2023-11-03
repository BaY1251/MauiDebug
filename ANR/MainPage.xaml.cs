﻿using System.Collections.ObjectModel;
namespace ANR;

public partial class MainPage : ContentPage
{
	public ObservableCollection<Item> ItemList { get; } = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		ItemList.Clear();
		for(int i = 0; i < 1000; i++)
		{
			ItemList.Add(new Item());
		}
	}
}

public class Item
{
	static int Count = 0;
	public string Name { get; set; } = $"{Count++}";
	public bool IsEnable { get; set; }
	public string Title { get; set; } = "Title";

	public ObservableCollection<SubItem> SubitemList { get; } = new ObservableCollection<SubItem> { new(), new(), new(), new(), new() };
}

public class SubItem
{
	public string Name { get; set; } = "SubItem";
	public string Description { get; set; } = "Description";
}

