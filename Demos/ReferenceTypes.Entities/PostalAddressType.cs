namespace TaleLearnCode.ReferenceTypes.Entities
{

	/// <summary>
	/// Represents a type of a postal address.
	/// </summary>
	public class PostalAddressType
	{

		/// <summary>
		/// Gets or sets the identifier of the Postal Address Type.
		/// </summary>
		public int Id { get; init; }

		/// <summary>
		/// Gets or sets the name of the Postal Address Type.
		/// </summary>
		public string? Name { get; set; }

		/// <summary>
		/// Gets or sets the sorting order of the Postal Address Type.
		/// </summary>
		public int? SortOrder { get; init; }

	}

}