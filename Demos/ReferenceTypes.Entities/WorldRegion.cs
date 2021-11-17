namespace TaleLearnCode.ReferenceTypes.Entities;


/// <summary>
/// Represents a world division as defined by the United Nations M49 standard.
/// </summary>
public class WorldRegion
{

	/// <summary>
	/// Gets or sets the code of the World Region as defined by the UN M49 standard.
	/// </summary>
	public string? Code { get; set; }

	/// <summary>
	/// Gets the name of the World region as defined by the UN M49 standard.
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Gets ors sets the code of the World Region's parent.
	/// </summary>
	public string? ParentCode { get; set; }

	/// <summary>
	/// Gets or sets the World Region's parent.
	/// </summary>
	public WorldRegion? Parent { get; set; }

	/// <summary>
	/// Gets or sets the World Region's subregions (children).
	/// </summary>
	public IEnumerable<WorldRegion>? Subregions { get; set; }

}