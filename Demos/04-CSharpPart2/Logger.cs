namespace _04_CSharpPart2
{

	public enum LogLevel
	{
		Off,
		Critical,
		Error,
		Warning,
		Information,
		Trace
	}


	public class Logger
	{

		public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

		public void LogMessage(LogLevel logLevel, string message)
		{
			if (EnabledLevel < logLevel) return;
			Console.WriteLine(message);
		}

		public void LogMessage(LogLevel logLevel, LogInterpolatedStringHandler builder)
		{
			if (EnabledLevel < logLevel) return;
			Console.WriteLine(builder.GetFormattedText());
		}

	}

}