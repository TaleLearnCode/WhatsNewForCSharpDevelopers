namespace TaleLearnCode.WhatsNewForCSharpDevelopers.Demo01
{

	// Immutable record using positional parameters
	public record WorldRegion(string Code, string Name);

	// Immutable record using standartd property syntax
	public record Country
	{
		public string Code { get; set; }
		public string Name { get; init; } = default;
		public WorldRegion WorldRegion { get; init; } = default;
	}

	// Muttable record
	public record CountryDivision
	{
		public string CountryCode { get; set; }
		public string DivisionCode { get; set; }
		public string Name { get; set; }
		public Country Country { get; set; }
	}

}