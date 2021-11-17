using TaleLearnCode.ReferenceTypes.Entities;

namespace TaleLearnCode.ReferenceTypes.Repository
{

	public class CountryRepository : ICountryRepository
	{

		/// <summary>
		/// Retreives the list of <see cref="Country"/> from the data persistance layer.
		/// </summary>
		/// <returns>A <see cref="IEnumerable{Country}"/> representing the list of countries.</returns>
		public IEnumerable<Country> Get()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retreives the specified <see cref="Country"/> from the data persistance layer.
		/// </summary>
		/// <param name="code">Code of the country to be retrievied.</param>
		/// <returns>A <see cref="Country" /> representing the specified country.</returns>`
		public Country Get(string code) => code.ToUpper() switch
		{
			"US" => new()
			{
				Code = "US",
				Name = "United States of America",
				WorldRegionCode = "019",
				WorldSubregionCode = "021",
				HasDivisions = true,
				DivisionName = "state"
			},
			_ => throw new NotImplementedException(),
		};

		/// <summary>
		/// Adds the givien <see cref="Country"/> to the data persistance layer.
		/// </summary>
		/// <param name="country">The <see cref="Country"/> to be added.</param>
		/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
		public void Add(Country country)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Updates the given <see cref="Country"/> within the data persistance layer.
		/// </summary>
		/// <remarks>Depending on data persistance layer, the <see cref="SaveChanges"/> method might need to be called to affect the addition.</remarks>
		/// <param name="country"></param>
		public void Update(Country country)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes the given <see cref="Country"/> from the data persistance layer.
		/// </summary>
		/// <param name="country">Removes the given <see cref="Country"/> from the data persistance layer.</param>
		public void Remove(Country country)
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

		[Obsolete($"Call {nameof(SaveChanges)} instead")]
		public void OldSaveChanges()
		{
			throw new NotImplementedException();
		}

	}

}