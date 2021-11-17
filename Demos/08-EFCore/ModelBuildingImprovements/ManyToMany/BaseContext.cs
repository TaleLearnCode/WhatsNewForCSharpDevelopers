namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.ManyToMany;

public abstract class BaseContext : DbContext
{
	public bool Log { get; set; }

	public DbSet<Dog>? Dog { get; set; }
	public DbSet<Human>? Humans { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder
				.EnableSensitiveDataLogging()
				.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreSample");

		optionsBuilder.LogTo(
				s => { if (Log) Console.WriteLine(s); }, new[] { RelationalEventId.CommandExecuted });
	}

}