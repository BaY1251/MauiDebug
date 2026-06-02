namespace Leak;

public partial class MainPage : ContentPage
{
	int countA = 0;
	private readonly SemaphoreSlim _semaphore = new(1, 1);
	private CancellationTokenSource? _cts;

	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		// 如果已经有正在运行的任务，就直接返回，防止重复启动
		if (_cts != null)
			return;
		_cts = new CancellationTokenSource();

		// 使用 async void 是因为这是由 MAUI 框架触发的生命周期事件
		_ = Task.Run(async () =>
		{
			Task? task = null;
			try
			{
				while (!_cts.Token.IsCancellationRequested)
				{
					bool hasLock = false;
					try
					{
						// WaitOne(0) 是非阻塞的，如果拿不到锁就立刻返回 false
						hasLock = _semaphore.Wait(0);
					}
					catch (ObjectDisposedException ex)
					{
						// 防止在极端情况下信号量已被释放导致的异常
						LabelB.Text = $"后台任务异常: {ex.Message}";
						break;
					}

					if (hasLock)
					{
						task?.Dispose();
						task = Task.Run(async () =>
						{
							try
							{
								await MainThread.InvokeOnMainThreadAsync(() =>
								{
									LabelA.Text = $"Clicked {countA++} times";
								});
							}
							finally
							{
								_semaphore.Release(); // 执行完释放许可
							}
						});

						await task; // 等待任务完成，确保 LabelA 更新后才继续循环
					}

					// 真正的异步等待，传入 Token 可以在 Cancel 时立刻响应退出
					await Task.Delay(10, _cts.Token);
				}
			}
			catch (OperationCanceledException)
			{
				LabelB.Text = $"正常的取消流程";
			}
			catch (Exception ex)
			{
				LabelB.Text = $"后台任务异常: {ex.Message}";
				System.Diagnostics.Debug.WriteLine($"后台任务异常: {ex.Message}");
			}
		}, _cts.Token);
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();

		// 发出取消信号，让 while 循环安全退出
		_cts?.Cancel();

		// 释放资源
		_cts?.Dispose();
		_cts = null;
	}
}
