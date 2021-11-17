namespace TaleLearnCode.ReferenceTypes.Entities;


/// <summary>
/// Represents a division of <see cref="Country"/> as defined by the ISO 3166-2 standard.
/// </summary>
public class CountryDivision
{

	/// <summary>
	/// Initializes a new instance of the <see cref="CountryDivision"/> type.
	/// </summary>
	/// <param name="countryCode">The code for the Country the Country Division is a part of.</param>
	/// <param name="countryDivisionCode">The code for the Country Division.</param>
	/// <param name="name">The name of the Country Division.</param>
	public CountryDivision(
		string countryCode,
		string countryDivisionCode,
		string name)
	{
		CountryCode = countryCode;
		CountryDivisionCode = countryDivisionCode;
		Name = name;
	}

	/// <summary>
	/// Gets or sets the code for the Country the Country Division is a part of.
	/// </summary>
	public string CountryCode { get; set; }

	/// <summary>
	/// Gets or sets the code for the Country Division.
	/// </summary>
	public string CountryDivisionCode { get; set; }

	/// <summary>
	/// Gets the code for the Country Division.
	/// </summary>
	public string Code { get { return $"{CountryCode}-{CountryDivisionCode}"; } }

	/// <summary>
	/// Gets or sets the name of the Country Division.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Gets or sets the name of the type of division the Country Division is.
	/// </summary>
	public string? DivisionName { get; set; }

	/// <summary>
	/// Gets or sets the ranking of the country division within the country by population.
	/// </summary>
	public int PopulationRank { get; set; }

	/// <summary>
	/// Gets or sets the Country the Country Division is a part of.
	/// </summary>
	public Country? Country { get; set; }

}