using System.Runtime.CompilerServices;
using System.Text;

namespace _04_CSharpPart2
{

	[InterpolatedStringHandler]
	public ref struct LogInterpolatedStringHandler
	{
		// Storage for the built-up string
		StringBuilder builder;

		// Add the receiver argument:
		public LogInterpolatedStringHandler(int literalLength, int formattedCount)
		{
			builder = new StringBuilder(literalLength);
			Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
		}

		public void AppendLiteral(string s)
		{
			Console.WriteLine($"\tAppendLiteral called: {{{s}}}");

			builder.Append(s);
			Console.WriteLine($"\tAppended the literal string");
		}

		public void AppendFormatted<T>(T t)
		{
			Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");

			builder.Append(t?.ToString());
			Console.WriteLine($"\tAppended the formatted object");
		}

		internal string GetFormattedText() => builder.ToString();
	}

}