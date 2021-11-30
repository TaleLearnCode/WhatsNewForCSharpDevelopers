//ExtendedPropertyPatterns();
//AssignmentAndDeclarationInDifferentDeconstruction();
InterpolatedStringHandler();

static void ExtendedPropertyPatterns()
{

	object northernAmerica = new WorldRegion()
	{
		Code = "021",
		Name = "Northern America",
		ParentCode = "019",
		Parent = new()
		{
			Code = "019",
			Name = "Americas"
		}
	};

	// Pre-C# 10 syntax
	if (northernAmerica is WorldRegion { Parent: { Code: "019" } })
		Console.WriteLine("Americas");

	// Extended Property Patterns
	if (northernAmerica is WorldRegion { Parent.Code: "019" })
		Console.WriteLine("Americas");

}

static void AssignmentAndDeclarationInDifferentDeconstruction()
{
	int x2;
	int y2;
	(x2, y2) = (0, 1);        // Works in C# 9
	(var x, var y) = (0, 1);  // Works in C# 9
	(x2, var y3) = (0, 1);    // Works in C# 10 onwards
}

static void InterpolatedStringHandler()
{

	Logger? logger = new Logger() { EnabledLevel = LogLevel.Warning };
	var time = DateTime.UtcNow;

	logger.LogMessage(LogLevel.Error, $"Error Level. Current Time: {time}. This is an error.  It will be printed.");
	logger.LogMessage(LogLevel.Trace, $"Trace level. Current Time: {time}. This will not be printed.");
	logger.LogMessage(LogLevel.Warning, "Warning Level.  This warning is a string, not an interpolated string expression.");

}