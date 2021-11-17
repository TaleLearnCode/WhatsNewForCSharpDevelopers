using TaleLearnCode.ReferenceTypes.Entities;

namespace TaleLearnCode.ReferenceTypes.Repository;

public interface ICountryDivisionRepository
{

	/// <summary>
	/// Retreives the list of <see cref="CountryDivision"/> from the data persistance layer.
	/// </summary>
	/// <param name="countryCode">Code of the Country whose divisions are to be returned.</param>
	/// <returns>A <see cref="IEnumerable{CountryDivision}"/> representing the list of country divisions.</returns>
	IEnumerable<CountryDivision> Get(string countryCode);

	/// <summary>
	/// Retreives the specified <see cref="CountryDivision"/> from the data persistance layer.
	/// </summary>
	/// <param name="countryCode">Code of the Country the Country Division to be retrieved is located in.</param>
	/// <param name="countryDivisionCode">Code of the Country Division to be retrievied.</param>
	/// <returns>A <see cref="CountryDivision" /> representing the specified Country Division.</returns>`
	CountryDivision Get(string countryCode, string countryDivisionCode);

	/// <summary>
	/// Adds the givien <see cref="CountryDivision"/> to the data persistance layer.
	/// </summary>
	/// <param name="CountryDivision">The <see cref="CountryDivision"/> to be added.</param>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	void Add(CountryDivision CountryDivision);

	/// <summary>
	/// Updates the given <see cref="CountryDivision"/> within the data persistance layer.
	/// </summary>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	/// <param name="CountryDivision"></param>
	void Update(CountryDivision CountryDivision);

	/// <summary>
	/// Removes the given <see cref="CountryDivision"/> from the data persistance layer.
	/// </summary>
	/// <param name="CountryDivision">Removes the given <see cref="CountryDivision"/> from the data persistance layer.</param>
	void Remove(CountryDivision CountryDivision);

	/// <summary>
	/// Saves all of the chagnes made in the context to the data persistance layer.
	/// </summary>
	void SaveChanges();

}