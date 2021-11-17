using TaleLearnCode.ReferenceTypes.Entities;

namespace TaleLearnCode.ReferenceTypes.Repository;

public interface IPostalAddressTypeRepository
{

	/// <summary>
	/// Retreives the list of <see cref="PostalAddressType"/> from the data persistance layer.
	/// </summary>
	/// <returns>A <see cref="IEnumerable{PostalAddressType}"/> representing the list of postal address types.</returns>
	IEnumerable<PostalAddressType> Get();

	/// <summary>
	/// Retreives the specified <see cref="PostalAddressType"/> from the data persistance layer.
	/// </summary>
	/// <param name="code">Code of the Postal Address Type to be retrievied.</param>
	/// <returns>A <see cref="PostalAddressType" /> representing the specified Postal Address Type.</returns>`
	PostalAddressType Get(string code);

	/// <summary>
	/// Adds the givien <see cref="PostalAddressType"/> to the data persistance layer.
	/// </summary>
	/// <param name="PostalAddressType">The <see cref="PostalAddressType"/> to be added.</param>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	void Add(PostalAddressType PostalAddressType);

	/// <summary>
	/// Updates the given <see cref="PostalAddressType"/> within the data persistance layer.
	/// </summary>
	/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
	/// <param name="PostalAddressType"></param>
	void Update(PostalAddressType PostalAddressType);

	/// <summary>
	/// Removes the given <see cref="PostalAddressType"/> from the data persistance layer.
	/// </summary>
	/// <param name="PostalAddressType">Removes the given <see cref="PostalAddressType"/> from the data persistance layer.</param>
	void Remove(PostalAddressType PostalAddressType);

	/// <summary>
	/// Saves all of the chagnes made in the context to the data persistance layer.
	/// </summary>
	void SaveChanges();

}