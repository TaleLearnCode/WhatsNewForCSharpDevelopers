namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.MappingAttributes;

internal static class MappingAttributesSample
{

	public static void Execute()
	{
		Console.WriteLine($">>>> Sample: {nameof(Execute)}");
		Console.WriteLine();

		RecreateCleanDatabase();
		PopulateDatabase();

		using BooksContext? context = new();

		var book = context.Books?.Single(e => e.Id == 1);

		Console.WriteLine(book?.Isbn);
	}

	private static void RecreateCleanDatabase()
	{
		using var context = new BooksContext();

		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}

	private static void PopulateDatabase()
	{
		using var context = new BooksContext();

		context.Add(
				new Book()
				{
					Isbn = "978-1-48-427832-1",
					Title = "Pro Microservices in .NET 6: With Examples Using ASP.NET Core 6, MassTransit, and Bubernetes",
					Price = 54.99m
				});

		context.Add(
			new Book2()
			{
				Isbn = "978-1-48-425954-2",
				Title = "The Art of Immutable Architecture: Theory and Practice of Data Management in Distributed Systems",
				Price = 59.99m
			});

		context.SaveChanges();
	}

}