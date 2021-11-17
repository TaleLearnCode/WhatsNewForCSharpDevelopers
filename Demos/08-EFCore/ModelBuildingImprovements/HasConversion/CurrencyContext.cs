namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.HasConversion;

public class CurrencyContext : DbContext
{
	private readonly bool _quiet;

	public CurrencyContext(bool quiet = false)
	{
		_quiet = quiet;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder
				.EnableSensitiveDataLogging()
				.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreSample");

		if (!_quiet)
		{
			optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		// AsString
		modelBuilder.Entity<TestEntity1>()
			.Property(e => e.Currency)
			.HasConversion<string>();

		// AsShort
		modelBuilder.Entity<TestEntity2>()
			.Property(e => e.Currency)
			.HasConversion<EnumToNumberConverter<Currency, short>>();

		// AsSymbol
		modelBuilder.Entity<TestEntity3>()
			.Property(e => e.Currency)
			.HasConversion<CurrencyToSymbolConverter>();

	}

}