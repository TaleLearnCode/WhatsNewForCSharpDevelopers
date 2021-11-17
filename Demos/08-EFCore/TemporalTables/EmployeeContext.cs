namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.TemporalTables;

public class EmployeeContext : DbContext
{
	public DbSet<Employee>? Employees { get; set; }

	private readonly bool _quiet;

	public EmployeeContext(bool quiet = false)
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
		#region SimpleConfig
		modelBuilder
				.Entity<Employee>()
				.ToTable("Employees", b => b.IsTemporal());
		#endregion

		#region AdvancedConfig
		modelBuilder
				.Entity<Employee>()
				.ToTable(
						"Employees",
						b => b.IsTemporal(
								b =>
								{
									b.HasPeriodStart("ValidFrom");
									b.HasPeriodEnd("ValidTo");
									b.UseHistoryTable("EmployeeHistoricalData");
								}));
		#endregion

		modelBuilder
				.Entity<Employee>(
						b =>
						{
							b.Property(e => e.Name).HasMaxLength(100);
							b.Property(e => e.Position).HasMaxLength(100);
							b.Property(e => e.Department).HasMaxLength(100);
							b.Property(e => e.Address).HasMaxLength(1024);
							b.Property(e => e.AnnualSalary).HasPrecision(10, 2);
						});
	}

}