namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.PreConventionModelConfiguration;

internal static class PreConventionModelConfigurationSample
{


	public static void Execute()
	{
		Console.WriteLine($">>>> Sample: {nameof(PreConventionModelConfigurationSample)}");
		Console.WriteLine();

		RecreateCleanDatabase();
		PopulateDatabase();

		using var context = new CustomersContext();

		Console.WriteLine();
	}

	private static void RecreateCleanDatabase()
	{
		using var context = new CustomersContext(quiet: true);

		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}

	private static void PopulateDatabase()
	{
		using var context = new CustomersContext(quiet: true);

		context.AddRange(
				new Customer
				{
					Name = "Arthur",
					IsActive = true,
					AccountValue = new Money(1090.0m, Currency.PoundsSterling),
					Orders =
						{
												new()
												{
														OrderDate = new DateTime(2021, 7, 31),
														Price = new Money(29.0m, Currency.PoundsSterling),
														Discount = new Money(5.0m, Currency.PoundsSterling)
												}
						}
				},
				new Customer
				{
					Name = "Alan",
					AccountValue = new Money(0.0m, Currency.UsDollars),
					Orders =
						{
												new()
												{
														OrderDate = new DateTime(2021, 7, 21),
														Price = new Money(2.99m, Currency.UsDollars)
												}
						}
				},
				new Customer
				{
					Name = "Andrew",
				});

		context.SaveChanges();
	}

}