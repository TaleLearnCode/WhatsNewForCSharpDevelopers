using TaleLearnCode.ReferenceTypes.Entities;

namespace TaleLearnCode.ReferenceTypes.Repository;

public interface IWorldRegionRepository
{

	/// <summary>
	/// Retreives the list of <see cref="WorldRegion"/> from the data persistance layer.
	/// </summary>
	/// <returns>A <see cref="IEnumerable{WorldRegion}"/> representing the list of world regions.</returns>
	IEnumerable<WorldRegion> Get();

	/// <summary>
	/// Retreives the specified <see cref="WorldRegion"/> from the data persistance layer.
	/// </summary>
	/// <param name="code">Code of the Worl dRegion to be retrievied.</param>
	/// <returns>A <see cref="WorldRegion" /> representing the specified World Region.</returns>`
	WorldRegion Get(string code);

	/// <summary>
	/// Retreives the subregions of the specified World Region.
	/// </summary>
	/// <param name="code">Code the world region whose subregions are to be returned.</param>
	/// <returns>An <see cref="IEnumerable{WorldRegion}"/> representing the list of subregions for the specified world region.</returns>
	IEnumerable<WorldRegion> GetSubregions(string code);

	/// <summary>
	/// Adds the givien <see cref="WorldRegion"/> to the data persistance layer.
	/// </summary>
	/// <param name="WorldRegion">The <see cref="WorldRegion"/> to be added.</param>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	void Add(WorldRegion WorldRegion);

	/// <summary>
	/// Updates the given <see cref="WorldRegion"/> within the data persistance layer.
	/// </summary>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	/// <param name="WorldRegion"></param>
	void Update(WorldRegion WorldRegion);

	/// <summary>
	/// Removes the given <see cref="WorldRegion"/> from the data persistance layer.
	/// </summary>
	/// <param name="WorldRegion">Removes the given <see cref="WorldRegion"/> from the data persistance layer.</param>
	void Remove(WorldRegion WorldRegion);

	/// <summary>
	/// Saves all of the chagnes made in the context to the data persistance layer.
	/// </summary>
	void SaveChanges();

}