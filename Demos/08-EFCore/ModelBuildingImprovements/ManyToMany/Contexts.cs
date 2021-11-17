namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.ManyToMany;

public class SpecifyEntityTypeAndFksContext : BaseContext
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Dog>()
				.HasMany(e => e.Humans)
				.WithMany(e => e.Dogs)
				.UsingEntity<DogHuman>(
						e => e.HasOne<Human>().WithMany().HasForeignKey(e => e.DogId),
						e => e.HasOne<Dog>().WithMany().HasForeignKey(e => e.HumanId),
						e => e.HasKey(e => new { e.DogId, e.HumanId }));
	}
}

public class SpecifyEntityTypeAndKeyContext : BaseContext
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Dog>()
				.HasMany(e => e.Humans)
				.WithMany(e => e.Dogs)
				.UsingEntity<DogHuman>(
						e => e.HasKey(e => new { e.DogId, e.HumanId }));
	}
}

public class SpecifyEntityTypeContext : BaseContext
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Dog>()
				.HasMany(e => e.Humans)
				.WithMany(e => e.Dogs)
				.UsingEntity<DogHuman>();
	}
}

public class SpecifySharedEntityTypeContext : BaseContext
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Dog>()
				.HasMany(e => e.Humans)
				.WithMany(e => e.Dogs)
				.UsingEntity<Dictionary<string, object>>();
	}
}

public class JustNavigationsContext : BaseContext
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Dog>()
				.HasMany(e => e.Humans)
				.WithMany(e => e.Dogs);
	}
}
public class NoConfigContext : BaseContext
{
}