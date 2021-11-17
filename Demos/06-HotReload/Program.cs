while (true)
	ShowOffHotReload();

static void ShowOffHotReload()
{
	Console.WriteLine($"Hello Louisville {System.Diagnostics.Process.GetCurrentProcess().Id}");
	Thread.Sleep(1000);
}