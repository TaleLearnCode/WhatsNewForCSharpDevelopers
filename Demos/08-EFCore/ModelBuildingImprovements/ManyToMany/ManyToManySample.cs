namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.ManyToMany;

internal static class ManyToManySample
{

	public static void Execute()
	{
		Console.WriteLine($">>>> Sample: {nameof(ManyToManySample)}");
		Console.WriteLine();

		ManyToManyTest<NoConfigContext>();
		ManyToManyTest<JustNavigationsContext>();
		ManyToManyTest<SpecifySharedEntityTypeContext>();
		ManyToManyTest<SpecifyEntityTypeContext>();
		// ManyToManyTest<SpecifyEntityTypeAndKeyContext>();
		ManyToManyTest<SpecifyEntityTypeAndFksContext>();
	}

	private static void ManyToManyTest<TContext>() where TContext : BaseContext, new()
	{
		Console.WriteLine($"{typeof(TContext).Name}: ");
		Console.WriteLine();

		using (var context = new TContext())
		{
			context.Database.EnsureDeleted();

			Console.WriteLine(context.Model.ToDebugString());
			Console.WriteLine();

			context.Log = true;
			context.Database.EnsureCreated();
			context.Log = false;

			var cats = new List<Dog>
						{
								new() { Name = "Alice" },
								new() { Name = "Mac" }
						};

			context.AddRange(new List<Human>
						{
								new() { Name = "Wendy", Dogs = { cats[0], cats[1] } },
								new() { Name = "Arthur", Dogs = { cats[0], cats[1] } }
						});

			context.SaveChanges();
		}

		Console.WriteLine();

		using (TContext? context = new())
		{
			List<Dog>? dogs = context?.Dog?.Include(e => e.Humans).ToList();
			if (dogs is not null)
			{
				foreach (var dog in dogs)
					Console.WriteLine($"{dog.Name} has {dog.Humans.Count} humans.");
			}
		}
		Console.WriteLine();
	}

}