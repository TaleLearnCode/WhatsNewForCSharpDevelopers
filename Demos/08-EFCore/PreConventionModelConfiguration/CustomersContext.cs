namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.PreConventionModelConfiguration;

public class CustomersContext : DbContext
{
	public DbSet<Customer> Customers { get; set; }

	private readonly bool _quiet;

	public CustomersContext(bool quiet = false)
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

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		// BoolConversion
		configurationBuilder
				.Properties<bool>()
				.HaveConversion<BoolToZeroOneConverter<int>>();

		// MoneyConversion
		configurationBuilder
				.Properties<Money>()
				.HaveConversion<MoneyConverter>()
				.HaveMaxLength(64);

		configurationBuilder
				.Properties<Money?>()
				.HaveConversion<MoneyConverter>()
				.HaveMaxLength(64);

		// DateTimeConversion
		configurationBuilder
				.Properties<DateTime>()
				.HaveConversion<long>();

		// StringFacets
		configurationBuilder
				.Properties<string>()
				.AreUnicode(false)
				.HaveMaxLength(1024);

		// IgnoreSession
		configurationBuilder
				.IgnoreAny<Session>();

		// DefaultTypeMapping
		configurationBuilder
				.DefaultTypeMapping<string>()
				.IsUnicode(false);
	}
}