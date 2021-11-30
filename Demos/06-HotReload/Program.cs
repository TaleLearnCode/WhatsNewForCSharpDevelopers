while (true)
	ShowOffHotReload("Hey");

static void ShowOffHotReload(string doesThisWork)
{
	Console.WriteLine($"Hello Louisville .NET {System.Diagnostics.Process.GetCurrentProcess().Id}");
	Thread.Sleep(1000);
}