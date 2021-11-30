// DateOnly Examples
NewDateOnlyType();
DateOnlyMath();
DateOnlyStringParsing();
DateOnlyStorage();

// TimeOnly Examples
NewTimeOnlyType();
TimeOnlyStorage();
TimeOnlyMath();
TimeOnlyRangeValidation();
TimeOnlyRangeValidation2();
TimeOnlyComparison();

#region DateOnly Examples

static void NewDateOnlyType()
{

	// Old Implementation
	DateTime oldBirthday = new(1971, 3, 12);
	Console.WriteLine(oldBirthday);
	// output: 3/12/1971 12:00:00 AM

	// New Implementation
	DateOnly newBirthday = new(1971, 3, 12);
	Console.WriteLine(newBirthday);
	// output: 3/12/1971

}

static void DateOnlyMath()
{
	DateOnly enlistmentDate = new(1990, 7, 2);
	DateOnly lastDayOfActiveDuty = enlistmentDate.AddYears(4).AddMonths(6);
	Console.WriteLine(lastDayOfActiveDuty);
	// output: 1/2/1995
}

static void DateOnlyStringParsing()
{
	if (DateOnly.TryParse("07/25/2003", out DateOnly result))
		Console.WriteLine(result);
	// output: 7/25/2003
}

static void DateOnlyStorage()
{

	DateOnly marineCorpsBirthday = new(1775, 11, 10);
	int dayNumber = marineCorpsBirthday.DayNumber;
	Console.WriteLine(dayNumber);
	// output: 648253

	// Military Julian Dates
	DateOnly firstDayOfYear = new(DateTime.Now.Year, 1, 1);
	DateOnly today = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
	Console.WriteLine($"{DateTime.Now.Year.ToString().Substring(2, 2)}{today.DayNumber - firstDayOfYear.DayNumber}");

}

#endregion

#region TimeOnly Examples

static void NewTimeOnlyType()
{

	// Old Implementation
	TimeSpan timeSpan = new(19, 0, 0);
	Console.WriteLine(timeSpan);
	// output: 19:00:00

	// New Implementation
	TimeOnly timeOnly = new(19, 0);
	Console.WriteLine(timeOnly);
	// output: 7:00 PM

}

static void TimeOnlyStorage()
{
	TimeOnly startTime = new(19, 0);
	Console.WriteLine(startTime.Ticks);
	// output: 684000000000
}

static void TimeOnlyMath()
{
	TimeOnly startTime = new(19, 0);
	TimeOnly endTime = new(20, 30);
	TimeSpan sessionLength = endTime - startTime;
	Console.WriteLine(sessionLength);
	// output: 01:30:00
}

static void TimeOnlyRangeValidation()
{

	TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
	TimeOnly workStart = new(7, 15);
	TimeOnly workEnd = new(18, 0);

	if (now.IsBetween(workStart, workEnd))
		Console.WriteLine("Time to make the donuts");
	else
		Console.WriteLine("It's Miller time");

}

static void TimeOnlyRangeValidation2()
{

	TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
	TimeOnly bedTime = new(23, 0);
	TimeOnly timeToWakeUp = new(6, 0);

	if (now.IsBetween(bedTime, timeToWakeUp))
		Console.WriteLine("Sleeping");
	else
		Console.WriteLine("Awake");

}

static void TimeOnlyComparison()
{
	TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
	if (now < new TimeOnly(12, 0))
		Console.WriteLine("Good Morning!");
	else if (now < new TimeOnly(18, 0))
		Console.WriteLine("Good Afternoon!");
	else
		Console.WriteLine("Good Evening!");
}

#endregion