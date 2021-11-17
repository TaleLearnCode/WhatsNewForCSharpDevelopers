using TaleLearnCode.ReferenceTypes.Entities;

namespace TaleLearnCode.ReferenceTypes.Repository;

public interface ICountryRepository
{

	/// <summary>
	/// Retreives the list of <see cref="Country"/> from the data persistance layer.
	/// </summary>
	/// <returns>A <see cref="IEnumerable{Country}"/> representing the list of countries.</returns>
	IEnumerable<Country> Get();

	/// <summary>
	/// Retreives the specified <see cref="Country"/> from the data persistance layer.
	/// </summary>
	/// <param name="code">Code of the country to be retrievied.</param>
	/// <returns>A <see cref="Country" /> representing the specified country.</returns>`
	Country Get(string code);

	/// <summary>
	/// Adds the givien <see cref="Country"/> to the data persistance layer.
	/// </summary>
	/// <param name="country">The <see cref="Country"/> to be added.</param>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	void Add(Country country);

	/// <summary>
	/// Updates the given <see cref="Country"/> within the data persistance layer.
	/// </summary>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	/// <param name="country"></param>
	void Update(Country country);

	/// <summary>
	/// Removes the given <see cref="Country"/> from the data persistance layer.
	/// </summary>
	/// <param name="country">Removes the given <see cref="Country"/> from the data persistance layer.</param>
	void Remove(Country country);

	/// <summary>
	/// Saves all of the chagnes made in the context to the data persistance layer.
	/// </summary>
	void SaveChanges();

}