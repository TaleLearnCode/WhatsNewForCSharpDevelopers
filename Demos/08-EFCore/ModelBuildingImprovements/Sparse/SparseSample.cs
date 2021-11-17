namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.Sparse;

internal static class SparseSample
{

	internal static void Execute()
	{

		Console.WriteLine($">>>> Sample: {nameof(SparseSample)}");
		Console.WriteLine();

		RecreateCleanDatabase();
		PopulateDatabase();

		using var context = new ForumContext();

		_ = context.Users?.ToList();

		Console.WriteLine();
	}

	private static void RecreateCleanDatabase()
	{
		using var context = new ForumContext();

		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}

	private static void PopulateDatabase()
	{
		using var context = new ForumContext();

		context.AddRange(
				new ForumUser { UserName = "arthur" },
				new ForumUser { UserName = "wendy" },
				new ForumUser { UserName = "smokey" },
				new ForumUser { UserName = "alice" },
				new ForumUser { UserName = "mac" },
				new ForumModerator { UserName = "baxter", ForumName = "Viral Cats" },
				new ForumUser { UserName = "olive" },
				new ForumUser { UserName = "toast" });

		context.SaveChanges();
	}
}