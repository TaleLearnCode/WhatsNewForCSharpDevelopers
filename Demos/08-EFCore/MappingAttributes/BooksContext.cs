namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.MappingAttributes;

public class BooksContext : DbContext
{
	public DbSet<Book>? Books { get; set; }

	private readonly bool _quiet;

	public BooksContext(bool quiet = false)
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
		modelBuilder.Entity<Book2>();
	}

}