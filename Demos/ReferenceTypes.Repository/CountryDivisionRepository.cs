using TaleLearnCode.ReferenceTypes.Entities;

namespace TaleLearnCode.ReferenceTypes.Repository;

public class CountryDivisionRepository : ICountryDivisionRepository
{

	/// <summary>
	/// Retreives the list of <see cref="CountryDivision"/> from the data persistance layer.
	/// </summary>
	/// <param name="countryCode">Code of the Country whose divisions are to be returned.</param>
	/// <returns>A <see cref="IEnumerable{CountryDivision}"/> representing the list of country divisions.</returns>
	public IEnumerable<CountryDivision> Get(string countryCode)
	{
		if (countryCode is null) throw new ArgumentNullException(nameof(countryCode));
		return countryCode switch
		{
			"US" => new List<CountryDivision>()
				{
					Get("US", "AL"),
					Get("US", "AK"),
					Get("US", "AZ"),
					Get("US", "AR"),
					Get("US", "CA"),
					Get("US", "CO"),
					Get("US", "CT"),
					Get("US", "DE"),
					Get("US", "FL"),
					Get("US", "GA"),
					Get("US", "HI"),
					Get("US", "ID"),
					Get("US", "IL"),
					Get("US", "IN"),
					Get("US", "IA"),
					Get("US", "KS"),
					Get("US", "KY"),
					Get("US", "LA"),
					Get("US", "ME"),
					Get("US", "MD"),
					Get("US", "MA"),
					Get("US", "MI"),
					Get("US", "MN"),
					Get("US", "MS"),
					Get("US", "MO"),
					Get("US", "MT"),
					Get("US", "NE"),
					Get("US", "NV"),
					Get("US", "NH"),
					Get("US", "NJ"),
					Get("US", "NM"),
					Get("US", "NY"),
					Get("US", "NC"),
					Get("US", "ND"),
					Get("US", "OH"),
					Get("US", "OK"),
					Get("US", "OR"),
					Get("US", "PA"),
					Get("US", "RI"),
					Get("US", "SC"),
					Get("US", "SD"),
					Get("US", "TN"),
					Get("US", "TX"),
					Get("US", "UT"),
					Get("US", "VT"),
					Get("US", "VA"),
					Get("US", "WA"),
					Get("US", "WV"),
					Get("US", "WI"),
					Get("US", "WY"),
					Get("US", "DC"),
					Get("US", "AS"),
					Get("US", "GU"),
					Get("US", "MP"),
					Get("US", "PR"),
					Get("US", "UM"),
					Get("US", "VI")
				},
			_ => new List<CountryDivision>()
		};
	}

	/// <summary>
	/// Retreives the specified <see cref="CountryDivision"/> from the data persistance layer.
	/// </summary>
	/// <param name="countryCode">Code of the Country the Country Division to be retrieved is located in.</param>
	/// <param name="countryDivisionCode">Code of the Country Division to be retrievied.</param>
	/// <returns>A <see cref="CountryDivision" /> representing the specified Country Division.</returns>`
	public CountryDivision Get(string countryCode, string countryDivisionCode)
	{

		if (countryCode is null) throw new ArgumentNullException(nameof(countryCode));
		if (countryDivisionCode is null) throw new ArgumentNullException(nameof(countryDivisionCode));

		if (countryCode.ToUpper() == "US")
		{
			return countryDivisionCode.ToUpper() switch
			{
				"AL" => new("US", "AL", "Alabama") { DivisionName = "state", PopulationRank = 24 },
				"AK" => new("US", "AK", "Alaska") { DivisionName = "state", PopulationRank = 49 },
				"AZ" => new("US", "AZ", "Arizona") { DivisionName = "state", PopulationRank = 14 },
				"AR" => new("US", "AR", "Arkansas") { DivisionName = "state", PopulationRank = 34 },
				"CA" => new("US", "CA", "California") { DivisionName = "state", PopulationRank = 1 },
				"CO" => new("US", "CO", "Colorado") { DivisionName = "state", PopulationRank = 20 },
				"CT" => new("US", "CT", "Connecticut") { DivisionName = "state", PopulationRank = 29 },
				"DE" => new("US", "DE", "Delaware") { DivisionName = "state", PopulationRank = 46 },
				"FL" => new("US", "FL", "Florida") { DivisionName = "state", PopulationRank = 3 },
				"GA" => new("US", "GA", "Georgia") { DivisionName = "state", PopulationRank = 8 },
				"HI" => new("US", "HI", "Hawaii") { DivisionName = "state", PopulationRank = 41 },
				"ID" => new("US", "ID", "Idaho") { DivisionName = "state", PopulationRank = 39 },
				"IL" => new("US", "IL", "Illinois") { DivisionName = "state", PopulationRank = 6 },
				"IN" => new("US", "IN", "Indiana") { DivisionName = "state", PopulationRank = 17 },
				"IA" => new("US", "IA", "Iowa") { DivisionName = "state", PopulationRank = 33 },
				"KS" => new("US", "KS", "Kansas") { DivisionName = "state", PopulationRank = 36 },
				"KY" => new("US", "KY", "Kentucky") { DivisionName = "state", PopulationRank = 26 },
				"LA" => new("US", "LA", "Louisiana") { DivisionName = "state", PopulationRank = 25 },
				"ME" => new("US", "ME", "Maine") { DivisionName = "state", PopulationRank = 43 },
				"MD" => new("US", "MD", "Maryland") { DivisionName = "state", PopulationRank = 19 },
				"MA" => new("US", "MA", "Massachusetts") { DivisionName = "state", PopulationRank = 16 },
				"MI" => new("US", "MI", "Michigan") { DivisionName = "state", PopulationRank = 10 },
				"MN" => new("US", "MN", "Minnesota") { DivisionName = "state", PopulationRank = 22 },
				"MS" => new("US", "MS", "Mississippi") { DivisionName = "state", PopulationRank = 35 },
				"MO" => new("US", "MO", "Missouri") { DivisionName = "state", PopulationRank = 18 },
				"MT" => new("US", "MT", "Montana") { DivisionName = "state", PopulationRank = 44 },
				"NE" => new("US", "NE", "Nebraska") { DivisionName = "state", PopulationRank = 38 },
				"NV" => new("US", "NV", "Nevada") { DivisionName = "state", PopulationRank = 32 },
				"NH" => new("US", "NH", "New Hampshire") { DivisionName = "state", PopulationRank = 42 },
				"NJ" => new("US", "NJ", "New Jersey") { DivisionName = "state", PopulationRank = 11 },
				"NM" => new("US", "NM", "New Mexico") { DivisionName = "state", PopulationRank = 37 },
				"NY" => new("US", "NY", "New York") { DivisionName = "state", PopulationRank = 4 },
				"NC" => new("US", "NC", "North Carolina") { DivisionName = "state", PopulationRank = 9 },
				"ND" => new("US", "ND", "North Dakota") { DivisionName = "state", PopulationRank = 48 },
				"OH" => new("US", "OH", "Ohio") { DivisionName = "state", PopulationRank = 7 },
				"OK" => new("US", "OK", "Okalahoma") { DivisionName = "state", PopulationRank = 28 },
				"OR" => new("US", "OR", "Oregon") { DivisionName = "state", PopulationRank = 27 },
				"PA" => new("US", "PA", "Pennslyvania") { DivisionName = "state", PopulationRank = 5 },
				"RI" => new("US", "RI", "Rhode Island") { DivisionName = "state", PopulationRank = 45 },
				"SC" => new("US", "SC", "South Carolina") { DivisionName = "state", PopulationRank = 23 },
				"SD" => new("US", "SD", "South Dakota") { DivisionName = "state", PopulationRank = 47 },
				"TN" => new("US", "TN", "Tennessee") { DivisionName = "state", PopulationRank = 15 },
				"TX" => new("US", "TX", "Texas") { DivisionName = "state", PopulationRank = 2 },
				"UT" => new("US", "UT", "Utah") { DivisionName = "state", PopulationRank = 30 },
				"VT" => new("US", "VT", "Vermont") { DivisionName = "state", PopulationRank = 51 },
				"VA" => new("US", "VA", "Virginia") { DivisionName = "state", PopulationRank = 12 },
				"WA" => new("US", "WA", "Washington") { DivisionName = "state", PopulationRank = 13 },
				"WV" => new("US", "WV", "West Virgina") { DivisionName = "state", PopulationRank = 40 },
				"WI" => new("US", "WI", "Wisconsin") { DivisionName = "state", PopulationRank = 21 },
				"WY" => new("US", "WY", "Wyoming") { DivisionName = "state", PopulationRank = 52 },
				"DC" => new("US", "DC", "Distict of Columbia") { DivisionName = "district", PopulationRank = 50 },
				"AS" => new("US", "AS", "American Samoa") { DivisionName = "outlying area", PopulationRank = 55 },
				"GU" => new("US", "GU", "Guam") { DivisionName = "outlying area", PopulationRank = 53 },
				"MP" => new("US", "MP", "Northern Mariana Islands") { DivisionName = "outlying area", PopulationRank = 55 },
				"PR" => new("US", "PR", "Puerto Rico") { DivisionName = "outlying area", PopulationRank = 31 },
				"UM" => new("US", "UM", "United Sates Minor Outlying Islands") { DivisionName = "outlying area", PopulationRank = 56 },
				"VI" => new("US", "VI", "U.S. Virgin Islands") { DivisionName = "outlying area", PopulationRank = 54 },
				_ => throw new NotImplementedException(),
			};
		}
		else
			throw new NotImplementedException();
	}

	public IEnumerable<string> GetNames(string countryCode)
	{
		List<string> response = new();
		IEnumerable<CountryDivision> countryDivisions = Get(countryCode);
		if (countryDivisions is not null && countryDivisions.Any())
			foreach (CountryDivision countryDivision in countryDivisions)
				response.Add(countryDivision.Name);
		return response;
	}

	/// <summary>
	/// Adds the givien <see cref="CountryDivision"/> to the data persistance layer.
	/// </summary>
	/// <param name="CountryDivision">The <see cref="CountryDivision"/> to be added.</param>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	public void Add(CountryDivision CountryDivision)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Updates the given <see cref="CountryDivision"/> within the data persistance layer.
	/// </summary>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	/// <param name="CountryDivision"></param>
	public void Update(CountryDivision CountryDivision)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Removes the given <see cref="CountryDivision"/> from the data persistance layer.
	/// </summary>
	/// <param name="CountryDivision">Removes the given <see cref="CountryDivision"/> from the data persistance layer.</param>
	public void Remove(CountryDivision CountryDivision)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Saves all of the chagnes made in the context to the data persistance layer.
	/// </summary>
	public void SaveChanges()
	{
		throw new NotImplementedException();
	}

}