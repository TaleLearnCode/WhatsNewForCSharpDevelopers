namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.Sparse;

public class ForumContext : DbContext
{

	public DbSet<ForumUser>? Users { get; set; }

	private readonly bool _quiet;

	public ForumContext(bool quiet = false)
	{
		_quiet = quiet;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{

		optionsBuilder
			.EnableSensitiveDataLogging()
			.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreSample");

		if (!_quiet)
			optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.Entity<ForumModerator>()
			.Property(e => e.ForumName)
			.IsSparse();
	}

}