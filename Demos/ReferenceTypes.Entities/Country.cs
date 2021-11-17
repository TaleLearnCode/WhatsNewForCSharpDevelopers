namespace TaleLearnCode.ReferenceTypes.Entities
{

	/// <summary>
	/// Represents a Country as defined by the ISO 3166-1 standard.
	/// </summary>
	public class Country
	{

		/// <summary>
		/// Gets or sets the ISO 3166-1 Alpha-2 code representing the Country.
		/// </summary>
		public string? Code { get; set; }

		/// <summary>
		/// Gets or sets the official state name of the Country.
		/// </summary>
		public string? Name { get; set; }

		/// <summary>
		/// Gets or sets the code of the World Region the Country is a part of.
		/// </summary>
		public string? WorldRegionCode { get; set; }

		/// <summary>
		/// Gets or sets the World Region the Country is a part of.
		/// </summary>
		public WorldRegion? WorldRegion { get; set; }

		/// <summary>
		/// Gets or sets the code of the World Subregion the Country is a part of.
		/// </summary>
		public string? WorldSubregionCode { get; set; }

		/// <summary>
		/// Gets or setts the World Subregion the Country is a part of.
		/// </summary>
		public WorldRegion? WorldSubregion { get; set; }

		/// <summary>
		/// Gets or sets an indication whether the Country has divisions (i.e. states, provinces, regions, etc.).
		/// </summary>
		/// <value><c>True</c> if the Country has divisions; otherwise, <c>false</c>.</value>
		public bool? HasDivisions { get; set; }

		/// <summary>
		/// Gets or sets the primary name for divisions within the Country.
		/// </summary>
		public string? DivisionName { get; set; }

		/// <summary>
		/// Gets or sets the list of Country Divisions that are a part of the Country.
		/// </summary>
		public IEnumerable<CountryDivision>? CountryDivisions { get; set; }

	}

}