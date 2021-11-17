namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.PreConventionModelConfiguration;

public class SomeDbContext : DbContext
{
	protected override void ConfigureConventions(
			ModelConfigurationBuilder configurationBuilder)
	{
		// Pre-convention model configuration goes here
	}
}