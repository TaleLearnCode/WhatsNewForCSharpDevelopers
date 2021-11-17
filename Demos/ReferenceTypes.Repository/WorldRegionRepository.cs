using TaleLearnCode.ReferenceTypes.Entities;

namespace TaleLearnCode.ReferenceTypes.Repository;

public class WorldRegionRepository : IWorldRegionRepository
{

	/// <summary>
	/// Retreives the list of <see cref="WorldRegion"/> from the data persistance layer.
	/// </summary>
	/// <returns>A <see cref="IEnumerable{WorldRegion}"/> representing the list of world regions.</returns>
	public IEnumerable<WorldRegion> Get()
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Retreives the specified <see cref="WorldRegion"/> from the data persistance layer.
	/// </summary>
	/// <param name="code">Code of the Worl dRegion to be retrievied.</param>
	/// <returns>A <see cref="WorldRegion" /> representing the specified World Region.</returns>`
	public WorldRegion Get(string code) => code switch
	{
		"019" => new()
		{
			Code = "019",
			Name = "Americas",
			Subregions = GetSubregions(code)
		},
		"021" => new()
		{
			Code = "021",
			Name = "Northern America",
			Subregions = GetSubregions(code),
			ParentCode = "019",
			Parent = Get("019")
		},
		"419" => new()
		{
			Code = "419",
			Name = "Latin America and the Caribbean",
			Subregions = GetSubregions(code),
			ParentCode = "019",
			Parent = Get("019")
		},
		_ => throw new NotImplementedException(),
	};

	/// <summary>
	/// Retreives the subregions of the specified World Region.
	/// </summary>
	/// <param name="code">Code the world region whose subregions are to be returned.</param>
	/// <returns>An <see cref="IEnumerable{WorldRegion}"/> representing the list of subregions for the specified world region.</returns>
	public IEnumerable<WorldRegion> GetSubregions(string code) => code switch
	{
		"019" => new List<WorldRegion>() { Get("021"), Get("419") },
		"021" => new List<WorldRegion>(),
		"419" => new List<WorldRegion>(),
		_ => throw new NotImplementedException(),
	};

	/// <summary>
	/// Adds the givien <see cref="WorldRegion"/> to the data persistance layer.
	/// </summary>
	/// <param name="WorldRegion">The <see cref="WorldRegion"/> to be added.</param>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	public void Add(WorldRegion WorldRegion)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Updates the given <see cref="WorldRegion"/> within the data persistance layer.
	/// </summary>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	/// <param name="WorldRegion"></param>
	public void Update(WorldRegion WorldRegion)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Removes the given <see cref="WorldRegion"/> from the data persistance layer.
	/// </summary>
	/// <param name="WorldRegion">Removes the given <see cref="WorldRegion"/> from the data persistance layer.</param>
	public void Remove(WorldRegion WorldRegion)
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