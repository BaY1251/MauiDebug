using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PropertyInvalid;

public partial class MainPage : ContentPage
{
	public ByteList List { get; set; } = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void OnCounterClicked(object sender, EventArgs e) => List.Update();
}

public class ByteList : INotifyPropertyChanged
{
	/// <summary>
	/// 序列
	/// </summary>
	public List<byte> Core { get; } = [0x01];

	public void Update()
	{
		Core[0]++;
		OnPropertyChanged("Item");
	}

	/// <summary>
	/// 布尔值索引器
	/// </summary>
	public bool this[int i, int j]
	{
		get => (Core.ElementAtOrDefault(i) & (0x01 << j)) != 0;
		set
		{
			if(i < 0 || i > Core.Count || j < 0 || j >= 8)
				return;

			var val = 0x01 << j;
			Core[i] = (byte)(value ? Core[i] | val : Core[i] & ~val);
		}
	}


	/// <summary>
	/// 布尔值索引器
	/// </summary>
	public bool this[string index]
	{
		get
		{
			SplitIndex(index, out var i, out var j);
			while(Core.Count <= i)
			{
				Core.Add(0);
			}
			return this[i, j];
		}

		set
		{
			SplitIndex(index, out var i, out var j);
			this[i, j] = value;
		}
	}

	private static void SplitIndex(string index, out int i, out int j)
	{
		var parts = index.Split('-');
		if(parts.Length >= 2)
		{
			i = int.Parse(parts[0]);
			j = int.Parse(parts[1]);
		}
		else
		{
			i = 0;
			j = 0;
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

