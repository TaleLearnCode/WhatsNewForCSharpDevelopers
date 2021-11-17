namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.HasConversion;

internal static class HasConversionSample
{

	internal static void Execute()
	{
		Console.WriteLine($">>>> Sample: {nameof(HasConversionSample)}");
		Console.WriteLine();

		RecreateCleanDatabase();
		PopulateDatabase();

		Console.WriteLine();
	}

	private static void RecreateCleanDatabase()
	{
		using var context = new CurrencyContext(quiet: true);

		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}

	private static void PopulateDatabase()
	{
		using var context = new CurrencyContext();

		context.AddRange(
			new TestEntity1
			{
				Currency = Currency.UsDollars
			},
			new TestEntity1
			{
				Currency = Currency.Euros
			},
			new TestEntity1
			{
				Currency = Currency.PoundsSterling
			},
			new TestEntity2
			{
				Currency = Currency.UsDollars
			},
			new TestEntity2
			{
				Currency = Currency.Euros
			},
			new TestEntity2
			{
				Currency = Currency.PoundsSterling
			},
			new TestEntity3
			{
				Currency = Currency.UsDollars
			},
			new TestEntity3
			{
				Currency = Currency.Euros
			},
			new TestEntity3
			{
				Currency = Currency.PoundsSterling
			});

		context.SaveChanges();

	}

}