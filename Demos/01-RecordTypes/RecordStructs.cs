namespace TaleLearnCode.WhatsNewForCSharpDevelopers.Demo01
{

	/* ----------------------------------------------------------------------
	 * C# 10 - Immutable record struct using positional parameters
	 * ---------------------------------------------------------------------- */

	public readonly record struct Point1(double X, double Y, double Z);

	/* ----------------------------------------------------------------------
	 * C# 10 - Immutable record struct using standard property syntax
	 * ---------------------------------------------------------------------- */

	public record struct Point2
	{
		public double X { get; init; }
		public double Y { get; init; }
		public double Z { get; init; }
	}






	/* ----------------------------------------------------------------------
	 * C# 10 - Mutable record struct using positional parameters
	 * ---------------------------------------------------------------------- */

	public record struct Point3(double X, double Y, double Z);

	/* ----------------------------------------------------------------------
	 * C# 10 - Mutable record struct using standard property syntax
	 * ---------------------------------------------------------------------- */

	public record struct Point4
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

	}

}