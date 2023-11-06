using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
namespace Data
{
	public class Model : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// 更新属性
		/// </summary>
		/// <param name="propertyName">属性名</param>
		public void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public int Time { get; set; }
		public ObservableCollection<Item> ItemList { get; } = new ObservableCollection<Item>();

		public Command RefreshCommand { get; }

		public void Refresh()
		{
			var tick = Environment.TickCount;
			ItemList.Clear();
			for(int i = 0; i < 10000; i++)
			{
				ItemList.Add(new Item());
			}

			Time = Environment.TickCount - tick;
			OnPropertyChanged(nameof(Time));
		}

		public Model()
		{
			RefreshCommand = new Command(Refresh);
		}
	}

	public class Item
	{
		static int Count = 0;
		public string Name { get; set; } = $"{Count++}";
		public bool IsEnable { get; set; }
		public string Title { get; set; } = "Title";

		public ObservableCollection<SubItem> SubitemList { get; } = new ObservableCollection<SubItem> { new SubItem(), new SubItem(), new SubItem(), new SubItem(), new SubItem() };
	}

	public class SubItem
	{
		public string Name { get; set; } = "SubItem";
		public string Description { get; set; } = "Description";
	}
}